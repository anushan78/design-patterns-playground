namespace Patterns.Behavioural.FactoryMethod
{
    public interface INotificationSender
    {
        Task SendAsync(string recipient, string message, CancellationToken cancellationToken = default);
    }
}