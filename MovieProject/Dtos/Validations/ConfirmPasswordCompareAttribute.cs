using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Dtos.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class ConfirmPasswordCompareAttribute : ValidationAttribute
    {
        private readonly string _comparisionPassword;

        public ConfirmPasswordCompareAttribute(string comparisionPassword)
        {
            _comparisionPassword = comparisionPassword;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var currentValue = value;

            var property = validationContext.ObjectType.GetProperty(_comparisionPassword);

            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var comparisonValue = property.GetValue(validationContext.ObjectInstance);

            if (!string.Equals(currentValue, comparisonValue))
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}
