using System;
using System.Data;
using System.Data.SqlClient;
using KarizmaClinicManagementSystem.Framework.Abstracts;

namespace Appointment.Infrastructure.Persistence;

public class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
{
    private readonly string connectionString;
    private IDbConnection connection;

    public SqlConnectionFactory(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public IDbConnection GetOpenConnection()
    {
        if (this.connection == null || this.connection.State != ConnectionState.Open)
        {
            this.connection = new SqlConnection(connectionString);
            this.connection.Open();
        }

        return this.connection;
    }

    public IDbConnection CreateNewConnection()
    {
        var connection = new SqlConnection(connectionString);
        connection.Open();

        return connection;
    }

    public string GetConnectionString()
    {
        return connectionString;
    }

    public void Dispose()
    {
        if (this.connection != null && this.connection.State == ConnectionState.Open)
        {
            this.connection.Dispose();
        }
    }
}