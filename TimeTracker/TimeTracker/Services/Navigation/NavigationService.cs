using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.PageModels.Base;
using Xamarin.Forms;

namespace TimeTracker.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public Task GoBackAsync()
        {
            return App.Current.MainPage.Navigation.PopAsync();
        }

        public async Task NavigateToAsync<TPageModel>(object navigationData = null, bool setRoot = false)
            where TPageModel : PageModelBase
        {
            var page = PageModelLocator.CreatePageFor(typeof(TPageModel));

            if (setRoot)
            {
                // if it's a tabbed page, we dont want to wrap it in a navigation page (the bar at the top with the arrow)
                // ensures there's no back arrow at top bar when page is in a tabview
                if (page is TabbedPage tabbedPage)
                {
                    App.Current.MainPage = tabbedPage;
                }
                else
                    App.Current.MainPage = new NavigationPage(page);
            }
                
            else
            {
                // if it's a tabbed page, we dont want to wrap it in a navigation page (the bar at the top with the arrow)
                // ensures there's no back arrow at top bar when page is in a tabview
                if (page is TabbedPage tabPage)
                {
                    App.Current.MainPage = tabPage;
                }
                else if (App.Current.MainPage is NavigationPage navPage)
                {
                    await navPage.PushAsync(page);
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(page);
                }
            }

            if (page.BindingContext is PageModelBase pmBase)
            {
                await pmBase.InitializeAsync(navigationData);
            }
        }
    }
}
