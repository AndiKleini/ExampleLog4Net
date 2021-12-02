using Example.Log4Net.logging;

namespace Example.Log4Net
{
    class Program
    {
        // get the logger from a factory so that the concrete implementation is hidden behind some interface
        private static ILoggerWrapper logger = LoggerFactory.GetLogger();

        static void Main(string[] args)
        {
            // use different methods to write messages with desired degree of severity
            logger.Debug("This is a debug message.");
            logger.Fatal("This is a fatal message.");
            logger.Warn("This is a warning message.");
            logger.Error("This is an error message.");
        }
    }
}
