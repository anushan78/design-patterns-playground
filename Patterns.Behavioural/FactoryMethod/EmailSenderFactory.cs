using Patterns.Behavioural.FactoryMethod.Products;

namespace Patterns.Behavioural.FactoryMethod
{
  public sealed class EmailSenderFactory : NotificationSenderFactory
  {
    public override INotificationSender CreateSender() => new EmailSender();
  }
}