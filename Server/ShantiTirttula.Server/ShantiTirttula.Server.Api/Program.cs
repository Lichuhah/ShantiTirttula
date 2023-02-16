

namespace ShantiTirttula.Server.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
#if DEBUG
            //NHibernateProfiler.Initialize();
#endif
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}