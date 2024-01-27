using BookerToDo.Resources.Strings;
using BookerToDo.Services.SettingsManager;
using System.ComponentModel;
using System.Globalization;
using System.Resources;

namespace BookerToDo.Services.Localization
{
    public class LocalizationService : ILocalizationService
    {
        private readonly ResourceManager _resourceManager;
        private readonly ISettingsManager _settingsManager;

        private static LocalizationService _instance;
        private CultureInfo _currentCultureInfo;

        private LocalizationService()
        {
            _resourceManager = new ResourceManager(typeof(Strings));
            _settingsManager = new SettingsManager.SettingsManager();
            SelectCurrentLanguage();
        }

        #region -- Public properties --

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region -- Public methods --

        public static LocalizationService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LocalizationService();
            }

            return _instance;
        }

        #endregion

        #region -- ILocalizationService implementation

        public string this[string key] => _resourceManager.GetString(key, _currentCultureInfo);

        public void SetCulture(CultureInfo culture)
        {
            _currentCultureInfo = culture;
            _settingsManager.SelectedAppLanguage = culture.Name;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item"));
        }

        #endregion

        #region -- Private methods --

        private void SelectCurrentLanguage()
        {
            var defaultLanguage = "en-US";

            if (_settingsManager.SelectedAppLanguage == string.Empty)
            {
                _currentCultureInfo = new CultureInfo(defaultLanguage);
                _settingsManager.SelectedAppLanguage = defaultLanguage;
            }
            else
            {
                _currentCultureInfo = new CultureInfo(_settingsManager.SelectedAppLanguage);
            }
        }

        #endregion
    }
}