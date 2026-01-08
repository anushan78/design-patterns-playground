namespace Patterns.Behavioural.Strategy
{
  public sealed class EmailNotificationStrategy : INotificationStrategy
  {
    public Task SendAsync(string recipient, string message, CancellationToken cancellationToken = default)
    {
      Console.WriteLine($"Sending Email to {recipient}: {message}");
      return Task.CompletedTask;
    }
  }
}