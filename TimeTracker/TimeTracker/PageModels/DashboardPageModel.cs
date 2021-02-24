using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.PageModels.Base;

namespace TimeTracker.PageModels
{
    public class DashboardPageModel : PageModelBase
    {
        private ProfilePageModel _profilePM;
        public ProfilePageModel ProfilePageModel
        {
            get => _profilePM;
            set => SetProperty(ref _profilePM, value);
        }

        private SettingsPageModel _settingsPM;
        public SettingsPageModel SettingsPageModel
        {
            get => _settingsPM;
            set => SetProperty(ref _settingsPM, value);
        }

        private SummaryPageModel _summaryPM;
        public SummaryPageModel SummaryPageModel
        {
            get => _summaryPM;
            set => SetProperty(ref _summaryPM, value);
        }

        private TimeClockPageModel _timeclockPM;
        public TimeClockPageModel TimeClockPageModel
        {
            get => _timeclockPM;
            set => SetProperty(ref _timeclockPM, value);
        }

        public DashboardPageModel(ProfilePageModel profielPM, SettingsPageModel settingsPM, SummaryPageModel summaryPM, TimeClockPageModel timeclockPM)
        {
            ProfilePageModel = profielPM;
            SettingsPageModel = settingsPM;
            SummaryPageModel = summaryPM;
            TimeClockPageModel = timeclockPM;
        }

        public override Task InitializeAsync(object navigationData = null)
        {
            return Task.WhenAny(base.InitializeAsync(navigationData),
                ProfilePageModel.InitializeAsync(navigationData),
                SettingsPageModel.InitializeAsync(navigationData),
                SummaryPageModel.InitializeAsync(navigationData),
                TimeClockPageModel.InitializeAsync(navigationData));
        }
    }
}
