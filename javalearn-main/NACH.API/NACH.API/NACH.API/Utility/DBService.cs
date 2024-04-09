using Microsoft.EntityFrameworkCore;
using NACH.DAL.Data;


namespace NACH.API.Utility
{
    public static class DBService
    {
        public static void AddDBServices(this IServiceCollection services, IConfiguration configuration)
        {
            string DBUserID = string.Empty;
            string DBPassWord = string.Empty;

            var dbType = configuration["ConnectionStrings:DBType"] ?? "MSSQL";

            if (configuration["ConnectionStrings:DBUserID"] != null && !string.IsNullOrEmpty(configuration["ConnectionStrings:DBUserID"].Trim()))
            {
                bool flag = false;
                string userid = Obfuscate.Decrypt(configuration["ConnectionStrings:DBUserID"].Trim(), out flag);
                if (flag)
                {
                    DBUserID = userid;
                }
            }

            if (configuration["ConnectionStrings:DBPassWord"] != null && !string.IsNullOrEmpty(configuration["ConnectionStrings:DBPassWord"].Trim()))
            {
                bool flag = false;
                string password = Obfuscate.Decrypt(configuration["ConnectionStrings:DBPassWord"].Trim(), out flag);
                if (flag)
                {
                    DBPassWord = password;
                }
            }

            services.AddScoped<ApplicationDbContext>();
            services.AddDbContext<ApplicationDbContext>(options => {
                if (dbType.Equals("oracle", StringComparison.OrdinalIgnoreCase))
                {
                    var conString = configuration["ConnectionStrings:ORACLEConnection"];
                    conString = conString.Replace("[UserID]", DBUserID);
                    conString = conString.Replace("[PassWord]", DBPassWord);

                    //options.UseOracle(conString ?? throw new InvalidOperationException("Connection string 'ORACLEConnection' not found."));
                }
                else if (dbType.Equals("mysql", StringComparison.OrdinalIgnoreCase))
                {
                    var conString = configuration["ConnectionStrings:MYSQLConnection"];
                    conString = conString.Replace("[UserID]", DBUserID);
                    conString = conString.Replace("[PassWord]", DBPassWord);

                    //options.UseMySql(conString ?? throw new InvalidOperationException("Connection string 'MYSQLConnection' not found."), ServerVersion.AutoDetect(conString));
                }
                else if (dbType.Equals("postgre", StringComparison.OrdinalIgnoreCase))
                {
                    var conString = configuration["ConnectionStrings:POSTGREConnection"];
                    conString = conString.Replace("[UserID]", DBUserID);
                    conString = conString.Replace("[PassWord]", DBPassWord);

                    //options.UseNpgsql(conString ?? throw new InvalidOperationException("Connection string 'POSTGREConnection' not found."));
                }
                else
                {
                    var conString = configuration["ConnectionStrings:DefaultConnection"];
                    conString = conString.Replace("[UserID]", DBUserID);
                    conString = conString.Replace("[PassWord]", DBPassWord);

                    options.UseSqlServer(conString ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found."));
                }
            });
        }
    }
}
