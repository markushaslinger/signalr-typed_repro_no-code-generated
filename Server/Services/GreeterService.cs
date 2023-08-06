using Shared;

namespace Server.Services;

public sealed class GreeterService : IGreeter
{
    public ValueTask<GreetResponse> GreetUser(GreetRequest request)
    {
        throw new NotImplementedException();
    }
    
    public ValueTask<AdminGreetResponse> GreetAdmin(GreetRequest request)
    {
        throw new NotImplementedException();
    }

    public async ValueTask SendMeAMail(MailRequest request)
    {
        throw new NotImplementedException();
    }
}
