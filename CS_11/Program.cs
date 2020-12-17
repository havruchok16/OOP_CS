using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace CS_11
{
    public class Date : III
    {
        public int day;
        public int month;
        public int year;
        public Date(int d, int m, int y)
        {
            this.day = d;
            this.month = m;
            this.year = y;
        }
        public void ShowInfo()
        {
            Console.WriteLine("Date: " + day + "." + month + "." + year);
        }
        public override string ToString()
        {
            return $"{day} {month} {year}";
        }
        public void MonthWinter(int month)
        {
            if (month == 1 && month == 2 && month == 12)
            {
                Console.WriteLine("This month is winter");
            }
            else
            {
                Console.WriteLine("This month is not winter");
            }
        }
        public int Sum(int a, int b) { return a + b; }
    }
    interface III
    {
        void ShowInfo();
    }
    public class Corporation : III
    {
        public string name;
        public string town;
        public int staff;
        public Corporation(string n, string t, int s)
        {
            this.name = n;
            this.town = t;
            this.staff = s;
        }
        public void ShowInfo()
        {
            Console.WriteLine("Corporation: " + name + ", Town: " + town + ", Staff: " + staff);
        }
        public override string ToString()
        {
            return $"{name} {town} {staff}";
        }

    }

    public class Reflector
    {
        public const string File = @"C:\Users\37544\Desktop\C#\CS_labs\CS_11\CS_11\Info.txt";
        public static void ReflectorA(string className)
        {
            Type type = Type.GetType(className, false, true);
            if (type == null)
            {
                Console.WriteLine("Error");
                return;
            }
            using (StreamWriter writer = new StreamWriter(File, false, System.Text.Encoding.Default))
            {
                writer.WriteLine("Namespace.ClassName: " + className);
                writer.Write("Fields: ");
                foreach (var filds in type.GetFields())
                {
                    writer.Write(filds.Name + "; ");
                }
                writer.WriteLine();
                writer.Write("Properties: ");
                foreach (var properties in type.GetProperties())
                {
                    writer.Write(properties.Name + "; ");
                }
                writer.WriteLine();
                writer.Write("Methods: ");
                foreach (var methods in type.GetMethods())
                {
                    writer.Write(methods.Name + "; ");
                }
                writer.WriteLine();
                writer.Write("Interfaces: ");
                foreach (var interfaces in type.GetInterfaces())
                {
                    writer.Write(interfaces.Name + "; ");
                }
            }
        }
        public static MethodInfo[] ReflectorB(string className)
        {
            Type type = Type.GetType(className, false, true);
            if (type == null)
            {
                Console.WriteLine("Error");
                return null;
            }
            return type.GetMethods();
        }
        public static List<MemberInfo[]> ReflectorC(string className)
        {
            Type type = Type.GetType(className, false, true);
            if (type == null)
            {
                Console.WriteLine("Error");
                return null;
            }
            var properties = type.GetProperties();
            var fields = type.GetFields();
            List<MemberInfo[]> members = new List<MemberInfo[]> { properties, fields };
            return members;
        }
        public static Type[] ReflectorD(string className)
        {
            Type type = Type.GetType(className, false, true);
            if (type == null)
            {
                Console.WriteLine("Error");
                return null;
            }
            return type.GetInterfaces();
        }
        public static void ReflectorE(string className, Type parameterType)
        {
            Type type = Type.GetType(className, false, true);
            if (type == null)
            {
                Console.WriteLine("Error");
                return;
            }
            var methods = type.GetMethods();
            var result = methods.Where(item => item.GetParameters().Where(item2 => item2.ParameterType == parameterType).Count() > 0);
            Console.Write($"Methods with parameters {parameterType.Name}: ");
            foreach (var method in result)
            {
                Console.Write(method.Name + "; ");
            }
        }
        static public void ReflectorF(string className, string methodName)
        {
            Type classType = Type.GetType(className, false, true);
            object obj = Activator.CreateInstance(classType);
            MethodInfo methodInfo = classType.GetMethod(methodName);
            StreamReader reader = new StreamReader(@"C\Users\37544\Desktop\C#\CS_labs\CS_11\CS_11\Invoke.txt");

            object result = methodInfo.Invoke(obj, new object[] { Convert.ToInt32(reader.ReadLine()), Convert.ToInt32(reader.ReadLine()) });
            Console.WriteLine($"Invoke: {result}");
        }
        static public object Create(Type t)
        {
            object obj = Activator.CreateInstance(t);
            return obj;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Reflector reflector = new Reflector();
            Reflector.ReflectorA("CS_11.Date");
            Reflector.ReflectorB("CS_11.Corporation");
            Console.Write("Methods of class Corporation: ");
            foreach (var methods in Reflector.ReflectorB("CS_11.Corporation"))
            {
                Console.Write(methods.Name + "; ");
            }
            Console.WriteLine();

            Console.Write("Fields and properties of class Date: ");
            foreach (var info in Reflector.ReflectorC("CS_11.Date"))
            {
                foreach (var info2 in info)
                {
                    Console.Write(info2.Name + "; ");
                }
            }
            Console.WriteLine();

            Console.Write("Interfaces of class Corporation: ");
            foreach (var interfaces in Reflector.ReflectorD("CS_11.Corporation"))
            {
                Console.Write(interfaces.Name + "; ");
            }
            Console.WriteLine();

            Reflector.ReflectorE("CS_11.Date", typeof(int));
            Console.WriteLine();

            try
            {
                Reflector.ReflectorF("CS_11.Date", "Sum");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
