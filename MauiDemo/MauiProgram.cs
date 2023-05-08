using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MauiDemo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if !RELEASE
        builder.Logging.AddDebug();
#endif
        
        // Select appsettings.json file based on build configuration
#if DEV
        var appSettingsFileName = "appsettings.dev.json";
#elif PROD
        var appSettingsFileName = "appsettings.prod.json";
#endif

        // Load appsettings.json file as part of configuration
        var executingAssembly = Assembly.GetExecutingAssembly();
        using (var jsonStream = executingAssembly.GetManifestResourceStream($"MauiDemo.{appSettingsFileName}"))
        {
            if (jsonStream == null)
            {
                throw new Exception($"Could not find {appSettingsFileName} file");
            }

            var config = new ConfigurationBuilder()
                .AddJsonStream(jsonStream)
                .Build();

            var mySettings = config.Get<MySettings>();
            Console.WriteLine($"AppEnv: " + mySettings?.AppEnv);

            builder.Configuration.AddConfiguration(config);
        }

        return builder.Build();
    }
}