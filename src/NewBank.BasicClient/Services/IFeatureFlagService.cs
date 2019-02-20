using System.Threading.Tasks;

namespace NewBank.BasicClient.Services
{
    public interface IFeatureFlagService
    {
        bool Can(string id);
    }
}