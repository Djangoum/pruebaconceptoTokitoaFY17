using Dapper;
using Entities.IssuesManager;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Loggers
{
    public class DatabaseLogger : ILogger, IDisposable
    {
        private string _categoryName;
        private Func<string, LogLevel, bool> _filter;
        private readonly IConfiguration config;

        public DatabaseLogger(string categoryName, Func<string, LogLevel, bool> filter, IConfiguration configuration)
        {
            config = configuration;
            _categoryName = categoryName;
            _filter = filter;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return this;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return (_filter == null || _filter(_categoryName, logLevel));
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Log log = new Log();

            log.Message = formatter(state, exception);
            log.LogLevel = logLevel.ToString();
            log.CreatedTime = DateTime.Now;

            if (string.IsNullOrEmpty(log.Message))
            {
                return;
            }

            if (exception != null)
            {
                log.Message += Environment.NewLine + Environment.NewLine + exception.ToString();
            }

            InsertLog(log);
        }

        private void InsertLog(Log log)
        {
            using (var sqlConnection = new SqlConnection(config.GetConnectionString("DefaultConnection")))
            {
                sqlConnection.Open();

                sqlConnection.Execute(
                @"
                    insert Logs (LogLevel, Message, CreatedTime) values (@LogLevel, @Message, @CreatedTime);
                ", log);
                
                sqlConnection.Close();
            }
        }

        public void Dispose()
        {
            
        }
    }
}
