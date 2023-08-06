using System.ServiceModel;
using ProtoBuf;

namespace Shared;

[ServiceContract]
public interface IGreeter
{
    [OperationContract]
    public ValueTask<GreetResponse> GreetUser(GreetRequest request);

    [OperationContract]
    public ValueTask<AdminGreetResponse> GreetAdmin(GreetRequest request);

    [OperationContract]
    public ValueTask SendMeAMail(MailRequest request);
}

[ProtoContract]
public sealed class GreetRequest
{
    [ProtoMember(1)]
    public required string Name { get; set; }
}

[ProtoContract]
public class GreetResponse
{
    [ProtoMember(1)]
    public int ANumber { get; set; }

    [ProtoMember(2)]
    public required string Greeting { get; set; }
}

[ProtoContract]
public sealed class AdminGreetResponse
{
    [ProtoMember(1)]
    public long FakeAdminValue { get; set; }

    [ProtoMember(2)]
    public required string Greeting { get; set; }
}

[ProtoContract]
public sealed class MailRequest
{
    [ProtoMember(1)]
    public required string Message { get; set; }

    [ProtoMember(2)]
    public required string Address { get; set; }
}
