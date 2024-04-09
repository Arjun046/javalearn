namespace NACH.API.Services
{
    public interface ISessionValidator
    {
        bool IsValidSession(string authHeader);
        bool IsResetPassword(string authHeader);
    }
}
