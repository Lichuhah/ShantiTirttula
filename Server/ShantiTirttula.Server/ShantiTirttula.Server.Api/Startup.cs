using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ShantiTirttula.Server.Api.Helpers;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace ShantiTirttula.Server.Api
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseStaticFiles();
            app.UseCors("_myAllowSpecificOrigins");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapSwagger();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("v1/swagger.json", "ShantiTirttula 1.0 alpha API"); });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                 options.JsonSerializerOptions.PropertyNamingPolicy = null;
                 //options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
             });
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAuthorization();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // укзывает, будет ли валидироваться издатель при валидации токена
                            ValidateIssuer = false,
                            // строка, представляющая издателя
                            ValidIssuer = JwtHelper.ISSUER,

                            // будет ли валидироваться потребитель токена
                            ValidateAudience = false,
                            // установка потребителя токена
                            ValidAudience = JwtHelper.AUDIENCE,
                            ValidateLifetime = false,
                            // установка ключа безопасности
                            IssuerSigningKey = JwtHelper.GetSymmetricSecurityKey(),
                            // валидация ключа безопасности
                            ValidateIssuerSigningKey = true,
                        };
                    });

            services.AddCors(options =>
            {
                options.AddPolicy("_myAllowSpecificOrigins",
                    policy =>
                    {
                        policy.SetIsOriginAllowed(_ => true);
                        policy.AllowAnyMethod();
                        policy.AllowAnyHeader();
                        policy.AllowCredentials();
                    });
            });

            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(type => type.ToString());
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShantiTirttula 1.0 alpha API", Version = "v1" });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                c.DocInclusionPredicate((_, apiDesc) =>
                {
                    if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;
                    if (methodInfo.DeclaringType?.AssemblyQualifiedName == null) return false;
                    // Exclude all DevExpress reporting controllers
                    return !methodInfo.DeclaringType.AssemblyQualifiedName.StartsWith("DevExpress",
                        StringComparison.OrdinalIgnoreCase);
                });
            });
        }
    }
}
