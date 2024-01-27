using System.ComponentModel;
using System.Globalization;

namespace BookerToDo.Services.Localization
{
    public interface ILocalizationService : INotifyPropertyChanged
    {
        string this[string key] { get; }

        void SetCulture(CultureInfo culture);
    }
}
