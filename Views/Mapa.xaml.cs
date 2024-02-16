using AndroidX.Lifecycle;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using static Android.Icu.Text.Transliterator;

namespace PM2E15026.Views;

public partial class Mapa : ContentPage
{

    double latitud;
    double longitud;
    string descripcion;


    public Mapa(double latitud, double longitud, string descripcion)
    {
        InitializeComponent();

        this.latitud = latitud;
        this.longitud = longitud;
        this.descripcion = descripcion;

        AddPinToMap();

    }
    private void AddPinToMap()
    {
        Pin pin = new Pin
        {
            Label = descripcion,
            Location = new Location(latitud, longitud)
        };

        hola.Pins.Add(pin);
        hola.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Location, Distance.FromMiles(1)));
    }


}