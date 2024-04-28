using System.Globalization;

namespace PromocyjnePrzepisy.Converters
{
    class ExpandedToRotationConverter : IValueConverter
    {
        private readonly int ROTATION = 180;
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null) return 0;
            return (bool)value == true ? 0 : ROTATION;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
