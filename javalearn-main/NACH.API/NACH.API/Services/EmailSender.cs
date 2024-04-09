

using NACH.DAL.Data;

namespace NACH.API.Services
{
    public class EmailSender : IEmailSender
    {

        private IFunctional _functional { get; }
        private readonly ICommon _iCommon;
        private readonly ILogger _logger;
        public readonly ApplicationDbContext _context;

        public EmailSender(IFunctional functional, ICommon iCommon,
           ApplicationDbContext context,
            ILogger<EmailSender> logger)
        {
            _functional = functional;
            _iCommon = iCommon;
            _context = context;
            _logger = logger;
        }

        public async Task<Task> SendEmailAsync(string email, string subject, string message, bool send = true)
        {
            try
            {
                bool IsEnabled = _context.parameter_Msts.FirstOrDefault(u => u.ParaCode == "108")?.ParaValue == "Y";
                if (IsEnabled)
                {
                    Int32.TryParse(_context.parameter_Msts.FirstOrDefault(u => u.ParaCode == "102")?.ParaValue, out int lsPort);
                    string lsHost = _context.parameter_Msts.FirstOrDefault(u => u.ParaCode == "101")?.ParaValue;
                    string lsUser = _context.parameter_Msts.FirstOrDefault(u => u.ParaCode == "103")?.ParaValue;
                    string lsPass = _context.parameter_Msts.FirstOrDefault(u => u.ParaCode == "104")?.ParaValue;
                    bool IsSSL = _context.parameter_Msts.FirstOrDefault(u => u.ParaCode == "105")?.ParaValue == "Y";
/*
                    if (send && lsUser != null && lsPass != null & lsHost != null)
                    {
                        await _functional.SendEmailByGmailAsync(lsUser,
                                                     lsUser,
                                                     subject,
                                                     message,
                                                     email,
                                                     email,
                                                     lsUser,
                                                     lsPass,
                                                     lsHost,
                                                     lsPort,
                                                     IsSSL);
                    }*/

                 /*   SendSMSMail sendSMS = new SendSMSMail()
                    {
                        Sendtype = "M",
                        ToMail = email,
                        Description = message,
                        Subject = subject,
                        SendStatus = send ? "Y" : "P",
                        SendTime = DateTime.Now,
                        SendResponse = send ? "send successful" : null
                    };*/
                   // _context.SendSMSMail.Add(sendSMS);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "SendEmailAsync Exception : ");
            }
            return Task.CompletedTask;
        }
    }
}
