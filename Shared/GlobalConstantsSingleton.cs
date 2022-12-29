using System.ComponentModel;

namespace LibrarySystem.Shared
{
    public class GlobalConstantsSingleton
    {
        public static GlobalConstantsSingleton? instance;
        public readonly string? ConnectionString;

        public GlobalConstantsSingleton(string? connectionString)
        {
            ConnectionString = connectionString;
        }
    
        private static void Init()
        {
            // dependency injecton
            var configuration = new ConfigurationBuilder().AddJsonFile(
                                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json"))
                            .Build();
            instance = new GlobalConstantsSingleton(configuration.GetConnectionString("Default"));
        }
        public static GlobalConstantsSingleton GetInstance()
        {
            if (instance==null)
            {
                Init();
            }
            return instance!;
        }
        
    }
}
