using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System;

namespace Macarron.Pages
{
    public class CrearTiendaModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public CrearTiendaModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty]
        public string Nombre { get; set; }

        [BindProperty]
        public string Direccion { get; set; }

        [BindProperty]
        public string Telefono { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Tiendas (Nombre, Direccion, Telefono) VALUES (@Nombre, @Direccion, @Telefono)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", Nombre);
                        command.Parameters.AddWithValue("@Direccion", Direccion);
                        command.Parameters.AddWithValue("@Telefono", Telefono);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Maneja errores de conexión o consulta aquí
                    ModelState.AddModelError(string.Empty, $"Error al guardar los datos: {ex.Message}");
                    return Page();
                }
            }

            return RedirectToPage("/Index");
        }
    }
}
