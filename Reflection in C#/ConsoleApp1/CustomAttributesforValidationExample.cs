using System;
using System.Reflection;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace _Reflection
{
    class ValidationAttribute:Attribute
    {
        public string Message = "";
        public int Min = 0;
        public int Max = 0;
 
        public ValidationAttribute(string message, int min, int max)
        {
            Message = message;
            Min = min;
            Max = max;
        }
    }
    abstract class ClsPerson
    {

        public string FullName { set; get; } = "";
        public string Phone { set; get; } = "";
        public string Email { set; get; } = "";

        [ValidationAttribute("Age must be greater than 18 years and less than 50", 18, 50)]
        public int Age { set; get; }
        public ClsPerson(string fullName, string phone, string email,int age)
        {       
            this.FullName = fullName;
            this.Phone = phone;
            this.Email = email;          
            this.Age = age;
        }   
    }
    class Employee : ClsPerson
    {
        public int ID { set; get; }

        [ValidationAttribute("Salary must be a positive number and less than 10000$",3000,10000)]
        public int Salary { set; get; }

        [ValidationAttribute("Experience must be greater than 5 years and less than 20", 5, 20)]
        public int Experience { set; get; }

        public Employee(int ID, string fullName, int age, string phone, string email, int salary, int experience)
            : base(fullName, phone, email, age)
        {
            this.ID = ID;
            this.FullName = fullName;
            this.Phone = phone;
            this.Email = email;
            this.Salary = salary;
            this.Experience = experience;
            this.Age = age;
        }
       
    }
    class Program3
    {
        private static void Validation(Employee emp)
        {
            Type type = typeof(Employee);
            PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Instance|BindingFlags.Public);
            foreach(PropertyInfo propertyInfo in propertyInfos)
            {
                if (!propertyInfo.IsDefined(typeof(ValidationAttribute)))
                {
                    continue;
                }
                ValidationAttribute ? attribute =  propertyInfo.GetCustomAttribute<ValidationAttribute>();
                object? value = propertyInfo.GetValue(emp);
                if ((int)value < attribute?.Min || (int)value > attribute?.Max)
                {
                    Console.WriteLine(propertyInfo.Name +" "+attribute.Message);
                }
            }
        }
        static void Main()
        {
            Employee emp = new Employee(1,"Mustapha Mustapha",  120,  "0704545454",  "ExMail.com", 12000,2);
            Validation(emp);

        }
    }
}