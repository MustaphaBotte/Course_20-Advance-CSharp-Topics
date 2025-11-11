using System;
using System.Numerics;
using System.Runtime.InteropServices;
using static Program;

#region utility class
public class Utility
{
    public static void Swap<T>(ref T first, ref T second)
    {
        T temp = first;
        first = second;
        second = temp;
    }
    public static T Sum<T>( T first,  T second)where T :INumber<T>
    {
        return first + second;
    }
}
#endregion

class ValueBox<T,T2>
{
    public readonly T2 Value2;

    public readonly T Value ;

    public ValueBox(T value,T2 value2)
    {
        this.Value = value;
        this.Value2 = value2;
    }
    public override string? ToString()
    {
        return Value?.ToString()??"";
    }
    
}
class Program
{
    public class notificationProcessor<Service, Notification> where Service : InotificationService<Notification>
    {
        public static bool Send(Service service, Notification notification)
        {
            // now here i can log /check/validate/save to database
            // if (notification == null) throw new ArgumentNullException();
            // log to db with single try catch
            // witout this is need to duplicate that code in every service
            return service.SendNotification(notification);
        }
    }
    public interface InotificationService<T>
    {
        bool SendNotification(T type);
    }
    static void Main()
    {
        #region Template With Functions
        int a = 10;
        int b = 20;
        string x = "x";
        string y = "y";

        Utility.Swap(ref a, ref b);
        Utility.Swap(ref x, ref y);

        Console.WriteLine(a);
        Console.WriteLine(b);

        Console.WriteLine(x);
        Console.WriteLine(y);

        Console.WriteLine(Utility.Sum(10.00, 20.45));
        #endregion 

        #region Template with class
        ValueBox<bool, int> valueBox = new ValueBox<bool, int>(true, 10);
        Console.WriteLine(valueBox);
        Console.WriteLine(valueBox.ToString());
        Console.WriteLine(valueBox.GetType());
        Console.WriteLine(valueBox);
        #endregion

        var email = new EmailNotification("email@gmal.com", "you have new order", "new order is on the way maybe aftre 2 hours");
        var service = new EmailNotificationService();
        service.SendNotification(email);
        notificationProcessor<EmailNotificationService,EmailNotification>.Send(service, email);
    }
   

    public class EmailNotificationService : InotificationService<EmailNotification>
    {
        public bool SendNotification(EmailNotification emailNotification)
        {         
            Console.WriteLine($"Hi {emailNotification.To} you have a notification about {emailNotification.Subject} body :{emailNotification.Body}");
            return true;
        }
    }
    public class SmsNotificationService : InotificationService<SmsNotification>
    {
        public bool SendNotification(SmsNotification smsNotification)
        {
            Console.WriteLine($" {smsNotification.PhoneNumber} notification : {smsNotification.Message}");
            return true;
        }
    }
    public class PushNotificationService : InotificationService<PushNotification>
    {

        public bool SendNotification(PushNotification pushNotification)
        {
            Console.WriteLine($"Hi you have a notification about {pushNotification.Title} body :{pushNotification.Message}");
            return true;
        }
    }

    public class EmailNotification
    {
        public EmailNotification(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }

        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
    public class SmsNotification
    {
        public SmsNotification(string phoneNumber, string message)
        {
            PhoneNumber = phoneNumber;
            Message = message;
        }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
    public class PushNotification
    {
        public PushNotification(string deviceToken, string title, string message)
        {
            DeviceToken = deviceToken;
            Title = title;
            Message = message;
        }
        public string DeviceToken { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }


    //now you can extend as much as you want generics give us scalability
}