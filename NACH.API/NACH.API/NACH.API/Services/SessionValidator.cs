using Microsoft.IdentityModel.Tokens;
using NACH.DAL.Data;
using NACH.API.Utility;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NACH.API.Services
{
    public class SessionValidator : ISessionValidator
    {
        private readonly IWebHostEnvironment _iHostingEnvironment;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public SessionValidator(
            IWebHostEnvironment iHostingEnvironment,
            ApplicationDbContext context,
            IConfiguration configuration,
            ILogger<SessionValidator> logger
            )
        {
            _iHostingEnvironment = iHostingEnvironment;
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        public bool IsValidSession(string authHeader)
        {
            try
            {
                bool flag = false;
                string Secret = Obfuscate.Decrypt(_configuration["JwtAuth:Secret"], out flag);

                string token = authHeader.Split(' ')[1];
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret)),
                    ValidateLifetime = false
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
                if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("Invalid token");

                var sessionId = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Thumbprint)?.Value;
                var user = _context.LoginMst.FirstOrDefault(u => u.SessionId == sessionId);

                if (user == null)
                {
                    return false;
                }
                _logger.LogInformation($"Checking Session User ID : {user.UserId} Session ID : {user.SessionId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception: ");
                return false;
            }
            return true;
        }

        public bool IsResetPassword(string authHeader)
        {
            try
            {
                bool flag = false;
                string Secret = Obfuscate.Decrypt(_configuration["JwtAuth:Secret"], out flag);

                string token = authHeader.Split(' ')[1];
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret)),
                    ValidateLifetime = false
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
                if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("Invalid token");

                var sessionId = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Thumbprint)?.Value;
                var user = _context.LoginMst.FirstOrDefault(u => u.SessionId == sessionId);

                bool isReset = false;
                if (user == null)
                {
                    return false;
                }
                else
                {
                    if (!string.IsNullOrEmpty(user.ResetFlag))
                    {
                        isReset = user.ResetFlag.Equals("Y", StringComparison.OrdinalIgnoreCase);
                    }
                }
                _logger.LogInformation($"Checking Password Reset User ID : {user.UserId} Reset : {isReset}");
                return isReset;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception: ");
                return false;
            }
        }
    }
}
