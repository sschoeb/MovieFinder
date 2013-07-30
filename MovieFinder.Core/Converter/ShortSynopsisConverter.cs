using System;
using System.Globalization;
using Cirrious.CrossCore.Converters;

namespace MovieFinder.Core.Converter
{
    public class ShortSynopsisConverter : MvxValueConverter<string, string>
    {
        protected override string Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Length > 50)
            {
                return value.Substring(0, 50) + "...";
            }

            return value;
        }
    }
}
