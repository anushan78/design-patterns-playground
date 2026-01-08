namespace Patterns.Behavioural.FactoryMethod.Products
{
  public sealed class EmailSender : INotificationSender
  {
    public Task SendAsync(string recipient, string message, CancellationToken cancellationToken = default)
    {
        Console.WriteLine($"Sending Email to {recipient}: {message}");
        return Task.CompletedTask;
    }
  }
}