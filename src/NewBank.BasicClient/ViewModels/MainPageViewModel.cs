using System;
using System.Linq;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using NewBank.BasicClient.Services;

namespace NewBank.BasicClient.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        readonly IFeatureFlagService _featureFlagService;

        public bool ShowSpendingAnalysis { get; private set; }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
                                 IDeviceService deviceService, IFeatureFlagService featureFlagService)
            : base(navigationService, pageDialogService, deviceService)
        {
            _featureFlagService = featureFlagService;
            Title = "Main Page";
        }

        public override void OnAppearing()
        {
            ShowSpendingAnalysis = _featureFlagService.Can(Features.CanSeeSpendingAnalysis);
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
           
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            // TODO: Handle any final tasks before you navigate away
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            switch (parameters.GetNavigationMode())
            {
                case NavigationMode.Back:
                    // TODO: Handle any tasks that should occur only when navigated back to
                    break;
                case NavigationMode.New:
                    // TODO: Handle any tasks that should occur only when navigated to for the first time
                    break;
            }

            // TODO: Handle any tasks that should be done every time OnNavigatedTo is triggered
        }

        public override void Destroy()
        {
            // TODO: Dispose of any objects you need to for memory management
        }
    }
}
