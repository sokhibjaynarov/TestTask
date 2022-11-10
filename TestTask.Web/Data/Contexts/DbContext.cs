using Microsoft.VisualBasic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace TestTask.Data.Contexts
{
    public class DbContext
    {
        private SqlConnection _connection;

        public DbContext()
        {
            _connection = new SqlConnection("Server=localhost; Database=TestTask; Trusted_Connection=True; TrustServerCertificate=True");
        }

        public async Task<SqlDataReader> ConnectionAsync(string query)
        {
            SqlCommand command = new SqlCommand(query, _connection);

            if (_connection.State == ConnectionState.Open)
                _connection.Close();
            else
            {
                _connection.Open();
                if (query.Contains("SELECT"))
                {
                    return await command.ExecuteReaderAsync();
                }
                else
                {
                    await command.ExecuteNonQueryAsync();
                }
                _connection.Close();
            }

            return null;
        }
    }
}
