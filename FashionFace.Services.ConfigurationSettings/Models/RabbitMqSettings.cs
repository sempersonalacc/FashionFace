#pragma warning disable CS8618
namespace FashionFace.Services.ConfigurationSettings.Models;

public sealed record RabbitMqSettings
{
    public bool IsEnabled { get; init; }
    public string Host { get; init; }
    public string VHost { get; init; }
    public int Port { get; init; }
    public string UserName { get; init; }
    public string Password { get; init; }
}