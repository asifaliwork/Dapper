
using Microsoft.Data.SqlClient;
using System.Data;
namespace DapperGraphQL.Data;

public class ApplicationDbContext
{
    private readonly IConfiguration _configuration;
    private readonly string ConnectionString;
    public ApplicationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        ConnectionString = _configuration.GetConnectionString("DefaultConnection");  
    }
    public IDbConnection CreateConnection() => new SqlConnection(ConnectionString);
}
