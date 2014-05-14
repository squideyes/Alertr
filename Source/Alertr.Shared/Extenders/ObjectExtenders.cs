using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Alertr.Shared
{
    public static partial class ObjectExtenders
    {
        public static bool TryValidateObject(this object instance)
        {
            var results = new List<ValidationResult>();

            return instance.TryValidateObject(out results);
        }

        public static bool TryValidateObject(this object instance,
            out List<ValidationResult> results)
        {
            Contract.Requires(instance != null);

            results = new List<ValidationResult>();

            var vc = new ValidationContext(
                instance, serviceProvider: null, items: null);

            return Validator.TryValidateObject(instance, vc, results, true);
        }

        public static bool TryValidateProperty(
            this object instance, object value, string memberName)
        {
            var results = new List<ValidationResult>();

            return instance.TryValidateProperty(value, memberName, out results);
        }

        public static bool TryValidateProperty(this object instance,
            object value, string memberName, out List<ValidationResult> results)
        {
            Contract.Requires(instance != null);
            Contract.Requires(!string.IsNullOrWhiteSpace(memberName));
            
            results = new List<ValidationResult>();

            TypeDescriptor.AddProviderTransparent(
                new AssociatedMetadataTypeTypeDescriptionProvider(
                    instance.GetType()), instance.GetType());

            var vc = new ValidationContext(instance, null, null);

            vc.MemberName = memberName;

            return Validator.TryValidateProperty(value, vc, results);
        }
    }
}
