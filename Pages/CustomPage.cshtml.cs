using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace TestWeb.Pages
{
    public class CustomPageModel : PageModel
    {
        
        public static string Header { get; set; } = "I'm your default header";
        public static string HeaderColor { get; set; } = "I'm your default color";

        public void OnGet()
        {
            
        }
        
        public async Task OnPostAsync()
        {
            var connectionString = "server=127.0.0.1; user id=test-user;database=test-web-database";

            var connection = new MySqlConnection(connectionString);
            try
            {
                await connection.OpenAsync();

                var sqlcmd = new MySqlCommand($"INSERT INTO `test-web-table` (text) VALUES ('{Request.Form["textForTestDatabase"]}')", connection);
                Console.WriteLine(sqlcmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Failed");
            }
            await connection.CloseAsync();
        }
    }
}
