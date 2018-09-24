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
                    services.AddConfiguration();

#if SUPPORTS_BIGINTEGER
                    commands.Register<FibonacciCommandHandler>();
                    services.AddTransient<IValidator<FibonacciCommand>, FibonacciCommandValidator>();
#else
                    commands.Register<FibLongCommandHandler>();
                    services.AddTransient<IValidator<FibLongCommand>, FibLongCommandValidator>();
#endif
                    commands.Register<ReverseWordsCommandHandler>();
                    services.AddTransient<IValidator<ReverseWordsCommand>, ReverseWordsCommandValidator>();
                    
                    commands.Register<TriangleTypeCommandHandler>();

                    commands.Register<GetApiTokenCommandHandler>();
                })
                .AddFluentValidation()
                .Authorization(auth => auth.AuthorizationDefault(AuthorizationTypeEnum.Anonymous))
                .Functions(functions => functions
                    .HttpRoute("/api/Fibonacci", 
#if SUPPORTS_BIGINTEGER
                    route => route.HttpFunction<FibonacciCommand>(HttpMethod.Get)
#else
                    route => route.HttpFunction<FibLongCommand>(HttpMethod.Get)
#endif
                    )
                    .HttpRoute("/api/TriangleType", route => route.HttpFunction<TriangleTypeCommand>(HttpMethod.Get))
                    .HttpRoute("/api/ReverseWords", route => route.HttpFunction<ReverseWordsCommand>(HttpMethod.Get))
                    .HttpRoute("/api/Token", route => route.HttpFunction<GetApiTokenCommand>(HttpMethod.Get))
                )
                .OpenApiEndpoint(openapi =>
                    openapi
                        .Title("KnockKnock Tones")
                        .Version("0.0.1")
                        .UserInterface());
        }
    }
}