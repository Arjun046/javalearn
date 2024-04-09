using System.Net.Mail;
using System.Net;
using System.Text;

using Microsoft.Extensions.Options;

using NACH.API.Utility;
using Microsoft.EntityFrameworkCore;
using NACH.DAL.Data;
using NACH.DAL.Model;
using NACH.DAL;


namespace NACH.API.Services
{
    public class Functional : IFunctional
    {
        private readonly ApplicationDbContext _context;
        private readonly ICommon _iCommon;
        private readonly SuperAdminDefaultOptions _superAdminDefaultOptions;
        private readonly BranchInfo _branchInfo;

        public Functional(
            ApplicationDbContext context,
             IOptions<SuperAdminDefaultOptions> superAdminDefaultOptions,
             IOptions<BranchInfo> branchInfo,
            ICommon iCommon)
        {
            _context = context;
            _iCommon = iCommon;
            _superAdminDefaultOptions = superAdminDefaultOptions.Value;
        }

        public async Task CreateBranchInfo()
        {
            try
            {
                BranchMst branch = new BranchMst();
                branch.BankCode = _branchInfo.BankCode;
                branch.BranchCode = _branchInfo.BranchCode;
                branch.BranchName = _branchInfo.BranchNm;
                branch.Address = _branchInfo.Address;
                branch.CityName = _branchInfo.CityNm;
                branch.ContactPerson = _branchInfo.ContactPerson;
                branch.PinCode = _branchInfo.PinCode;
                //branch.StateCode = _branchInfo.StateCode;
                //branch.CountryCode = _branchInfo.CountryCode;
                branch.Phone = _branchInfo.Phone;
                branch.Mobile = _branchInfo.Mobile;
                branch.Email = _branchInfo.Email;
                branch.MicrCode = _branchInfo.MicrCode;
                branch.IfscCode = _branchInfo.IfscCode;

                branch.CreatedBy = "Admin";
                branch.CreatedDate = DateTime.Now;
                branch.ModifiedBy = "Admin";
                branch.ModifiedDate = DateTime.Now;

                await _context.branch_Msts.AddAsync(branch);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }


        public Task CreateCompanyInfo()
        {
            throw new NotImplementedException();
        }

        public Task CreateDefaultAPIServices()
        {
            throw new NotImplementedException();
        }

        public Task CreateDefaultLanguageDetails()
        {
            throw new NotImplementedException();
        }

        public async Task CreateDefaultSuperAdmin()
        {
            try
            {
                var bank = await _context.bank_Msts.FirstOrDefaultAsync();
                var branch = await _context.branch_Msts.FirstOrDefaultAsync(x => x.BankCode == bank.BankCode);

                bool flag = false;
                string Password = Obfuscate.Decrypt(_superAdminDefaultOptions.Password, out flag);

                var hash = _iCommon.HashPasword(Password, out var salt);

                LoginMst profile = new()
                {
                    BankCode = bank.BankCode,
                    BranchCode = branch.BranchCode,
                    UserId = _superAdminDefaultOptions.UserName,
                    MobileNumber = _superAdminDefaultOptions.MobileNumber,
                    UserName = "Super Admin",
                    UserPass = hash,
                    PasswordSalt = salt,
                    ActiveStatus = "1",
                    RoleId = 1,
                    LockoutEnabled = false,
                    EmailId = _superAdminDefaultOptions.Email,
                    CreatedBy = "Admin",
                    CreateDate = DateTime.Now,
                    CustUserName = _superAdminDefaultOptions.UserName.ToUpper(),
                };

                await _context.LoginMst.AddAsync(profile);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task InitAppData()
        {
            throw new NotImplementedException();
        }

        public async Task SendEmailByGmailAsync(string fromEmail,
            string fromFullName,
            string subject,
            string messageBody,
            string toEmail,
            string toFullName,
            string smtpUser,
            string smtpPassword,
            string smtpHost,
            int smtpPort,
            bool smtpSSL)
        {

            var body = messageBody;
            var Message = new MailMessage();
            Message.To.Add(new MailAddress(toEmail, toFullName));
            Message.From = new MailAddress(fromEmail, fromFullName);
            Message.Subject = subject;
            Message.Body = body;
            Message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                smtp.UseDefaultCredentials = false;
                var credential = new NetworkCredential
                {
                    UserName = smtpUser,
                    Password = smtpPassword
                };
                smtp.Credentials = credential;
                smtp.Host = smtpHost;
                smtp.Port = smtpPort;
                smtp.EnableSsl = smtpSSL;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                await smtp.SendMailAsync(Message);
            }
        }

        public async Task<string> SendSMSAsync(string url, bool isPOST)
        {
            var _httpClient = new HttpClient();

            if (isPOST)
            {
                var response = await _httpClient.PostAsync(url, new StringContent("", Encoding.UTF8, "application/json"));
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                var response = await _httpClient.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
        }

        public Task<string> SendSMSAsync(string url, string data, bool isPOST)
        {
            throw new NotImplementedException();
        }

        public Task<string> UploadFile(List<IFormFile> files, IWebHostEnvironment env, string uploadFolder)
        {
            throw new NotImplementedException();
        }
    }

}