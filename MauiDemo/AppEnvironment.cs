namespace MauiDemo;

public interface IAppEnvironment
{
    string AppName { get; }

    string AppEnv { get; }

    string AppIdSuffix { get; }

    string ServerUrl { get; }
}

public class AppEnvironment : IAppEnvironment
{
    public required string AppName { get; init; }

    public required string AppEnv { get; init; }

    public required string AppIdSuffix { get; init; }

    public required string ServerUrl { get; init; }
}