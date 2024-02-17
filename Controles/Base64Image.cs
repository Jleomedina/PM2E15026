using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2E15026.Controles
{
    public class Base64Image : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageSource imageSource = null;

            if (value != null)
            {
                // Convierte la cadena Base64 a un arreglo de bytes
                String Base64 = (String)value;
                byte[] fotobyte = System.Convert.FromBase64String(Base64);

                // Crea un flujo de memoria a partir del arreglo de bytes
                var stream = new MemoryStream(fotobyte);

                // Crea un objeto ImageSource a partir del flujo de memoria
                imageSource = ImageSource.FromStream(() => stream);
            }
            return imageSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
