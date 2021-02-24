using System;
using System.Threading.Tasks;
using TimeTracker.PageModels;
using TimeTracker.PageModels.Base;
using TimeTracker.Services.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeTracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
        }

        Task InitNavigation()
        {
            var navService = PageModelLocator.Resolve<INavigationService>();
            return navService.NavigateToAsync<LoginPageModel>();
        }

        protected override async void OnStart()
        {
            await InitNavigation();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
