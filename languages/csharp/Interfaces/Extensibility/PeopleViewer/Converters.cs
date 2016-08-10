using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Data;
using System.Windows.Media;

namespace PeopleViewer
{
    public class DecadeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var dt = ((DateTime)value).ToString("yyyy/MM/dd");
            var date = DateTime.Parse(dt, CultureInfo.InvariantCulture);

            int year = (date).Year;
            return $"{year.ToString().Substring(0, 3)}0s";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class RatingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int rating = (int)value;
            return $"{rating.ToString()}/10 Stars";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class RatingStarConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int rating = (int)value;
            string output = string.Empty;
            return output.PadLeft(rating, '*');
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string input = (string)value;
            //int rating = 0;

            //foreach (var ch in input)
            //    if (ch == '*')
            //        rating++;

            //return rating;

            return input.Count(c => c == '*');
        }
    }

    public class DecadeBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string persianDateRegex = @"(?:0?[1-9]|[12][0-9]|3[01])\/(?:0?[1-9]|1[0-2])\/(?:1[23]\d{2})$";
            var date = new DateTime();

            var dt = ((DateTime) value).ToString("yyyy/MM/dd");
            if (Regex.IsMatch(dt, persianDateRegex))
                date = DateTime.Parse(dt, CultureInfo.InvariantCulture);
            else
                date = ((DateTime) value);

            int decade = (date.Year / 10) * 10;

            switch (decade)
            {
                case 1970:
                    return new SolidColorBrush(Colors.Maroon);
                case 1980:
                    return new SolidColorBrush(Colors.DarkGreen);
                case 1990:
                    return new SolidColorBrush(Colors.DarkSlateBlue);
                case 2000:
                    return new SolidColorBrush(Colors.CadetBlue);
                default:
                    return new SolidColorBrush(Colors.DarkSlateGray);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
