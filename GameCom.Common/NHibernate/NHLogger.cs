using Microsoft.Extensions.Logging;
using NHibernate;
using System;

namespace GameCom.Common.NHibernate
{
    /// <summary>
    /// Esta clase se usa para loguear el funcionamiento de NHibernate
    /// </summary>
    class NHLogger : INHibernateLogger
    {
        private readonly ILogger _logger;

        public NHLogger(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public bool IsEnabled(NHibernateLogLevel logLevel)
        {
            //Por el momento logueo todos los niveles
            return true;
        }

        public void Log(NHibernateLogLevel logLevel, NHibernateLogValues state, Exception exception)
        {
            _logger.LogDebug(exception, state.Format, state.Args);
        }
    }
}
