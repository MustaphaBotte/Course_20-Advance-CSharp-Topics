using System.Diagnostics;
namespace ConsoleApp1
{
    internal class Program
    {
        // Event log example
        // run this in your cmd : dotnet add package System.Diagnostics.EventLog
        // run this in your nuget packages manager :Install-Package System.Threading.AccessControl


        static void Main(string[] args)
        {
            string AppName = "DLMS";
            if (!EventLog.SourceExists(AppName))
                EventLog.CreateEventSource(AppName,"Application");


            EventLog.WriteEntry(AppName, "Error occured", EventLogEntryType.Error,eventID:100);
            //EventLog.DeleteEventSource(AppName); delete DLMS from eventlog db
            Console.Read();
        }
    }
}


//In computing, an event log is a file or database used to store events that occur in a system. 
//    These events can include information about errors, warnings, system events, user activities,
//    and more. Event logs are commonly used for troubleshooting, monitoring, and auditing purposes.