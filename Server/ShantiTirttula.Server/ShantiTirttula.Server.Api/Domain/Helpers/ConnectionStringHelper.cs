using Microsoft.AspNetCore.Connections;
using ShantiTirttula.Server.Api.Domain.Enums;

namespace ShantiTirttula.Server.Api.Domain.Helpers
{
    public class ConnectionStringHelper
    {
        private readonly string connectionString;
        private readonly EDataBaseType dbType;

        public ConnectionStringHelper()
        {
            connectionString = Environment.GetEnvironmentVariable("DATABASE") ??
                               throw new Exception(
                                   "Connection string not found in environment variables (DATABASE)");
            string dbtype = Environment.GetEnvironmentVariable("DATABASE_TYPE") ??
                               throw new Exception(
                                   "Connection string not found in environment variables (DATABASE_TYPE)");
            switch (dbtype)
            {
                case "MSSQL": dbType = EDataBaseType.MsSql; break;
                case "PostgreSql": dbType = EDataBaseType.PostgreSql; break;
            }
        }

        public string GetConnectionString()
        {
            return connectionString;
        }

        public EDataBaseType GetDataBaseType()
        {
            return dbType;
        }
    }
}
