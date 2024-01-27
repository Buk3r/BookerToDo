using BookerToDo.Resources.Strings;
using System.ComponentModel;
using System.Globalization;
using System.Resources;

namespace BookerToDo.Services.Localization
{
    public class LocalizationService : ILocalizationService
    {
        private readonly ResourceManager _resourceManager;

        private LocalizationService _instance;
        private CultureInfo _currentCultureInfo;

        private LocalizationService()
        {
            _resourceManager = new ResourceManager(typeof(Strings));
            SelectCurrentLanguage();
        }

        #region -- Public properties --

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region -- Public methods --

        public LocalizationService GetInstance()
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item"));
        }

        #endregion

        #region -- Private methods --

        private void SelectCurrentLanguage()
        {
            var defaultLanguage = "en-US";
            _currentCultureInfo = new CultureInfo(defaultLanguage);
        }

        #endregion
    }
}