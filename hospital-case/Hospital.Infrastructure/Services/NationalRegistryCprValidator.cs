using Hospital.Application.Interfaces;

namespace Hospital.Infrastructure.Services;

public class NationalRegistryCprValidator: ICprValidator
{
    public Task<bool> ValidateAsync(string cpr)
    {
        Console.WriteLine($"[LOG] Validating CPR: {cpr}");
        return Task.FromResult(true); // Dummy response
    }
}