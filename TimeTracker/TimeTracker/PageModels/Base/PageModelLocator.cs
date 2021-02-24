using System;
using System.Collections.Generic;
using System.Text;
using TimeTracker.Pages;
using TimeTracker.Services.Account;
using TimeTracker.Services.Navigation;
using TimeTracker.Services.Statement;
using TimeTracker.Services.Work;
using TinyIoC;
using Xamarin.Forms;

namespace TimeTracker.PageModels.Base
{
    public class PageModelLocator
    {
        static TinyIoCContainer _container;
        static Dictionary<Type, Type> _viewLookup;

        static PageModelLocator()
        {
            // instantiate 
            _container = new TinyIoCContainer();
            _viewLookup = new Dictionary<Type, Type>();

            // register pages, pagemodels
            Register<DashboardPageModel, DashboardPage>();
            Register<LoginPageModel, LoginPage>();
            Register<ProfilePageModel, ProfilePage>();
            Register<SettingsPageModel, SettingsPage>();
            Register<SummaryPageModel, SummaryPage>();
            Register<TimeClockPageModel, TimeClockPage>();

            // register services (services are registered as Singletons as default)
            _container.Register<INavigationService, NavigationService>();
            _container.Register<IAccountService, MockAccountService>();
            _container.Register<IWorkService, MockWorkService>();
            _container.Register<IStatementService, MockStatementService>();
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        public static Page CreatePageFor(Type pageModelType)
        {
            var pageType = _viewLookup[pageModelType];
            var page = (Page)Activator.CreateInstance(pageType);
            var pageModel = _container.Resolve(pageModelType);
            page.BindingContext = pageModel;
            return page;
        }

        static void Register<TPageModel, TPage>() where TPageModel : PageModelBase where TPage : Page
        {
            _viewLookup.Add(typeof(TPageModel), typeof(TPage));
            _container.Register<TPageModel>();
        }
    }
}
