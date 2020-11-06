using Microsoft.Extensions.Logging;
using NHibernate;

namespace GameCom.Common.NHibernate
{
    /// <summary>
    /// Implementación del logger factory de NHibernate
    /// </summary>
    public class NHLoggerFactory : INHibernateLoggerFactory
    {
        private readonly ILogger _appLogger;

        public NHLoggerFactory(ILogger appLogger = null)
        {
            _appLogger = appLogger;
        }

        public INHibernateLogger LoggerFor(string keyName)
        {
            return new NHLogger(_appLogger);
        }

        public INHibernateLogger LoggerFor(System.Type type)
        {
            return new NHLogger(_appLogger);
        }
    }    
}