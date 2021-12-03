# ExampleLog4Net

Contains an easy example for implementation and configuration of a vendor independent wapper for log4net logger. 

## decoupling from concrete logging library
Additionally it shows a way how the concrete logging librabry can be decoupled from the rest of the classes. Therefore a proper interface is introduced 
offering required logging methods (Debug, Warn, Info, Fatal). 

```c#
public interface ILoggerWrapper
{
    void Debug(string message);
    void Error(string message);
    void Fatal(string message);
    void Warn(string message);
}
```

The factory LoggerFactory creates a logger implementing ILoggerWrapper.

```c#
private static ILoggerWrapper logger = LoggerFactory.GetLogger();
```

The concrete ILoggerWrapper implementation Log4NetWrapper wraps around log4net Logger. It provides a static creator method that sets up a new instance properly.

```
public static Log4NetWrapper CreateLogger(string configPath)
{
     if (!File.Exists(configPath))
     {
         throw new ArgumentException("Does not exist.", nameof(configPath));
     }

     log4net.Config.XmlConfigurator.Configure(new FileInfo(configPath));
     var logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
     return new Log4NetWrapper(logger);
}
```

## configuration
The logger is configured by the configuration file log4net.config placed in the project root folder. Please be aware that the creation method of LoggerWrapper needs the 
relative path to the configuration file. It specifes the level to all and create a Rollingfile and Console Appender.

```xml
<log4net>
  <root>
    <level value="ALL" />
    <appender-ref ref="console" />
    <appender-ref ref="file" />
  </root>
  <appender name="console" type="log4net.Appender.ConsoleAppender">
    <layout type="log4net.Layout.PatternLayout">
      <conversionPattern value="%date %level %logger - %message%newline" />
    </layout>
  </appender>
  <appender name="file" type="log4net.Appender.RollingFileAppender">
    <file value="logfile.log" />
    <appendToFile value="true" />
    <rollingStyle value="Size" />
    <maxSizeRollBackups value="5" />
    <maximumFileSize value="10MB" />
    <staticLogFileName value="true" />
    <layout type="log4net.Layout.PatternLayout">
      <conversionPattern value="%date [%thread] %level %logger - %message%newline" />
    </layout>
  </appender>
</log4net>
```

For further configuration go through http://logging.apache.org/log4net/release/manual/configuration.html.
