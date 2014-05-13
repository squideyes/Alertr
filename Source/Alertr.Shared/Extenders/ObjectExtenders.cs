using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Alertr.Shared
{
    public static partial class ObjectExtenders
    {
        public static bool ValidateProperty(this object @object, string propertyName, object value)
        {
            TypeDescriptor.AddProviderTransparent(
                new AssociatedMetadataTypeTypeDescriptionProvider(
                    @object.GetType()), @object.GetType());

            var context = new ValidationContext(@object, null, null);

            context.MemberName = propertyName;

            var results = new List<ValidationResult>();

            return Validator.TryValidateProperty(value, context, results);
        }
    }
}
