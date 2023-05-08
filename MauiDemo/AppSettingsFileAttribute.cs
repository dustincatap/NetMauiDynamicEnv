namespace MauiDemo;

[AttributeUsage(AttributeTargets.Assembly)]
public class AppSettingsFileAttribute : Attribute
{
    public AppSettingsFileAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
}