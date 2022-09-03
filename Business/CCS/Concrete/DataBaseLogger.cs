using Business.CCS.Abstract;

namespace Business.CCS.Concrete;

public class DataBaseLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine("Database logged");
    }
}