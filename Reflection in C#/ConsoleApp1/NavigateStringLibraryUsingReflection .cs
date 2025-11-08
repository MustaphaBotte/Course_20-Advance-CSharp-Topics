using System;
using System.Reflection;
namespace _Reflection
{ 
    class ClsStringLibrary
    {       
        static string Parameterstring(ParameterInfo[] parameterInfos)
        {
            string line = "";
            foreach(ParameterInfo parameterInfo in parameterInfos)
            {
                line += parameterInfo.Name + " ";
            }
            return line;
        }
        static void Main3()//change the name to Main if you want run this file as an entry
        {
            Assembly assembly = typeof(DLMS.EntitiesNamespace.Entities).Assembly;
            Console.WriteLine("Assembly = "+assembly.FullName + " :\n");
            foreach (Type assemblyType in assembly.GetTypes())
            {                
                    Console.WriteLine(assemblyType.FullName + " :\n");
                    foreach (System.Reflection.FieldInfo f in assemblyType.GetFields())
                    {
                        Console.WriteLine(f.Name);
                    }
                    Console.WriteLine("================================================");           
            }


            Type type = typeof(BCrypt.Net.BCrypt);

            foreach (MethodInfo Method in type.GetMethods(bindingAttr: (BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance |BindingFlags.Static)))       
            {
                Console.WriteLine(Method.ReturnType+" "+Method.Name + " " + ClsStringLibrary.Parameterstring(Method.GetParameters()));
            }
            Console.WriteLine("================================================");
          
            Console.WriteLine();            
        }
    }
}