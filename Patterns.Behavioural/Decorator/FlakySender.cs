using Patterns.Behavioural.FactoryMethod;

namespace Patterns.Behavioural.Decorator
{
  public class FlakySender : INotificationSender
  {
    private int _faluresRemaining;

    public FlakySender(int failuresToSimulate = 1)
        => _faluresRemaining = failuresToSimulate;

    public Task SendAsync(string recipient, string message, CancellationToken cancellationToken = default)
    {
        if (_faluresRemaining-- > 0)
            throw new IOException("Simulated network failure.");
        
        Console.WriteLine($"[FLAKY] Sending to {recipient}: {message}");
        return Task.CompletedTask;
    }
  }
}