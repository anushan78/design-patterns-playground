namespace Patterns.Behavioural.Strategy
{
    public interface INotificationStrategy
    {
        Task SendAsync(string recipient, string message, CancellationToken cancellationToken = default);
    }
}