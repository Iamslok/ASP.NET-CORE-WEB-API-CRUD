namespace WEB_API.Models.Utility
{
    public class Helper
    {
        private static IConfiguration _configuration;

        public static string ConnectionString { get; set; }

        public static void LoadConfigurations(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = configuration.GetConnectionString("ApplicationDbContext");
        }

    }
}
