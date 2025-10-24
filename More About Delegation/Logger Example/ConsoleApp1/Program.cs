using System.IO;
class Logger
{
    public delegate void LogAction(string Message);

    private readonly LogAction logAction= delegate { };
    public Logger(LogAction logAction)
    {
        this.logAction = logAction;

    }
    public void LogMessage(string Message)
    {
        //you can use this method
        foreach (LogAction Handler in logAction.GetInvocationList())
        {
            try
            {
                Handler(Message);
            }
            catch
            {
                Console.WriteLine($"Error Occured in {Handler.Method.Name}");
            }
        }
        //  logAction?.Invoke(Message);
    }
}
class DataBaseLogger
{
    string _ConnString = "";
    public DataBaseLogger()
    {
        _ConnString = "connection string"; //Just a simulation OK
    }
    public void LogToDatabase(string Message)
    {
        Console.WriteLine("=============================================================");
        Console.WriteLine("Message Logged SuccessFully To Database");
        Console.WriteLine("=============================================================");
        //Just Simulation ---- for the idea only
    }
}
class FileLogger
{
    private string _LogFilePath;
    public FileLogger(string LogFilePath)
    {
        if(string.IsNullOrEmpty(LogFilePath))
        {
            throw new Exception("File Path Cannot be empty");
        }
        this._LogFilePath = LogFilePath;
    }
    public void LogToFile(string Message)
    {
        string Result = "Message Logged SuccessFully To Text File";
 
        try
        {
            if (!File.Exists(_LogFilePath))
                File.Create(_LogFilePath).Close();
            File.AppendAllText(_LogFilePath, Message);

        }
        catch
        {
            Result = "Error While Logging The Message";
        }
        Console.WriteLine("=============================================================");
        Console.WriteLine($"{Result}");
        Console.WriteLine("=============================================================");
    }
}
class ScreenLogger
{
    public void LogToscreen(string Message)
    {
        Console.WriteLine("=============================================================");
        Console.WriteLine($"Error Message IS {Message}");
        Console.WriteLine("=============================================================");
    }
}

// you can add much more loggers witout modifying the base logger 
class Program
{
    static void Main()
    {
        string Message = "you dont have the permissions to delete this user";

        Logger dataBaseLogger = new Logger(new DataBaseLogger().LogToDatabase);
        Logger fileLogger = new Logger(new FileLogger("Log.txt").LogToFile);
        Logger screenLogger = new Logger(new ScreenLogger().LogToscreen);

        fileLogger.LogMessage(Message);
        screenLogger.LogMessage(Message);
        dataBaseLogger.LogMessage(Message);

    }
}