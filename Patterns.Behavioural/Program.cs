using Patterns.Behavioural.FactoryMethod;
using Patterns.Behavioural.Strategy;

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