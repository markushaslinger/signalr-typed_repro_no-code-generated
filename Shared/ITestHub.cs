namespace Shared;

public static class TestHubConfig
{
    public const string Route = "Hubs/TestHub";
}

public interface ITestHub
{
    public Task SendMessage(TestMessage message);
}

public interface ITestHubClient
{
    public Task ReceiveMessage(TestMessage message);
}

public sealed class TestMessage
{
    public required string Message { get; set; }
    public required string Sender { get; set; }
}