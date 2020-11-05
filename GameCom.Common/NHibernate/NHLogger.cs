using Microsoft.Extensions.Logging;
using NHibernate;
using System;

namespace GameCom.Common.NHibernate
{
    class NHLogger : INHibernateLogger
    {
        private readonly ILogger _logger;

        //private readonly Dictionary<NHibernateLogLevel, LogLevel> LevelMapping = new Dictionary<NHibernateLogLevel, LogLevel>() {
        //    { NHibernateLogLevel.Trace, LogLevel.Trace },
        //    { NHibernateLogLevel.Debug, LogLevel.Debug },
        //    { NHibernateLogLevel.Info, LogLevel.Info },
        //    { NHibernateLogLevel.Warn, LogLevel.Warn },
        //    { NHibernateLogLevel.Error, LogLevel.Error },
        //    { NHibernateLogLevel.Fatal, LogLevel.Fatal },
        //    { NHibernateLogLevel.None, LogLevel.Off },
        //};

        public NHLogger(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public bool IsEnabled(NHibernateLogLevel logLevel)
        {
            //return _logger.IsEnabled(LevelMapping[logLevel]);
            return true;
        }

        public void Log(NHibernateLogLevel logLevel, NHibernateLogValues state, Exception exception)
        {
            _logger.LogDebug(exception, state.Format, state.Args);
        }
    }
}
