using System.Net.Http;
using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;
using KnockKnockApi.CommandHandlers;
using KnockKnockApi.Commands;

namespace KnockKnock.Api.Function
{
    public class FunctionAppConfiguration : IFunctionAppConfiguration
    {
        public void Build(IFunctionHostBuilder builder)
        {
            builder
                .Setup((services, commands) =>
                {
//                    services.AddConfiguration();
                    
                    commands.Register<FibonacciCommandHandler>();
                })
                .Authorization(auth => auth.AuthorizationDefault(AuthorizationTypeEnum.Anonymous))
                .Functions(functions =>
                    functions.HttpRoute("/api/Fibonacci",
                        route => route.HttpFunction<FibonacciCommand>(HttpMethod.Post))
                )
                .OpenApiEndpoint(openapi =>
                    openapi
                        .Title("KnockKnock Tones")
                        .Version("0.0.1")
                        .UserInterface());
        }
    }
}