

using NACH.DAL.Data;

namespace NACH.API.Services
{
    public class SMSSender: ISMSSender
    {
        private IFunctional _functional { get; }
        private readonly ICommon _iCommon;
        private readonly ILogger _logger;
        public readonly ApplicationDbContext _context;

        public SMSSender(IFunctional functional, ICommon iCommon,
           ApplicationDbContext context,
            ILogger<SMSSender> logger)
        {
            _functional = functional;
            _iCommon = iCommon;
            _context = context;
            _logger = logger;
        }

        public async Task<Task> SendSMSAsync(string mobileNo, string message, string templateId = "", bool send = true)
        {
            try
            {
                /*SendSMSMail sendSMS = new SendSMSMail()
                {
                    Sendtype = "S",
                    MobileNumber = mobileNo,
                    Description = message,
                    SendStatus = send ? "Y" : "P"
                };*/
                string response = string.Empty;
                bool IsActive = _context.parameter_Msts.Any(p => p.ParaCode == "116" && p.ParaValue == "Y");
                if (IsActive && send)
                {
                    string lsUrl = _context.parameter_Msts.FirstOrDefault(p => p.ParaCode == "111").ParaValue;
                    bool IsPost = _context.parameter_Msts.Any(p => p.ParaCode == "112" && p.ParaValue == "POST");

                    lsUrl = lsUrl.Replace("%mobile_no", mobileNo).Replace("%mobileno", mobileNo);
                    lsUrl = lsUrl.Replace("%message", message);

                   // response = await _functional.SendSMSAsync(lsUrl, IsPost);
                }
                else
                {
                    response = "Please active your sms service first";
                }

               // sendSMS.SendResponse = response;
                //_context.SendSMSMail.Add(sendSMS);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "SendSMSAsync Exception : ");
            }
            return Task.CompletedTask;
        }
    }
}
