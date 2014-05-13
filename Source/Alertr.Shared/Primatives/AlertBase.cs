namespace Alertr.Shared
{
    public abstract class AlertBase
    {
        public AlertBase(AlertVia mode)
        {
            Mode = mode;
        }

        public AlertVia Mode { get; private set; }
    }
}
