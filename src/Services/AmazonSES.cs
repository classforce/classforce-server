using System.Net;
using Amazon;
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

namespace Classforce.Server.Services;

/// <summary>
/// Service responsible for sending emails, including verification codes via Amazon Simple Email.
/// </summary>
/// <param name="configuration">The application settings.</param>
public sealed class AmazonSES(IConfiguration configuration) : IEmailService
{
    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="recipient"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="recipient"/> consists only of white-space characters.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="code"/> is less than 0 or greater than 999999.</exception>
    public async Task SendVerificationCodeAsync(string recipient, int code)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(recipient, nameof(recipient));

        if (code is < 0 or > 999999)
        {
            throw new ArgumentOutOfRangeException(nameof(code), "Verification code must be between 0 and 999999.");
        }

        var (awsAccessKeyId, awsSecretAccessKey) = GetAWSCredentials();

        using var client = new AmazonSimpleEmailServiceV2Client(awsAccessKeyId, awsSecretAccessKey, RegionEndpoint.USEast1);
        var request = new SendEmailRequest
        {
            FromEmailAddress = "noreply@classforce.net",
            Destination = new Destination { ToAddresses = [recipient] },
            Content = new EmailContent
            {
                Simple = new Message
                {
                    Subject = new Content { Data = "Classforce Verification Code" },
                    Body = new Body { Text = new Content { Data = $"Your verification code is: {code:D6}" } }
                }
            }
        };

        var response = await client.SendEmailAsync(request);
        if (response.HttpStatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Failed to send verification code to '{recipient}'. HTTP status code: {response.HttpStatusCode}");
        }
    }

    private (string awsAccessKeyId, string awsSecretAccessKey) GetAWSCredentials()
    {
        var accessKeyId = configuration["Integrations:AWS:AccessKeyId"];
        if (string.IsNullOrWhiteSpace(accessKeyId))
        {
            throw new Exception("AWS access key ID is null or white space.");
        }

        var secretAccessKey = configuration["Integrations:AWS:SecretAccessKey"];
        if (string.IsNullOrWhiteSpace(secretAccessKey))
        {
            throw new Exception("AWS secret access key is null or white space.");
        }

        return (accessKeyId, secretAccessKey);
    }
}
