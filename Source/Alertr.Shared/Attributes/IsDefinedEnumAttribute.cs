using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Alertr.Shared
{
    public class IsDefinedEnumAttribute : ValidationAttribute
    {
        private Type type;

        public IsDefinedEnumAttribute(Type type)
        {
            Contract.Requires(type != null);
            Contract.Requires(type.IsEnum);

            this.type = type;
        }

        protected override ValidationResult IsValid(
            object value, ValidationContext vc)
        {
            if ((!type.IsEnum) || (!Enum.IsDefined(type, value)))
            {
                return new ValidationResult(string.Format(
                    "The {0} field must be set to a pre-defined {1} value.",
                    vc.MemberName, type.FullName));
            }

            return ValidationResult.Success;
        }
    }
}
