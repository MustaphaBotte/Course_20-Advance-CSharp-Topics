using System.Security.Cryptography.X509Certificates;

class EmailValidator
{
    public static  bool checkEmail(string Mail)
    {
        Console.WriteLine("Valid");
        return true;
    }

}
class program
{
    static void Main()
    {
       
        Func<string, bool> EmailEvent = delegate { return false; };
        EmailEvent += EmailValidator.checkEmail;
        EmailEvent("example");
        // to simplify this use Predicate delegate its just a predefined delegate that take 1 parameter  and return boolean

        Predicate<string> PredicateEmailEvent = EmailValidator.checkEmail;
        PredicateEmailEvent("example2");

        // Action , eventhandler , Predicate , func , are just predefined delegates
        // and the event cover them to make sure no one call them outside the class
        //delegates are the base
    }
}