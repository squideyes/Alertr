using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Alertr.Shared
{
    public static class ValidationHelper
    {
        public static bool TryValidate(object @object, 
            out List<ValidationResult> results)
        {
            var context = new ValidationContext(
                @object, serviceProvider: null, items: null);

            results = new List<ValidationResult>();
            
            return Validator.TryValidateObject(
                @object, context, results,
                validateAllProperties: true
            );
        }
    }
}
