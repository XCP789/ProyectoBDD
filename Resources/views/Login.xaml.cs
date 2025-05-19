using Microsoft.Data.SqlClient;
using Microsoft.Maui.Controls;
using ProyectoBDD.Resources.Service;
using System.Diagnostics;

namespace ProyectoBDD;

public partial class Login : ContentPage
{
    public Login()
	{
		InitializeComponent();
	}
    private async void InicioSesionClicked(object sender, EventArgs e)
    {
        string usuario = usuarioEntry.Text.Trim() ?? string.Empty;
        string contra = contraEntry.Text ?? string.Empty;

        if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contra))
        {
            await DisplayAlert("Error", "Por favor, ingrese su usuario y contraseña.", "OK");
            return;
        }

        bool valido = await AuthService.ValidarUsuarioAsync(usuario, contra);

        if (valido)
        {
            await DisplayAlert("inicio de sesion", "Bienvenido", "OK");
            Application.Current.MainPage = new NavigationPage(new Principal());
        }
        else
        {
            await DisplayAlert("Error", "Usuario o contraseña incorrectos.", "OK");
        }

    }
}