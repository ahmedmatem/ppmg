using LibraryManagement.Services.Interfaces;

namespace LibraryManagement.Services.Implementations
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(string to, string subject, string body)
        {
            // Dummy implementation - подходяща за mock в тестовете
            Console.WriteLine($"Sending notification to {to}: {subject}");
            return Task.CompletedTask;
        }
    }
}
