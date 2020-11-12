using fm.Extensions.Testing;
using GameCom.Common.NHibernate;
using GameCom.Repository.Mapping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;

namespace GameCom.Test.Repo.Base
{
    public class BaseTestRepository: ServiceTests
    {
        protected ISession DbSession { get; set; }

        protected ILogger Logger { get; set; }

        private IConfigurationRoot _appConfiguration;

        [TestInitialize]
        public virtual void Init()
        {
            this._appConfiguration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            
            InitNHibernate();
        }

        private void InitNHibernate()
        {
            var mapper = new ModelMapper();
            mapper.AddMappings(typeof(ProductoMap).Assembly.ExportedTypes);
            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            string connectionString = _appConfiguration.GetConnectionString("DefaultConnection");

            var configuration = new NHibernate.Cfg.Configuration();
            configuration.DataBaseIntegration(c =>
            {
                c.Dialect<NHibernate.Dialect.MySQLDialect>();
                c.ConnectionString = connectionString;
                //c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                //c.SchemaAction = SchemaAutoAction.Validate;
                #if (DEBUG)
                    c.LogFormattedSql = true;
                    c.LogSqlInConsole = true;
                #endif

            });

            configuration.AddMapping(domainMapping);

            var sessionFactory = configuration.BuildSessionFactory();

            this.DbSession = sessionFactory.OpenSession();

            #if (DEBUG)
                NHibernateLogger.SetLoggersFactory(new NHLoggerFactory(this.Log));
            #endif
        }

        protected override void ConfigureLogging(ILoggingBuilder builder)
        {
            base.ConfigureLogging(builder);

            // Add additional loggers or configuration
            builder.AddDebug().AddFilter(logLevel => true);            
        }
    }
}
