using ExampleProject;

namespace Program
{
    public class ExampleProject
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(options =>
            {
                options.UseStartup<Startup>();
            });
    }
}