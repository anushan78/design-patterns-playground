namespace Patterns.Behavioural.Strategy
{
    public sealed class NotificationService
    {
        private INotificationStrategy _notificationStrategy;
        
        public NotificationService(INotificationStrategy notificationStrategy)
            => _notificationStrategy = notificationStrategy;

        public void Use(INotificationStrategy notificationStrategy)
            => _notificationStrategy = notificationStrategy;

        public Task NotifyAsync(string recipient, string message, CancellationToken cancellationToken = default)
            => _notificationStrategy.SendAsync(recipient, message, cancellationToken);
    }
}