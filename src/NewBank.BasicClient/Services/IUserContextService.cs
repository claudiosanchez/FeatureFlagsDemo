using LaunchDarkly.Client;

namespace NewBank.BasicClient.Services
{
    public interface IUserContextService
    {
        User CurrentUser();
     }
}