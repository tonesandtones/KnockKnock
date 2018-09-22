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

#if SUPPORTS_BIGINTEGER
                    commands.Register<FibonacciCommandHandler>();
#else
                    commands.Register<FibUlongCommandHandler>();
#endif
                    commands.Register<ReverseWordsCommandHandler>();
                    commands.Register<TriangleTypeCommandHandler>();
                })
                .Authorization(auth => auth.AuthorizationDefault(AuthorizationTypeEnum.Anonymous))
                .Functions(functions => functions
                    .HttpRoute("/api/Fibonacci", 
#if SUPPORTS_BIGINTEGER
                    route => route.HttpFunction<FibonacciCommand>(HttpMethod.Get)
#else
                    route => route.HttpFunction<FibUlongCommand>(HttpMethod.Get)
#endif
                    )
                    .HttpRoute("/api/TriangleType", route => route.HttpFunction<TriangleTypeCommand>(HttpMethod.Get))
                    .HttpRoute("/api/ReverseWords", route => route.HttpFunction<ReverseWordsCommand>(HttpMethod.Get))
                
                )
                .OpenApiEndpoint(openapi =>
                    openapi
                        .Title("KnockKnock Tones")
                        .Version("0.0.1")
                        .UserInterface());
        }
    }
}