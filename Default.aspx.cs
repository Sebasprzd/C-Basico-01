using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Código para ejecutar al cargar la página
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Cadena de conexión a tu base de datos
        string connectionString = "Server=localhost; Database=visual01; Integrated Security=True;";

        // Consulta SQL para insertar datos
        string query = "INSERT INTO registro (Nombre, Apellido, Correo) VALUES (@Nombre, @Apellido, @Correo)";

        // Crear conexión y comando
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Agregar parámetros 
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);

                try
                {
                    // Abrir conexión y ejecutar comando
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("Datos registrados correctamente.");
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Response.Write("Error: " + ex.Message);
                }
            }
        }
    }

    protected void btnLoadData_Click(object sender, EventArgs e)
    {
        // Cadena de conexión a tu base de datos
        string connectionString = "Server=localhost; Database=visual01; Integrated Security=True;";

        // Consulta SQL para seleccionar todos los registros
        string query = "SELECT Id, Nombre, Apellido, Correo, FechaRegistro FROM registro";

        // Crear conexión y comando
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                try
                {
                    // Llenar DataTable con los datos
                    sda.Fill(dt);
                    // Asignar DataTable al GridView
                    gvDatos.DataSource = dt;
                    gvDatos.DataBind();
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Response.Write("Error: " + ex.Message);
                }
            }
        }
    }

    protected void btnUploadPdf_Click(object sender, EventArgs e)
    {
        if (fileUploadPdf.HasFile)
        {
            try
            {
                // Verifica si el archivo es un PDF
                if (fileUploadPdf.PostedFile.ContentType == "application/pdf")
                {
                    string connectionString = "Server=localhost; Database=visual01; Integrated Security=True;";
                    string query = "INSERT INTO registro (Nombre, Apellido, Correo, FechaRegistro, PDF) VALUES (@Nombre, @Apellido, @Correo, @FechaRegistro, @PDF)";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            // Agregar parámetros para los datos
                            cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                            cmd.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                            cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                            cmd.Parameters.AddWithValue("@FechaRegistro", DateTime.Now);

                            // Convertir el archivo a un array de bytes
                            byte[] pdfData = fileUploadPdf.FileBytes;
                            cmd.Parameters.AddWithValue("@PDF", pdfData);

                            try
                            {
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                Response.Write("PDF cargado correctamente.");
                            }
                            catch (Exception ex)
                            {
                                Response.Write("Error: " + ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    Response.Write("Por favor, sube un archivo PDF.");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }
        else
        {
            Response.Write("No se seleccionó ningún archivo.");
        }
    }

    protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewPdf")
        {
            // Obtener el ID del archivo PDF desde el CommandArgument
            string id = e.CommandArgument.ToString();
            if (!string.IsNullOrEmpty(id))
            {
                // Cadena de conexión a tu base de datos
                string connectionString = "Server=localhost; Database=visual01; Integrated Security=True;";
                string query = "SELECT PDF FROM registro WHERE Id = @Id";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        try
                        {
                            conn.Open();
                            byte[] pdfData = (byte[])cmd.ExecuteScalar();

                            if (pdfData != null)
                            {
                                // Configurar la respuesta para enviar el archivo PDF al navegador
                                Response.ContentType = "application/pdf";
                                Response.AddHeader("content-disposition", "attachment;filename=archivo.pdf");
                                Response.BinaryWrite(pdfData);
                                Response.End();
                            }
                            else
                            {
                                Response.Write("No se encontró el archivo PDF.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Response.Write("Error: " + ex.Message);
                        }
                    }
                }
            }
        }
    }
}
