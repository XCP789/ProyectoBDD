using Android.Credentials;

namespace ProyectoBDD;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
	private async void InicioSesionClicked(object sender, EventArgs e)
    {
        if (CredentialCorrect(usuarioEntry.Text, contraEntry.Text))
        {
            await DisplayAlert("Inicio de sesi�n", "Se inico sesion correcctamente", "Aceptar");
            await Navigation.PushAsync(new Principal());
        }
        else
        {
            await DisplayAlert("Error", "Usuario o contrase�a incorrectos", "Aceptar");
        }
        
    }
    private bool CredentialCorrect(string usuario, string contra)
    {
        // Aqu� puedes implementar la l�gica para verificar las credenciales
        // Por ejemplo, comparando con valores predefinidos o consultando una base de datos
        return usuario.Trim() == "admin" && contra == "1234";
    }
}