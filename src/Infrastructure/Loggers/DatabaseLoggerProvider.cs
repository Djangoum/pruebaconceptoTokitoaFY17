using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Loggers
{
    public class DatabaseLoggerProvider : ILoggerProvider
    {
        private readonly Func<string, LogLevel, bool> _filter;
        private readonly IConfiguration config;

        public DatabaseLoggerProvider(Func<string, LogLevel, bool> filter, IConfiguration configuration)
        {
            _filter = filter;
            config = configuration;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new DatabaseLogger(categoryName, _filter, config);
        }

        public void Dispose()
        {
            
        }
    }

    public static class LoggerFactoryExtensions
    {
        public static ILoggerFactory AddDatabase(this ILoggerFactory factory, IConfiguration configuration, Func<string, LogLevel, bool> filter)
        {
            factory.AddProvider(new DatabaseLoggerProvider(filter, configuration));
            return factory;
        }

        public static ILoggerFactory AddDatabase(this ILoggerFactory factory, IConfiguration configuration, LogLevel minLevel)
        {
            return AddDatabase(
                factory,
                configuration,
                (_, logLevel) => logLevel >= minLevel);
        }
    }
}
