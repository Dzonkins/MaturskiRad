using System;
using System.Globalization;
using System.Windows.Data;

namespace ProgramZaRacunovodstvo.ViewModels
{
    class DatumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                return date.ToString("dd.MM.yyyy.");
            }

            if (parameter is string param)
            {
                if (param == "end")
                {
                    return "Odaberite krajnji datum";
                }
                else if (param == "slanje")
                {
                    return "Odaberite datum slanja";
                }
            }

            return "Odaberite početni datum";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str && !string.IsNullOrWhiteSpace(str))
            {
                if (DateTime.TryParseExact(str, "dd.MM.yyyy.", culture, DateTimeStyles.None, out var parsedDate))
                {
                    return parsedDate;
                }
            }
            return Binding.DoNothing;
        }
    }
}
