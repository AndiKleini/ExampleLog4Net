using Example.Log4Net.logging;
using System;
using System.IO;

namespace Example.Log4Net
{
    class Program
    {
        private static ILoggerWrapper logger = LoggerFactory.GetLogger();

        static void Main(string[] args)
        {
            logger.Debug("This is a debug message.");
            logger.Fatal("This is a fatal message.");
            logger.Warn("This is a warning message.");
            logger.Error("This is an error message.");
        }
    }
}
