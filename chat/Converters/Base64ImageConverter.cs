using System;
using System.Globalization;
using Xamarin.Forms;
using System.IO;

namespace chat.Converters
{
    public class Base64ToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo
                               culture)
        {
            var base64string = (string)value;
            var bytes =
            System.Convert.FromBase64String(base64string);
            var stream = new MemoryStream(bytes);
            return ImageSource.FromStream(() => stream);
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo
                                  culture)
        {
            throw new NotImplementedException();
        }
    }
}
