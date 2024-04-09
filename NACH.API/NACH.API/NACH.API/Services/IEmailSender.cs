namespace NACH.API.Services
{
    public interface IEmailSender
    {
        Task<Task> SendEmailAsync(string email, string subject, string message, bool send = true);
    }
}
