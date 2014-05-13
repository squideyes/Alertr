using HtmlAgilityPack;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Alertr.Shared
{
    public class HtmlAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            const string BADHTML =
                "The {0} field is not an HTML document.";

            var html = value as string;

            if (html != null && (!IsHtml(html)))
            {
                return new ValidationResult(
                    string.Format(BADHTML, context.MemberName));
            }

            return ValidationResult.Success;
        }

        private bool IsHtml(string value)
        {
            var doc = new HtmlDocument();

            doc.LoadHtml(value);

            return doc.ParseErrors.Any();
        }
    }
}
