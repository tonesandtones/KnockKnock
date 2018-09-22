using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using KnockKnock.Api.Commands.Config;
using KnockKnockApi.Commands;

namespace KnockKnockApi.CommandHandlers
{
    public class GetApiTokenCommandHandler : ICommandHandler<GetApiTokenCommand, string>
    {
        private readonly IAppConfig _config;

        public GetApiTokenCommandHandler(IAppConfig config)
        {
            _config = config;
        }

        public Task<string> ExecuteAsync(GetApiTokenCommand command, string previousResult)
        {
            return Task.FromResult(_config.ApiToken);
        }
    }
}