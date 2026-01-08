namespace Patterns.Behavioural.FactoryMethod.Products
{
    public sealed class SmsSender : INotificationSender
    {
        public Task SendAsync(string recipient, string message, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"Sending SMS to {recipient}: {message}");
            return Task.CompletedTask;
        }
    }
}