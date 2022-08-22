namespace servisi.trading.Repos;
public class LoggerServis:ILogger
{
    public LoggerServis()
    {

    }

    public IDisposable BeginScope<TState>(TState state)
    {
        throw new NotImplementedException();
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        throw new NotImplementedException();
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        Console.WriteLine(logLevel);
        Console.WriteLine(eventId);
        Console.WriteLine(state);
        Console.WriteLine(exception);
        Console.WriteLine(formatter);
    }


    public void LogInformation(string information)
    {
        Console.WriteLine(information);
    }
}

