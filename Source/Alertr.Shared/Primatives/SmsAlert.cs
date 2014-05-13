using System.ComponentModel.DataAnnotations;

namespace Alertr.Shared.Primatives
{
    public class SmsAlert : AlertBase
    {
        public SmsAlert()
            : base(AlertVia.Sms)
        {
        }

        [Required]
        [RegularExpression("")]
        public string PhoneNumber { get; set; }
    }
}
