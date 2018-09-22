namespace KnockKnock.Api.Commands.Config
{
    public interface IAppConfig
    {
        string ApiToken { get; }
    }

    public class AppConfig : IAppConfig
    {
        public string ApiToken { get; set;  }
    }
}