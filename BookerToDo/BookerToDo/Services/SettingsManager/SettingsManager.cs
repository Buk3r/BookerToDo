using Xamarin.Essentials;

namespace BookerToDo.Services.SettingsManager
{
    public class SettingsManager : ISettingsManager
    {
        public bool IsAuthorized
        {
            get { return Preferences.Get(nameof(IsAuthorized), false); }
            set { Preferences.Set(nameof(IsAuthorized), value); }
        }

        public string SelectedAppLanguage
        {
            get { return Preferences.Get(nameof(SelectedAppLanguage), string.Empty); }
            set { Preferences.Set(nameof(SelectedAppLanguage), value);  }
        }

        public void ClearSettings()
        {
            IsAuthorized = false;
        }
    }
}