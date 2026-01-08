using Patterns.Behavioural.FactoryMethod;

namespace Patterns.Behavioural.Decorator
{
    public sealed class LoggingNotificationSender : NotificationSenderDecorator
    {
        public LoggingNotificationSender(INotificationSender innerSender)
            : base(innerSender)
        {
        }

        public override async Task SendAsync(string recipient, string message, CancellationToken cancellationToken = default)
        {
            var startTime = DateTime.UtcNow;
            Console.WriteLine($"[LOG] Starting to send notification to {recipient} at {startTime:u}");

            try
            {
                await InnerSender.SendAsync(recipient, message, cancellationToken);
                var endTime = DateTime.UtcNow;
                Console.WriteLine($"[LOG] Successfully sent notification to {recipient} at {endTime:u}. Duration: {(endTime - startTime).TotalMilliseconds} ms");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LOG] Failed to send notification to {recipient}. Error: {ex.Message}");
                throw;
            }
        }
    }
}