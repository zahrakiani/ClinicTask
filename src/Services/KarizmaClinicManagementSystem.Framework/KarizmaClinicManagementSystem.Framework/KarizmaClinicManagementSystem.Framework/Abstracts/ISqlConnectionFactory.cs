using System.Data;

namespace KarizmaClinicManagementSystem.Framework.Abstracts;

public interface ISqlConnectionFactory
{
    IDbConnection GetOpenConnection();

    IDbConnection CreateNewConnection();

    string GetConnectionString();
}