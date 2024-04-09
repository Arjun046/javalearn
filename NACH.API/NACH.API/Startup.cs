using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NACH.DAL.Data;
using Newtonsoft.Json.Serialization;
using NACH.API.Services;
using NACH.API.Utility;
using System.Text;

namespace NACH.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDBServices(Configuration);

            services.AddCors(p => {
                p.AddPolicy("corspolicy", build => {
                    build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            bool flag = false;
            string Secret = Obfuscate.Decrypt(Configuration["JwtAuth:Secret"], out flag);

            //Adding Authentication
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // Adding Jwt Bearer
            .AddJwtBearer(options => {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,

                    ValidAudience = Configuration["JwtAuth:Audience"],
                    ValidIssuer = Configuration["JwtAuth:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret))
                };
            });

            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(5);
            });

            var _IServiceScopeFactory = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>();
            var _CreateScope = _IServiceScopeFactory.CreateScope();
            var _ServiceProvider = _CreateScope.ServiceProvider;
            var _context = _ServiceProvider.GetRequiredService<ApplicationDbContext>();
            bool IsDBCanConnect = _context.Database.CanConnect();

            services.AddTransient<ICommon, Common>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<ISMSSender, SMSSender>();
            services.AddTransient<IFunctional, Functional>();

            services.AddTransient<ISessionValidator, SessionValidator>();

            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            services.AddControllersWithViews().AddJsonOptions(options => {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            var securityScheme = new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Standard Authorization header using the Bearer scheme (\"Bearer {token}\")",
            };

            var securityReq = new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        };

            var contact = new OpenApiContact()
            {
                Name = "Soft-Tech Solutions",
                Email = "vinod@soft-techsolutions.com",
                Url = new Uri("https://soft-techsolutions.com")
            };

            var license = new OpenApiLicense()
            {
                Name = "License",
                Url = new Uri("https://soft-techsolutions.com")
            };

            var info = new OpenApiInfo()
            {
                Title = "Smart Nach Api",
                Version = "v1",
                Description = "An ASP.NET Core Web API for Smart Nach",
                TermsOfService = new Uri("https://soft-techsolutions.com/terms"),
                Contact = contact,
                License = license
            };

            services.AddSwaggerGen(o => {
                o.SwaggerDoc("v1", info);
                o.AddSecurityDefinition("Bearer", securityScheme);
                o.AddSecurityRequirement(securityReq);
            });

            services.AddHttpContextAccessor();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Smart Nach API v1");
                    c.DefaultModelsExpandDepth(-1);
                });
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Smart Nach API v1");
                    c.DefaultModelsExpandDepth(-1);
                });
            }


            //app.UseExceptionHandling();

            //app.UseRequestResponseLogging();

            //app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors("corspolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
