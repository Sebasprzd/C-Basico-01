using System;
using System.Data.SqlClient;
using System.Configuration;
using Telerik.Web.UI;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Código para ejecutar en cada carga de página (si es necesario)
    }

    protected void RadButtonEnviar_Click(object sender, EventArgs e)
    {
        try
        {
            // Obtener la cadena de conexión desde el archivo de configuración
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

            // Crear una conexión con la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); // Abrir la conexión

                // Definir la consulta SQL para insertar datos
                string query = "INSERT INTO registro (Nombre, Apellido, Correo) VALUES (@Nombre, @Apellido, @Correo)";

                // Crear un comando SQL y asignarle la consulta y la conexión
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar los parámetros y sus valores
                    command.Parameters.AddWithValue("@Nombre", RadTextBoxNombre.Text);
                    command.Parameters.AddWithValue("@Apellido", RadTextBoxApellido.Text);
                    command.Parameters.AddWithValue("@Correo", RadTextBoxCorreo.Text);

                    // Ejecutar la consulta
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            // Manejo de errores
            Response.Write("<script>alert('Error al procesar la solicitud: " + ex.Message + "');</script>");
        }
    }
}
