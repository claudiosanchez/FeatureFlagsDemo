using System.Threading.Tasks;
using NewBank.BasicClient.Views;
using Prism;
using Prism.Ioc;
using DryIoc;
using Prism.DryIoc;
using Prism.Logging;
using Xamarin.Forms;
using System;
using NewBank.BasicClient.Services;
using LaunchDarkly.Xamarin;
using LaunchDarkly.Client;

namespace NewBank.BasicClient
{

    public partial class App
    {
        string MOBILE_KEY_TEST = "mob-b3a03622-2410-4fa7-b846-e5c449c7aa97";
        /* 
        * NOTE: 
        * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
        * This imposes a limitation in which the App class must have a default constructor. 
        * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
        */
        public App()
            : this(null)
        {
        }

        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            InitializeClients();

            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        private async void InitializeClients()
        {
            var config = Configuration.Default(MOBILE_KEY_TEST)
            .WithStartWaitTime(TimeSpan.Zero);

           var _user = User.WithKey("claudio.a.sanchez@outlook.com");
            var _client = LdClient.Init(config, _user);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<TabbedPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<LoginPage>();

            // Register Services
            containerRegistry.RegisterSingleton<IFeatureFlagService, FeatureFlagService>();
            containerRegistry.RegisterSingleton<IUserContextService, UserContextService>();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle IApplicationLifecycle
            base.OnSleep();

            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle IApplicationLifecycle
            base.OnResume();

            // Handle when your app resumes
        }
    }
}
