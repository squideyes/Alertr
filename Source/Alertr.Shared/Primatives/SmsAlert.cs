namespace Alertr.Shared.Primatives
{
    public class SmsAlert : AlertBase
    {
        public SmsAlert()
            : base(AlertVia.Sms)
        {
        }
    }
}
