using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBDD.Resources.Service
{
    public class AuthService
    {
        public static async Task<bool> ValidarUsuarioAsync(string usuario, string contra)
        {
            string cadenaConexion = "Server=,1433;Database=SistemaTransporte;User Id=sa;Password=sa2024;TrustServerCertificate=True;";
            try
            {
                using MySqlConnection conexion = new MySqlConnection(cadenaConexion);
                await conexion.OpenAsync();

                string consulta = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario AND Contraseña = @Contraseña";
                using MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@Usuario", usuario);
                comando.Parameters.AddWithValue("@Contraseña", contra);

                object resultado = await comando.ExecuteScalarAsync();
                int result = resultado is int ? (int)resultado : 0;
                return result > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error de conexión: {ex.Message}");
                return false;
            }
        }
    }
}
