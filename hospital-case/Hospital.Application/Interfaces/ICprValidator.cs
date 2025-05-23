namespace Hospital.Application.Interfaces;

public interface ICprValidator
{
    Task<bool> ValidateAsync(string cpr);
}