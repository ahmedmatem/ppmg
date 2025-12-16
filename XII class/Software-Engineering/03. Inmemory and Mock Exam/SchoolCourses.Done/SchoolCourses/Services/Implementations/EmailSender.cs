using SchoolCourses.Services.Interfaces;

namespace SchoolCourses.Services.Implementations
{
    public class EmailSender : IEmailSender
    {
        public Task SendAsync(string to, string subject, string body)
        {
            // Dummy implementation - ideal for mocking in tests
            Console.WriteLine($"Sending email to {to}: {subject}");
            return Task.CompletedTask;
        }
    }
}
