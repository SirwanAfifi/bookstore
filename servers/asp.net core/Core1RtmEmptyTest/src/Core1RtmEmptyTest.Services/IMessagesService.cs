namespace Core1RtmEmptyTest.Services
{
    public interface IMessagesService
    {
        string GetSiteName();
    }

    public class MessagesService : IMessagesService
    {
        public string GetSiteName()
        {
            return "DNT";
        }
    }
}