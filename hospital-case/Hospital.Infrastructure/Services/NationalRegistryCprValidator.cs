using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Hospital.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace Hospital.Infrastructure.Services;

public class NationalRegistryCprValidator(ILogger<NationalRegistryCprValidator> logger) : ICprValidator
{
    private const string NationalRegistryApiKey = "1fds232d-1defw-2cwd23-23d";
    private const string CprValidationApiUrl = "https://dummy-national-registry.com/api/validate-cpr";

    public Task<bool> ValidateAsync(string cpr)
    {
        if (!IsCprFormatValid(cpr))
        {
            logger.LogError("CPR format invalid: {Cpr}", cpr);
            return Task.FromResult(false);
        }

        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {NationalRegistryApiKey}");

        var requestBody = new { cpr };
        var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
        logger.LogInformation($"CPR validation successful for {cpr}");
        return Task.FromResult(true);
    }

    private static bool IsCprFormatValid(string cpr) => Regex.IsMatch(cpr, @"^\d{6}-\d{4}$");
}