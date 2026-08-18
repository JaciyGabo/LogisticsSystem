namespace Logistics.Infrastructure.Logging;

public sealed class FileLogger
{
    private static readonly Lazy<FileLogger> _instance = new(() => new FileLogger());   
    private readonly string _filePath;
    private static readonly object _lock = new object();

    private FileLogger()
    {
        _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logistics_system_logs.txt");
    }

    public static FileLogger Instance => _instance.Value;

    public void Log(string message, string level = "INFO", Exception? ex = null)
    {
        lock (_lock)
        using StreamWriter writer = new StreamWriter(_filePath, true);
            writer.WriteLine($"[{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}] {level}: {message}");
            
            if (ex != null)
            {
                writer.WriteLine($"[STACKTRACE]: {ex.StackTrace}");
            }
    }
}