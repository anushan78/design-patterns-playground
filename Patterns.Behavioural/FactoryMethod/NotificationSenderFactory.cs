namespace Patterns.Behavioural.FactoryMethod
{
    public abstract class NotificationSenderFactory
    {
        // Factory Method
        public abstract INotificationSender CreateSender();

        // Optional: shared method to send notification
        public async Task SendAsync(string recipient, string message, CancellationToken cancellationToken = default)
        {
            var sender = CreateSender();
            await sender.SendAsync(recipient, message, cancellationToken);
        }
    }
}