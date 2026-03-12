using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace Homework2.Validation
{
    //validate if first latter is lower 
    public class FirstCapitalLetterAttribute:ValidationAttribute 
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //validate the value is not null
            if (value is null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            string? valueString = value.ToString();//change the value to string
            string? firstLatter = valueString[0].ToString();//get the firt latter

            if (firstLatter != firstLatter.ToUpper()) //validate
            {
                return new ValidationResult("The first latter need be Upper");
            }

            return ValidationResult.Success;
        }
    }
}
