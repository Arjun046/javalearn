namespace NACH.API.Services
{
    public interface IFunctional
    {
        Task InitAppData();
        Task SendEmailByGmailAsync(string fromEmail,
            string fromFullName,
            string subject,
            string messageBody,
            string toEmail,
            string toFullName,
            string smtpUser,
            string smtpPassword,
            string smtpHost,
            int smtpPort,
            bool smtpSSL);

        Task<string> SendSMSAsync(string url, string data, bool isPOST);
        Task<string> SendSMSAsync(string url, bool isPOST);
        //Task GenerateRolesFromPagesAsync();
        Task CreateDefaultSuperAdmin();
        Task CreateCompanyInfo();
        Task CreateBranchInfo();
        Task CreateDefaultAPIServices();
        Task CreateDefaultLanguageDetails();
        Task<string> UploadFile(List<IFormFile> files, IWebHostEnvironment env, string uploadFolder);
    }
}