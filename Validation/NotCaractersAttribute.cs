using System.ComponentModel.DataAnnotations;

namespace Homework2.Validation
{
    public class NotCaractersAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            if(value is null)
            {
                return ValidationResult.Success;
            }
            
            var input = value.ToString();

            if (!input.All(char.IsLetterOrDigit))
            {
                return new ValidationResult("Only number or latter is allower");
            }

            return ValidationResult.Success;

        }
    }
}
