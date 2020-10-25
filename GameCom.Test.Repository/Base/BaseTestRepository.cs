using GameCom.Repository.Mapping;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using System.Configuration;

namespace GameCom.Test.Repo.Base
{
    public class BaseTestRepository
    {
        protected ISession DbSession { get; set; }

        [TestInitialize]
        public virtual void Init()
        {
            var mapper = new ModelMapper();
            mapper.AddMappings(typeof(ProductoMap).Assembly.ExportedTypes);
            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            var appConfiguration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            string connectionString = appConfiguration.GetConnectionString("DefaultConnection");

            var configuration = new NHibernate.Cfg.Configuration();            
            configuration.DataBaseIntegration(c =>
            {
                c.Dialect<NHibernate.Dialect.MySQLDialect>();
                c.ConnectionString = connectionString;
                //c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                //c.SchemaAction = SchemaAutoAction.Validate;
                //c.LogFormattedSql = true;
                //c.LogSqlInConsole = true;
            });
            configuration.AddMapping(domainMapping);

            var sessionFactory = configuration.BuildSessionFactory();

            this.DbSession = sessionFactory.OpenSession();
        }
    }
}
