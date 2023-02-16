using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using MQTTnet;
using MQTTnet.Server;
using System.Text;

namespace ShantiTirttula.Server.Dispatcher
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseStaticFiles();
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
            MqttServerOptionsBuilder options = new MqttServerOptionsBuilder()
                                     // set endpoint to localhost
                                     .WithDefaultEndpoint()
                                     // port used will be 707
                                     .WithDefaultEndpointPort(707)
                                     // handler for new connections
                                     .WithConnectionValidator(OnNewConnection)
                                     // handler for new messages
                                     .WithApplicationMessageInterceptor(OnNewMessage);

            // creates a new mqtt server     
            IMqttServer mqttServer = new MqttFactory().CreateMqttServer();

            // start the server with options  
            mqttServer.StartAsync(options.Build()).GetAwaiter().GetResult();

            services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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

        public static void OnNewConnection(MqttConnectionValidatorContext context)
        {
            var A = 5;
        }

        public static void OnNewMessage(MqttApplicationMessageInterceptorContext context)
        {
            var payload = context.ApplicationMessage?.Payload == null ? null : Encoding.UTF8.GetString(context.ApplicationMessage?.Payload);

            var A = 5;
            //MessageCounter++;

            //Log.Logger.Information(
            //    "MessageId: {MessageCounter} - TimeStamp: {TimeStamp} -- Message: ClientId = {clientId}, Topic = {topic}, Payload = {payload}, QoS = {qos}, Retain-Flag = {retainFlag}",
            //    MessageCounter,
            //    DateTime.Now,
            //    context.ClientId,
            //    context.ApplicationMessage?.Topic,
            //    payload,
            //    context.ApplicationMessage?.QualityOfServiceLevel,
            //    context.ApplicationMessage?.Retain);
        }


    }
}
