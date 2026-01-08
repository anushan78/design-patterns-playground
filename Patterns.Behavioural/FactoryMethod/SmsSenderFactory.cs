using Patterns.Behavioural.FactoryMethod.Products;

namespace Patterns.Behavioural.FactoryMethod
{
    public sealed class SmsSenderFactory : NotificationSenderFactory
    {
        public override INotificationSender CreateSender() => new SmsSender();
    }
}