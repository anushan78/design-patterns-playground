using Patterns.Behavioural.FactoryMethod;
using Patterns.Behavioural.Strategy;
using Patterns.Behavioural.Decorator;
using Patterns.Behavioural.FactoryMethod.Products;

// Strategy Pattern Usage
Console.WriteLine("== Strategy Pattern Usage Starts ==");

var notificationService = new NotificationService(new EmailNotificationStrategy());
await notificationService.NotifyAsync("user@example.com", "[Strategy] Order confirmed!");

notificationService.Use(new SmsNotificationStrategy());
await notificationService.NotifyAsync("+1234567890", "[Strategy] Your delivery is arriving today!");

Console.WriteLine("== Strategy Pattern Usage Ends ==");

// Factory Method Pattern Usage
Console.WriteLine("== Factory Method Pattern Usage Starts ==");

NotificationSenderFactory factory = new EmailSenderFactory();
await factory.SendAsync("user@example.com", "[Factory Method] Order confirmed!");

factory = new SmsSenderFactory();
await factory.SendAsync("+1234567890", "[Factory Method] Your delivery is arriving today!");

Console.WriteLine("== Factory Method Pattern Usage Ends ==");

// Decorator Pattern Usage
Console.WriteLine("== Decorator Pattern Usage Starts ==");

// Base sende from Factory Method world:
INotificationSender emailSender = new EmailSender();

// Decorate with logging functionality and retry mechanism
INotificationSender decoratedSender = new RetryNotificationSender(
  new LoggingNotificationSender(emailSender), maxAttempts: 3, delay: TimeSpan.FromSeconds(1));

await decoratedSender.SendAsync("anushanten@gmail.com", "[Decorator] Order confirmed with retries and logging!");

// Simulate flaky sender with retries and logging
INotificationSender flakySender = new RetryNotificationSender(
  new LoggingNotificationSender(new FlakySender(failuresToSimulate: 2)), maxAttempts: 5, delay: TimeSpan.FromSeconds(1));

await flakySender.SendAsync("anushanten@gmail.com", "[Decorator Flaky] Order confirmed with retries and logging!");

Console.WriteLine("== Decorator Pattern Usage Ends ==");