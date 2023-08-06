using Microsoft.AspNetCore.SignalR;
using Shared;

namespace Server.Hubs;

public sealed class TestHub : Hub<ITestHubClient>, ITestHub
{
    public Task SendMessage(TestMessage message) => Clients.Others.ReceiveMessage(message);
}
