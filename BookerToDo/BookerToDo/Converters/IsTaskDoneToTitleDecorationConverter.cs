using System;
using System.Globalization;
using Xamarin.Forms;

namespace BookerToDo.Converters
{
    public class IsTaskDoneToTitleDecorationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isDone = (bool)value;

            return isDone
                ? TextDecorations.Strikethrough
                : TextDecorations.None;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
