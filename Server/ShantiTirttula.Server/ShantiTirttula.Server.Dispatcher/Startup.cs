using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using MQTTnet;
using MQTTnet.Server;
using System.Text;
using ShantiTirttula.Server.Dispatcher.Mqtt;
using ShantiTirttula.Server.Dispatcher.Sessions;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System;

namespace ShantiTirttula.Server.Dispatcher
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseStaticFiles();
            app.UseCors("_myAllowSpecificOrigins");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Login}/{action=Login}/{id?}");
                endpoints.MapSwagger();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("v1/swagger.json", "ShantiTirttula 1.0 alpha Disptacher"); });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
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
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            ShantiMqttServer mqttServer = ShantiMqttServer.GetServer();
            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(type => type.ToString());
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShantiTirttula 1.0 alpha Disptacher", Version = "v1" });
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
