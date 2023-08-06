using System.IO.Compression;
using ProtoBuf.Grpc.Server;
using Server.Hubs;
using Server.Services;
using Shared;

const string CorsPolicyName = "Sample";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCodeFirstGrpc(c => c.ResponseCompressionLevel = CompressionLevel.Optimal);
builder.Services.AddSignalR();
AddCors(builder.Services);

var app = builder.Build();

app.UseCors(CorsPolicyName);
app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });

app.MapGrpcService<GreeterService>();
app.MapHub<TestHub>(TestHubConfig.Route);
app.MapGet("/", () => "Client access only");

app.Run();


static void AddCors(IServiceCollection services)
{
    var clientOrigin = "http://localhost:5037";
    services.AddCors(o => o.AddPolicy(CorsPolicyName, builder =>
    {
        builder.WithOrigins(clientOrigin)
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials()
               .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
    }));
}