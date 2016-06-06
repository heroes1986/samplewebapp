namespace SampleWebApp.Services
{
    public interface IHomeService
    {
        string GetIndexName();
        string GetAboutDescription();
        string GetContractMessage();
    }

    public class HomeService : IHomeService
    {
        public string GetIndexName()
        {
            return "Index";
        }

        public string GetAboutDescription()
        {
            return "Your application description page.";
        }

        public string GetContractMessage()
        {
            return "Your contact page.";
        }
    }
}