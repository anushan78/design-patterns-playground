using Patterns.Behavioural.FactoryMethod;

namespace Patterns.Behavioural.Decorator
{
  public abstract class NotificationSenderDecorator : INotificationSender
  {
    protected readonly INotificationSender InnerSender;

    protected NotificationSenderDecorator(INotificationSender innerSender)
        => InnerSender = innerSender ?? throw new ArgumentNullException(nameof(innerSender));

    public virtual Task SendAsync(string recipient, string message, CancellationToken cancellationToken = default)
        => InnerSender.SendAsync(recipient, message, cancellationToken);
  }
}