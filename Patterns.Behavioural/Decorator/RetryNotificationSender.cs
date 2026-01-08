using Patterns.Behavioural.FactoryMethod;

namespace Patterns.Behavioural.Decorator
{
    public sealed class RetryNotificationSender : NotificationSenderDecorator
    {
        private readonly int _maxAttempts;
        private readonly TimeSpan _delay;

        public RetryNotificationSender(INotificationSender innerSender, int maxAttempts = 3, TimeSpan? delay = null)
            : base(innerSender)
        {
            _maxAttempts = maxAttempts < 1 ? 1 : maxAttempts;
            _delay = delay ?? TimeSpan.FromSeconds(2);
        }

        public override async Task SendAsync(string recipient, string message, CancellationToken cancellationToken = default)
        {
            Exception? lastException = null;

            for (var attempt = 1; attempt <= _maxAttempts; attempt++)
            {
                try
                {
                    await InnerSender.SendAsync(recipient, message, cancellationToken);
                    if (attempt > 1)
                    {
                        Console.WriteLine($"[RETRY] Successfully sent notification to {recipient} on attempt {attempt}.");
                    }
                    return;
                }
                catch (Exception ex) when (!cancellationToken.IsCancellationRequested)
                {
                    lastException = ex;
                    Console.WriteLine($"[RETRY] Attempt {attempt} to send notification to {recipient} failed. Error: {ex.Message}");

                    if (attempt < _maxAttempts)
                    {
                        Console.WriteLine($"[RETRY] Waiting {_delay.TotalSeconds} seconds before next attempt...");
                        await Task.Delay(_delay, cancellationToken);
                    }
                }
            }

            throw new InvalidOperationException($"Failed to send notification to {recipient} after {_maxAttempts} attempts.", lastException);
        }
    }
}