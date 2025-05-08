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
            await DisplayAlert("Inicio de sesión", "Se inico sesion correcctamente", "Aceptar");
            await Navigation.PushAsync(new Principal());
        }
        else
        {
            await DisplayAlert("Error", "Usuario o contraseña incorrectos", "Aceptar");
        }
        
    }
    private bool CredentialCorrect(string usuario, string contra)
    {
        // Aquí puedes implementar la lógica para verificar las credenciales
        // Por ejemplo, comparando con valores predefinidos o consultando una base de datos
        return usuario.Trim() == "admin" && contra == "1234";
    }
}