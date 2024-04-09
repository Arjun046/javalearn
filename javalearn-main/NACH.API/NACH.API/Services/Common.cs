using NACH.DAL.Data;
using NACH.DAL.Model;
using NACH.API.ControllerModel;

using NACH.API.Utility;
using System.Security.Cryptography;
using System.Text;

namespace NACH.API.Services
{
    public class Common : ICommon
    {
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _iHostingEnvironment;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public Common(IWebHostEnvironment iHostingEnvironment,
            ApplicationDbContext context,
            ILogger<Common> logger,
            IConfiguration configuration)
        {
            _iHostingEnvironment = iHostingEnvironment;
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        public string HashPasword(string password, out string saltstr)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(keySize);
            saltstr = Convert.ToHexString(salt);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);
            return Convert.ToHexString(hash);
        }

        public bool VerifyPassword(string password, string hash, string salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, Convert.FromHexString(salt), iterations, hashAlgorithm, keySize);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }

        public string UploadedFile(IFormFile ProfilePicture)
        {
            string ProfilePictureFileName = null;

            if (ProfilePicture != null)
            {
                string uploadsFolder = Path.Combine(_iHostingEnvironment.ContentRootPath, "wwwroot\\upload");

                if (ProfilePicture.FileName == null)
                    ProfilePictureFileName = Guid.NewGuid().ToString() + "_" + "blank-person.png";
                else
                    ProfilePictureFileName = Guid.NewGuid().ToString() + "_" + ProfilePicture.FileName;
                string filePath = Path.Combine(uploadsFolder, ProfilePictureFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    ProfilePicture.CopyTo(fileStream);
                }
            }
            return ProfilePictureFileName;
        }

        public string UploadedRecordingFile(IFormFile uploadFile, string uploadsFolder, string uploadFileName)
        {
            if (uploadFile != null)
            {
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                string filePath = Path.Combine(uploadsFolder, uploadFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    uploadFile.CopyTo(fileStream);
                }
            }
            return uploadFileName;
        }

        public bool InsertLoginHistory(user_time_log _LoginHistory)
        {
            try
            {
                var log = _context.user_Time_Logs.Where(l => l.TranCode == _LoginHistory.TranCode).FirstOrDefault();
                if (log != null)
                {
                    log.UserId = _LoginHistory.UserId;
                    log.InLatitde = _LoginHistory.InLatitde;
                    log.InLongitude = _LoginHistory.InLongitude;

                    log.OutLatitde = _LoginHistory.OutLatitde;
                    log.OutLongitude = _LoginHistory.OutLongitude;

                    log.ClockIntime = _LoginHistory.ClockIntime;
                    log.WorkHours = _LoginHistory.WorkHours;
                    log.WorkMinutes = _LoginHistory.WorkMinutes;
                    log.ClockOuttime = _LoginHistory.ClockOuttime;
                    log.Remarks = _LoginHistory.Remarks;
                }
                else
                {
                    _context.user_Time_Logs.Add(_LoginHistory);
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception : ");
                throw ex;
            }
        }

        public async Task<bool> UpdateLoginActivity(LoginModel _LoginHistory)
        {
            try
            {
                var _user = _context.LoginMst.Where(x => (x.UserId == _LoginHistory.UserId || x.CustUserName == _LoginHistory.UserId)).Take(1).SingleOrDefault();
                if (_user != null)
                {
                    _user.LastLoginDate = DateTime.Now;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception : ");
                throw ex;
            }
        }

        public async Task<bool> UpdateActivity(string msg, string userId, string auditId)
        {
            try
            {
                user_activity activity = new user_activity()
                {
                    UserId = userId,
                    AudTimeStamp = DateTime.Now,
                    LastActivityData = msg,
                    AuditId = auditId
                };

                var _user = _context.LoginMst.Where(x => (x.UserId == userId || x.CustUserName == userId)).Take(1).SingleOrDefault();
                if (_user != null)
                {
                    activity.BankCode = _user.BankCode;
                    _user.LastActivity = DateTime.Now;
                    _user.LastActivityType = msg;
                    _context.user_Activities.Add(activity);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception : ");
                throw ex;
            }
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public string Encrypt(string textToEncrypt)
        {
            string? key = _configuration["EncryptionKey:Key"];
            bool flag = false;
            key = Obfuscate.Decrypt(key, out flag);

            return Enc(textToEncrypt, key!);
        }

        public string Decrypt(string textToDecrypt)
        {
            string? key = _configuration["EncryptionKey:Key"];
            bool flag = false;
            key = Obfuscate.Decrypt(key, out flag);
            return Dec(textToDecrypt, key!);
        }

        public string Encrypt(string textToEncrypt, string key)
        {
            return Enc(textToEncrypt, key!);
        }

        public string Decrypt(string textToDecrypt, string key)
        {
            return Dec(textToDecrypt, key!);
        }

        protected string Dec(string textToDecrypt, string key, int keysize = 128, int blocksize = 128, CipherMode cipher = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7)
        {
            try
            {
                RijndaelManaged rijndaelCipher = new RijndaelManaged();
                rijndaelCipher.Mode = cipher;
                rijndaelCipher.Padding = padding;

                rijndaelCipher.KeySize = keysize;
                rijndaelCipher.BlockSize = blocksize;
                byte[] encryptedData = Convert.FromBase64String(textToDecrypt);
                byte[] pwdBytes = Encoding.UTF8.GetBytes(key);
                byte[] keyBytes = new byte[0x10];
                int len = pwdBytes.Length;
                if (len > keyBytes.Length)
                {
                    len = keyBytes.Length;
                }
                Array.Copy(pwdBytes, keyBytes, len);
                rijndaelCipher.Key = keyBytes;
                rijndaelCipher.IV = keyBytes;
                byte[] plainText = rijndaelCipher.CreateDecryptor().TransformFinalBlock(encryptedData, 0, encryptedData.Length);
                return Encoding.UTF8.GetString(plainText);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception : ");
                return textToDecrypt;
            }
        }

        protected string Enc(string textToEncrypt, string key, int keysize = 128, int blocksize = 128, CipherMode cipher = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7)
        {
            try
            {
                RijndaelManaged rijndaelCipher = new RijndaelManaged();
                rijndaelCipher.Mode = cipher;
                rijndaelCipher.Padding = padding;

                rijndaelCipher.KeySize = keysize;
                rijndaelCipher.BlockSize = blocksize;
                byte[] pwdBytes = Encoding.UTF8.GetBytes(key);
                byte[] keyBytes = new byte[0x10];
                int len = pwdBytes.Length;
                if (len > keyBytes.Length)
                {
                    len = keyBytes.Length;
                }
                Array.Copy(pwdBytes, keyBytes, len);
                rijndaelCipher.Key = keyBytes;
                rijndaelCipher.IV = keyBytes;
                ICryptoTransform transform = rijndaelCipher.CreateEncryptor();
                byte[] plainText = Encoding.UTF8.GetBytes(textToEncrypt);
                return Convert.ToBase64String(transform.TransformFinalBlock(plainText, 0, plainText.Length));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception : ");
                return textToEncrypt;
            }
        }

        public string Masking(string text, int lastdigit)
        {
            try
            {
                string new_string = new String('X', text.Trim().Length - lastdigit)
                  + text.Trim().Substring(text.Trim().Length - lastdigit);
                return new_string;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception : ");
                return text;
            }
        }

        public string PANMasking(string text)
        {
            try
            {
                //XXXXX1234X
                if (text.Trim().Length == 10)
                {
                    string new_string = new String('X', 5) + text.Trim().Substring(5, 4) + new String('X', 1);
                    return new_string;
                }
                return text;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception : ");
                return text;
            }
        }
    }
}
