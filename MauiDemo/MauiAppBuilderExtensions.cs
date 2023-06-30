using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace MauiDemo;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder ConfigureEnvironment(this MauiAppBuilder builder,
        Action<IAppEnvironment>? onConfigure = null)
    {
        const string appSettingsFileName = "appsettings.json";
        using var jsonStream = Assembly.GetExecutingAssembly()
            .GetManifestResourceStream($"{appSettingsFileName}");

        if (jsonStream == null)
        {
            throw new Exception($"Could not find {appSettingsFileName} file");
        }

        var config = new ConfigurationBuilder()
            .AddJsonStream(jsonStream)
            .Build();
        var appEnvironment = config.Get<AppEnvironment>();

        if (appEnvironment == null)
        {
            throw new Exception($"Could not find {nameof(AppEnvironment)} in {appSettingsFileName} file");
        }

        onConfigure?.Invoke(appEnvironment);
        builder.Configuration.AddConfiguration(config);

        return builder;
    }
}