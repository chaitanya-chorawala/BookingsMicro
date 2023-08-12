using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Hotel.Persistence.Configuration;
public class ApplicationDbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connStr;

    public ApplicationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connStr = _configuration.GetConnectionString("connStr")!;
    }

    /// <summary>
    /// Create Connection
    /// </summary>
    /// <returns></returns>
    public IDbConnection CreateConnection() => new SqlConnection(_connStr);
}
