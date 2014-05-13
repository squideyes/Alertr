using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace Alertr.Shared
{
    public class EmailAlert : AlertBase
    {
        public EmailAlert()
            : base(AlertVia.Email)
        {
            var m = new MailMessage();
        }

        public string Subject { get; set; }
        public string BodyHtml { get; set; }
        public string BodyText { get; set; }
        public DateTime SendOn { get; set; }
        public DateTime? SendBy { get; set; }
        public MailPriority Priority { get; set; }
    }
}
