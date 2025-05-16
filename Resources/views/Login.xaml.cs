using Microsoft.Data.SqlClient;
using Microsoft.Maui.Controls;
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
        string usuario = usuarioEntry?.Text?.Trim() ?? string.Empty;
        string contra = contraEntry?.Text ?? string.Empty;

        if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contra))
        {
            await DisplayAlert("Error", "Por favor, ingrese su usuario y contraseña.", "OK");
            return;
        }
        bool valido = await ValidarCredencialesAsync(usuario, contra);
        if (valido)
        {
            await DisplayAlert("Éxito", "Inicio de sesión exitoso.", "OK");
            await Navigation.PushAsync(new Principal());
        }
        else
        {
            await DisplayAlert("Error", "Usuario o contraseña incorrectos.", "OK");
        }

    }

        private async Task<bool> ValidarCredencialesAsync(string usuario, string contra)
        {
        string cadenaConexion = "Server=DESKTOP-KM5L4O7\\SQLEXPRESS2022,1433;Database=SistemaTransporte;User Id=sa;Password=sa2024;TrustServerCertificate=True;";

        try
        {
            using SqlConnection conexion = new SqlConnection(cadenaConexion);
            await conexion.OpenAsync();
            Debug.WriteLine("Conexión exitosa a la base de datos.");

            string consulta = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario AND Contraseña = @Contraseña";

            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@Usuario", usuario);
            comando.Parameters.AddWithValue("@Contraseña", contra);
            object resultado = await comando.ExecuteScalarAsync();
            int result = resultado is int ? (int)resultado : 0;
            return result > 0;
        }

        catch (SqlException ex)
        {
            Debug.WriteLine($"Error de conexión: {ex.Message}");
            await DisplayAlert("Error", ex.Message, "OK");
            return false;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error: {ex.Message}");
            await DisplayAlert("Error", ex.Message, "OK");
            return false;
        }

    }
}