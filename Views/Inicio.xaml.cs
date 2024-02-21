using System.Reflection;

namespace PM2E15026.Views;

public partial class Inicio : ContentPage

{

    FileResult photo;
    public Inicio()
    {
        InitializeComponent();
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Verificacion y soliCITUD DE permisos de ubicación
        var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
        if (status != PermissionStatus.Granted)
        {
            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
            {
                await DisplayAlert("Error", "Los permisos de ubicación no están habilitados.", "OK");
                return;
            }
        }

        // ObtenCION la ubicación actual
        try
        {
            var location = await Geolocation.GetLocationAsync();
            if (location != null)
            {
                Latitud.Text = location.Latitude.ToString();
                Longitud.Text = location.Longitude.ToString();
            }
            else
            {
                await DisplayAlert("Error", "No se pudo obtener la ubicación actual.", "OK");
            }
        }
        catch (FeatureNotSupportedException)
        {
            await DisplayAlert("Error", "La geolocalización no es compatible con este dispositivo.", "OK");
        }
        catch (PermissionException)
        {
            await DisplayAlert("Error", "Los permisos de ubicación no están habilitados.", "OK");
        }
        catch (Exception)
        {
            await DisplayAlert("Error", "Se produjo un error al obtener la ubicación.", "OK");
        }
    }

    // Método para obtener la representación en Base64 de la foto
    public String GetImage64()
    {
        if (photo != null)
        {
            using (MemoryStream ms = new MemoryStream())
            {

                Stream stream = photo.OpenReadAsync().Result;
                stream.CopyTo(ms);
                byte[] data = ms.ToArray();

                String Base64 = Convert.ToBase64String(data);

                return Base64;
            }
        }
        return null;
    }

    public byte[] GetImageArray()
    {
        if (photo == null)
        {
            using (MemoryStream ms = new MemoryStream())
            {

                Stream stream = photo.OpenReadAsync().Result;
                stream.CopyTo(ms);
                byte[] data = ms.ToArray();
                return data;
            }
        }
        return null;
    }

    private async void btnAgregar_Clicked(object sender, EventArgs e)
    {
        if (double.TryParse(Latitud.Text, out double latitud) && double.TryParse(Longitud.Text, out double longitud))
        {
            // Creación de una instancia de Ubicaciones con los datos ingresados
            var lugar = new Modelos.Ubicaciones
            {
                Latitud = latitud,
                Longitud = longitud,
                Desc = Descripcion.Text,
                foto = GetImage64()
            };

            if (await App.Database.StoreSitios(lugar) > 0)
            {
                await DisplayAlert("Aviso", "Registro ingresado con exitosamente", "OK");
            }
        }
        else
        {
            // Manejo de error  si no es un num valido
            await DisplayAlert("Error", "No se encuentra la Latitud y la Longitud.", "OK");
        }
    }

    // Manejador de evento para el botón "Sitios"
    private async void btnSitios_Clicked(object sender, EventArgs e)
    {
        var Sitios = new ListaUbicaciones();
        await Navigation.PushAsync(Sitios);

    }

    private async void btnSalir_Clicked(object sender, EventArgs e)
    {
        //aun no implementado
        Application.Current.Quit(); 
    }

    // Manejador de evento para el botón "Foto"
    private async void btnFoto_Clicked(object sender, EventArgs e)
    {
        photo = await MediaPicker.CapturePhotoAsync();

        if (photo != null)
        {
            // Mostrar la foto capturada en la interfaz de usuario y guardarla localmente
            string path = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using Stream sourcephoto = await photo.OpenReadAsync();
            using FileStream Streamlocal = File.OpenWrite(path);

            foto.Source = ImageSource.FromStream(() => photo.OpenReadAsync().Result);

            await sourcephoto.CopyToAsync(Streamlocal);
        }
    }
}