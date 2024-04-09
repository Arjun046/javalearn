namespace NACH.API.Services
{
    public interface ISMSSender
    {
        Task<Task> SendSMSAsync(string mobileNo, string message, string templateId = "", bool send = true);
    }
}
