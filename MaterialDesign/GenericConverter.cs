
using System.Collections.Specialized;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MaterialDesign
{


    public class GenericConverter : IValueConverter
    {
        private readonly Dictionary<string, string>? resourcePairs;

        public GenericConverter()
        {
            this.resourcePairs = null;
        }

        public GenericConverter(Dictionary<string, string> resourcePairs)
        {
            this.resourcePairs = resourcePairs;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (resourcePairs == null)
            {
                throw new InvalidOperationException("Resource pairs not initialized");
            }

            bool isMaterialDesign = (bool)value;
            string resourceKey = isMaterialDesign ? resourcePairs.Keys.First() : resourcePairs.Values.First();
            return Application.Current.FindResource(resourceKey);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}