using Microsoft.Extensions.Logging;
using System.IO;

namespace EntityFrameworkCoreLab.Persistence.Log
{
    public class FileLoggerProvider : ILoggerProvider
    {
        public StreamWriter Writer { get; private set; }

        public FileLoggerProvider(StreamWriter writer)
        {
            Writer = writer;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(Writer);
        }

        public void Dispose()
        {
        }
    }
}
