using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace Homework2.Validation
{
    public class FirstCapitalLetterAttribute:ValidationAttribute 
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            string? valueString = value.ToString();
            string? firstLatter = valueString[0].ToString();

            if (firstLatter != firstLatter.ToUpper())
            {
                return new ValidationResult("The first latter need be Upper");
            }

            return ValidationResult.Success;
        }
    }
}
