using Core1RtmEmptyTest.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Core1RtmEmptyTest.Services
{
    /*public interface IMessagesService
    {
        string GetSiteName();
    }

    public class MessagesService : IMessagesService
    {
        private readonly IConfigurationRoot _configurationRoot;
        private readonly IOptions<SmtpConfig> _settings; 

        public MessagesService(IConfigurationRoot configurationRoot, IOptions<SmtpConfig> settings)
        {
            _configurationRoot = configurationRoot;
            _settings = settings;
        }

        public string GetSiteName()
        {
            var key1 = _configurationRoot["the-key"];
            var server = _settings.Value.Server;
            return $"DNT {key1} - {server}";
        }
    }*/
}