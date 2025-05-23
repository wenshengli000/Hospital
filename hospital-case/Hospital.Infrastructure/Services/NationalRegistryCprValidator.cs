using Hospital.Application.Interfaces;

namespace Hospital.Infrastructure.Services;

public class NationalRegistryCprValidator_: ICprValidator
{
    public Task<bool> ValidateAsync(string cpr)
    {
        throw new NotImplementedException();
    }
}