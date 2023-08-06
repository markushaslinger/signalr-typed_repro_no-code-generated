# MWE showing 'no code generated'

Steps to reproduce:

1. Clone
2. Run `dotnet restore` in sln folder
3. Run `dotnet run` in the `Server` folder - keep terminal open
4. Run `dotnet run` in the `Client` folder - keep terminal open
5. Open browser at `http://localhost:5037`
6. Check browser console (F12) Exception was thrown: `Failed to create a hub proxy. TypedSignalR.Client did not generate source code to create a hub proxy, which type is Shared.ITestHub.`
    * Can be debugged in an IDE

Notes:

* gRPC services are without function in this MWE, they just demonstrate that the original project uses them and thus the required packages are installed (in case those lead to conflicts)
* Auth is faked here, the SignalR connection sens a JWT Bearer token when starting the connection - this works in the original project, so here just as a fake demonstration and not expected to interfere
* Starting the connection _does_ work, the problem comes when attempting to access `CreateHubProxy`
* The project is configured for .NET 8 preview 6 already