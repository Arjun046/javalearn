using Microsoft.IdentityModel.Tokens;
using NACH.DAL.Data;
using NACH.API.Enum;
using NACH.API.Utility;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NACH.API.Services
{
    public class PermissionValidator : IPermissionValidator
    {
        private readonly IWebHostEnvironment _iHostingEnvironment;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public PermissionValidator(
            IConfiguration configuration,
            IWebHostEnvironment iHostingEnvironment,
            ILogger<PermissionValidator> logger,
            ApplicationDbContext context)
        {
            _iHostingEnvironment = iHostingEnvironment;
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        public bool IsHavePermission(Form form, Rights right, string authHeader)
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
                var sessionId = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Thumbprint)?.Value;

                var user = _context.LoginMst
                    .Join(_context.role_Msts, user => user.RoleId, role => role.TranCode, (user, role) => new { user, role.RoleType })
                    .FirstOrDefault(u => u.user.SessionId == sessionId);

                return true;

                //if (user != null) {
                //    _logger.LogInformation($"Checking Permission User ID : {user.user.UserId} RoleType : {user.RoleType}");

                //    if (user.RoleType.Equals("X", StringComparison.OrdinalIgnoreCase)) {
                //        return true;
                //    } else if (user.RoleType.Equals("M", StringComparison.OrdinalIgnoreCase)) {
                //        if (form == Form.LEAVE_MASTER || form == Form.REPORT || form == Form.REPORT) {
                //            return true;
                //        }
                //    } else if (user.RoleType.Equals("O", StringComparison.OrdinalIgnoreCase)) {

                //    } else if (user.RoleType.Equals("A", StringComparison.OrdinalIgnoreCase)) {

                //    }
                //}
                //return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception: ");
                return false;
            }

            // Implement logic for validating the API key.
            return false;
        }
    }
}
