using System;
using Microsoft.Extensions.Logging;

namespace OnlineBookingAggregatorApp.Persistence.Helpers
{
    public class LoggerProvider : ILoggerProvider
    {
        public void Dispose()
        {
        }

        public ILogger CreateLogger(string categoryName) => new SqlQueriesLogger();

        private class SqlQueriesLogger : ILogger {
            public IDisposable BeginScope<TState>(TState state) {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel) {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, 
                Exception exception, Func<TState, Exception, string> formatter)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(formatter(state, exception));
                Console.ForegroundColor = color;
            }
        }
    }
}