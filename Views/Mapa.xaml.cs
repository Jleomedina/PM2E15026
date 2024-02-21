using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace PM2E15026.Views
{
    public partial class Mapa : ContentPage
    {
        double latitud;
        double longitud;
        string descripcion;

        // Constructor que toma la latitud, longitud y descripci�n como par�metros
        public Mapa(double latitud, double longitud, string descripcion)
        {
            // Inicializar las variables con los valores proporcionados
            InitializeComponent();

            this.latitud = latitud;
            this.longitud = longitud;
            this.descripcion = descripcion;

            // llamar al M�todo para agregar un pin al mapa
            AddPinToMap();
        }

        // M�todo para agregar un pin al mapa
        private void AddPinToMap()
        {
            Pin pin = new Pin
            {
                Label = descripcion,
                Location = new Location(latitud, longitud)
            };

            punto.Pins.Add(pin);
            punto.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Location, Distance.FromMiles(1)));
        }

        // Evento de clic para el bot�n de compartir ubicaci�n
        private async void CompartirUbicacion_Clicked(object sender, EventArgs e)
        {
            // Crear un texto con la ubicaci�n
            string ubicacionTexto = $"Mi ubicaci�n: {latitud}, {longitud}";

            // Compartir la ubicaci�n a trav�s de la aplicaci�n predeterminada de mensajer�a
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = ubicacionTexto,
                Title = "Compartir Ubicaci�n"
            });
        }
    }
}
