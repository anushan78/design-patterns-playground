
namespace Patterns.Behavioural.Strategy
{
  public sealed class SmsNotificationStrategy : INotificationStrategy
  {
    public Task SendAsync(string recipient, string message, CancellationToken cancellationToken = default)
    {
        Console.WriteLine($"Sending SMS to {recipient}: {message}");
        return Task.CompletedTask;
    }
  }
}