using System.Text.RegularExpressions;

namespace Hospital.Domain.ValueObjects
{
    public class Cpr
    {
        public string Value { get; }

        public Cpr(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !IsValidFormat(value))
                throw new ArgumentException("Invalid CPR format.", nameof(value));

            Value = value;
        }

        private static bool IsValidFormat(string value) => Regex.IsMatch(value, @"^\d{10}$");

        public override string ToString() => Value;

        public override bool Equals(object? obj) => obj is Cpr other && Value == other.Value;

        public override int GetHashCode() => Value.GetHashCode();
    }

}
