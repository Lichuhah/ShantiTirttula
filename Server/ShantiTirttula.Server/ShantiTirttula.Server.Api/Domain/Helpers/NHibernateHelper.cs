using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Context;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using ShantiTirttula.Server.Api.Domain.Enums;
using ShantiTirttula.Server.Api.Domain.Implementations.Mappings;
using ShantiTirttula.Server.Api.Domain.Implementations.Models;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;
using ISession = NHibernate.ISession;

namespace ShantiTirttula.Server.Api.Domain.Helpers
{
    public class NHibernateHelper
    {
        private ISessionFactory nhSessionFactory;
        private ConnectionStringHelper connecionStringHelper;

        public NHibernateHelper()
        {
            connecionStringHelper = new ConnectionStringHelper();
            nhSessionFactory = GetNHibernateSessionFactory();
        }

        public ISession OpenSession()
        {
            return nhSessionFactory.OpenSession();
        }

        private ISessionFactory GetNHibernateSessionFactory()
        {
            ModelMapper mapper = new();
            mapper.AddMappings(typeof(EntityMapping<Entity>).Assembly.ExportedTypes);
            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            Configuration configuration = new();

            switch (connecionStringHelper.GetDataBaseType())
            {
                case EDataBaseType.MsSql:
                    configuration.DataBaseIntegration(c =>
                    {
                        c.Dialect<MsSql2008Dialect>();
                        c.ConnectionString = connecionStringHelper.GetConnectionString();
                        c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
#if DEBUG
                        c.LogFormattedSql = true;
                        c.LogSqlInConsole = true;
#endif
                    });
                    break;
                case EDataBaseType.PostgreSql:
                    configuration.DataBaseIntegration(c =>
                    {
                        c.Dialect<PostgreSQLDialect>();
                        c.Driver<NpgsqlDriver>();
                        c.ConnectionString = connecionStringHelper.GetConnectionString();
#if DEBUG
                        c.LogFormattedSql = true;
                        c.LogSqlInConsole = true;
#endif
                    });
                    break;
                default:
                    throw new Exception("Database type not supported");
            }


            // configuration.Cache(cache =>
            // {
            //     cache.UseQueryCache = true;
            //     cache.Provider<CoreMemoryCacheProvider>();
            // });

            // // adding filter for exclude deleted entries
            // configuration.AddFilterDefinition(new FilterDefinition("deleteFilter", "DELETED < 100", null, true));
            // configuration.SetInterceptor(new EnableDeleteFilterInterceptor());

            configuration.CurrentSessionContext<CallSessionContext>();

            configuration.AddMapping(domainMapping);

            return configuration.BuildSessionFactory();
        }
    }
}
