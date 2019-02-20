using Prism.Navigation;
using Prism.Services;
using NewBank.BasicClient.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace NewBank.BasicClient.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        readonly IFeatureFlagService _featureFlagService;
        public LoginPageViewModel(
            INavigationService navigationService,
            IPageDialogService pageDialogService,
            IDeviceService deviceService,
            IFeatureFlagService featureFlagService) : base(navigationService, pageDialogService, deviceService)
        {
            _featureFlagService = featureFlagService;
            Title = "Login";
            LoginCommand = new Command(HandleAction);
        }

        async void HandleAction(object obj)
        {
            var r =  _featureFlagService.Can(Features.CanLoginWithoutCredentials);
        }


        public ICommand LoginCommand { get; set; }
        public bool NoLoginNeeded { get; set; }

        public override async void OnAppearing()
        {
            var results =  _featureFlagService.Can(Features.CanLoginWithoutCredentials);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
           
        }
    }
}
