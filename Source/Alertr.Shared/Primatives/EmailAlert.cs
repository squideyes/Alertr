using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Alertr.Shared
{
    public class EmailAlert : AlertBase 
    {
        public EmailAlert()
            : base(AlertVia.Email)
        {
        }       

        [EmailAddress]
        [Required]
        public string From { get; set; }

        [EmailAddress]
        public string Sender { get; set; }

        [EmailAddress]
        public string ReplyTo { get; set; }

        [EmailAddressList]
        [Required]
        public List<string> Tos { get; set; }

        [EmailAddressList]
        public List<string> CCs { get; set; }

        [EmailAddressList]
        public List<string> Bccs { get; set; }

        [StringLength(100)]
        [Required]
        public string Subject { get; set; }

        [Required]
        public string BodyText { get; set; }

        [Html]
        public string BodyHtml { get; set; }

        [Required]
        public EmailPriority Priority { get; set; }
    }
}
