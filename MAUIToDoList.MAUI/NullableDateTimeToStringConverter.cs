using System.Globalization;

namespace MAUIToDoList.MAUI
{
    public class NullableDateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            CultureInfo culture) => value == null ? "None"
                : string.Format("{0:d}", value);

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture) => DateTime.TryParse((string)value, out DateTime result)
                ? result : null!;
    }
}
