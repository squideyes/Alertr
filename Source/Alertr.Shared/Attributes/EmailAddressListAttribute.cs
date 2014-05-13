using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Alertr.Shared
{
    public class EmailAddressListAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            const string NOTALIST =
                "The {0} field is not a list of valid e-mail address.";

            var emailAddresses = value as List<string>;

            if ((emailAddresses != null) && 
                emailAddresses.Any(ea => !ea.IsEmailAddress()))
            {
                return new ValidationResult(
                    string.Format(NOTALIST, context.MemberName));
            }

            return ValidationResult.Success;
        }
    }
}
