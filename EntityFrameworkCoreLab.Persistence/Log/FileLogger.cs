using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace EntityFrameworkCoreLab.Persistence.Log
{
    public class FileLogger : ILogger
    {
        public StreamWriter Writer { get; }

        public string Name { get; set; }

        public FileLogger(StreamWriter writer)
        {
            Writer = writer;
            Name = nameof(FileLogger);
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            if (formatter == null)
                throw new ArgumentNullException(nameof(formatter));

            string message = formatter(state, exception);
            if (string.IsNullOrEmpty(message) && exception == null)
                return;

            string line = $"{logLevel}: {Name}: {message}";

            Writer.WriteLine(line);

            if (exception != null)
                Writer.WriteLine(exception.ToString());
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return new FileScope();
        }
    }
}
