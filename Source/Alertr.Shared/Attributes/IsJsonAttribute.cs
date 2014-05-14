using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace Alertr.Shared
{
    public class IsJsonAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value, ValidationContext context)
        {
            const string BADJSON = "The {0} field is not JSON.";

            var json = value as string;

            if (json != null && (!IsJson(json)))
            {
                return new ValidationResult(
                    string.Format(BADJSON, context.MemberName));
            }

            return ValidationResult.Success;
        }

        private bool IsJson(string value)
        {
            try
            {
                var json = JContainer.Parse(value);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
