using System;
using System.Reflection;

namespace _Reflection
{
    public class Person
    {
        private string FullName { set; get; } = "";
        private int ID { set; get; }
        public Person(string fullName, int iD)
        {
            FullName = fullName;
            ID = iD;
        }
        private void PrintInfo(DateTime dateTime)
        {
            Console.WriteLine($"==============={dateTime.ToString()}====================");
            Console.WriteLine("Name = " + FullName);
            Console.WriteLine("ID   = " + ID);
        }
        private string InfoAsText()
        {
            return "Name = " + FullName + " ID   = " + ID + ".";
        }
    }
    class Program
    {
        private static string Parameters(ParameterInfo[] parameterInfos)
        {
            if (parameterInfos.Length == 0)
                return "()";
            string line = "(";
            foreach (ParameterInfo info in parameterInfos)
            {
                line += info.ParameterType + " " + info.Name + ")";
            }
            return line;
        }
        static void Main()
        {
            Type ClassType = typeof(Person);
            Console.WriteLine("Properties :");
            foreach (PropertyInfo property in ClassType.GetProperties((BindingFlags.NonPublic | BindingFlags.Instance)))
            {
                Console.WriteLine(property.Name + " " + property.PropertyType + " ");
            }
            Console.WriteLine("===================================");
            Console.WriteLine("Methods :");
            foreach (MethodInfo method in ClassType.GetMethods((BindingFlags.NonPublic | BindingFlags.Instance)))
            {
                Console.WriteLine(method.ReturnParameter + " " + method.Name + " " + Parameters(method.GetParameters()));
            }

            Console.WriteLine("===================================");
            Console.WriteLine("Create Object :");

            object? person = Activator.CreateInstance(ClassType, ["", 0]);
            ClassType.GetProperty("FullName", BindingFlags.NonPublic | BindingFlags.Instance)?.SetValue(person, "Mustapha Botte");
            ClassType.GetProperty("ID", BindingFlags.NonPublic | BindingFlags.Instance)?.SetValue(person, 500);

            Console.WriteLine("ID   = " + ClassType.GetProperty("ID", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(person));
            Console.WriteLine("Name = " + ClassType.GetProperty("FullName", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(person));

            Console.WriteLine("===================================");
            Console.WriteLine("Invode Methods :");

            MethodInfo[] methodInfos = ClassType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (MethodInfo methodInfo in methodInfos)
            {
                if (methodInfo.IsSpecialName)
                    continue;
                if (methodInfo.ReturnType == typeof(void))
                {
                    if (methodInfo.GetParameters().Length == 0)
                        methodInfo.Invoke(person, null);
                    else
                    {
                        List<object> parameters = new List<object>();
                        foreach (ParameterInfo parameterInfo in methodInfo.GetParameters())
                        {
                            parameters.Add(Activator.CreateInstance(parameterInfo.ParameterType));
                        }
                        methodInfo.Invoke(person, parameters.ToArray());
                    }
                }
                else
                {
                    Console.WriteLine("Invoked function output = " + methodInfo.Invoke(person, null));
                }
            }
        }
    }
}