using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NACH.DAL.Data;
using NACH.DAL.Model;
using NACH.API.Utility;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace NACH.API.Controllers
{
   
    [ApiController]
    [Route("/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : ControllerBase
    {
        private const string AuthorizationHeaderName = "Authorization";
        public readonly IConfiguration _configuration;
        public readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

        public BaseController(
           IConfiguration configuration = null,
           ApplicationDbContext context = null,
           IHttpContextAccessor httpContextAccessor = null)
        {
            _configuration = configuration;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public JwtSecurityToken CreateToken(List<Claim> authClaims)
        {

            bool flag = false;
            string Secret = Obfuscate.Decrypt(_configuration["JwtAuth:Secret"], out flag);

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
            _ = int.TryParse(_configuration["JwtAuth:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtAuth:Issuer"],
                audience: _configuration["JwtAuth:Audience"],
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
            return token;
        }

        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            bool flag = false;
            string Secret = Obfuscate.Decrypt(_configuration["JwtAuth:Secret"], out flag);

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

            return principal;

        }

        public string GetUniqueKey(int maxSize = 15)
        {
            char[] chars = new char[62];
            chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        public string GenerateRandomOTP(int iOTPLength)
        {
#if DEBUG
            return "0".PadLeft(iOTPLength, '0');
#endif
            string sOTP = String.Empty;
            string sTempChars = String.Empty;
            Random rand = new Random();
            for (int i = 0; i < iOTPLength; i++)
            {
                int p = rand.Next(0, saAllowedCharacters.Length);
                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];
                sOTP += sTempChars;
            }
            return sOTP;
        }

        public LoginMst? GetSessionUser(out role_mst? roleMst)
        {
            roleMst = null;
            if (_httpContextAccessor == null)
            {
                return null;
            }
            else
            {
                string authHeader = _httpContextAccessor.HttpContext.Request.Headers[AuthorizationHeaderName];
                if (authHeader != null && authHeader.StartsWith("Bearer"))
                {
                    string token = authHeader.Split(' ')[1];

                    bool flag = false;
                    string Secret = Obfuscate.Decrypt(_configuration["JwtAuth:Secret"], out flag);

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
                    var UserId = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
                    var user = _context.LoginMst.FirstOrDefault(u => u.UserId == UserId);
                    if (user != null)
                    {
                        roleMst = _context.role_Msts.FirstOrDefault(x => x.TranCode == user.RoleId);
                    }
                    return user;
                }
                return null;
            }
        }
    }
}
