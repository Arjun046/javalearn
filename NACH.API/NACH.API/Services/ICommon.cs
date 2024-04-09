using NACH.DAL.Model;
using NACH.API.ControllerModel;


namespace NACH.API.Services
{
    public interface ICommon
    {
        string UploadedFile(IFormFile ProfilePicture);
        string UploadedRecordingFile(IFormFile uploadFile, string uploadsFolder, string uploadFileName);
        bool InsertLoginHistory(user_time_log _LoginHistory);
        Task<bool> UpdateLoginActivity(LoginModel _LoginHistory);
        Task<bool> UpdateActivity(string msg, string userId, string auditId);
        string HashPasword(string password, out string saltstr);
        bool VerifyPassword(string password, string hash, string salt);
        string Encrypt(string textToEncrypt);
        string Encrypt(string textToEncrypt, string key);
        string Decrypt(string textToDecrypt);
        string Decrypt(string textToDecrypt, string key);
        string Masking(string text, int lastdigit);
        string PANMasking(string text);
        string Base64Encode(string plainText);
        string Base64Decode(string plainText);
    }
}
