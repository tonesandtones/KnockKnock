using System.Net.Http;
using FluentValidation;
using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;
using FunctionMonkey.FluentValidation;
using KnockKnockApi.CommandHandlers;
using KnockKnockApi.Commands;
using KnockKnockApi.Validators;
using Microsoft.Extensions.DependencyInjection;

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
                    services.AddTransient<IValidator<FibonacciCommand>, FibonacciCommandValidator>();
#else
                    commands.Register<FibUlongCommandHandler>();
                    services.AddTransient<IValidator<FibUlongCommand>, FibUlongCommandValidator>();
#endif
                    commands.Register<ReverseWordsCommandHandler>();
                    services.AddTransient<IValidator<ReverseWordsCommand>, ReverseWordsCommandValidator>();
                    
                    commands.Register<TriangleTypeCommandHandler>();
                })
                .AddFluentValidation()
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