using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_8
{
    public delegate void UserDel(Software obj);//создание делегата
    public class User
    {
        //создание событий
        public event UserDel upgrade;
        public event UserDel work;
        public void DoUpgrade(Software obj) => upgrade?.Invoke(obj);
        public void DoWork(Software obj) => work?.Invoke(obj);

    }
    public class Software
    {
        public int version;
        public int year;

        public UserDel doUpgrade;
        public UserDel doWork;

        public override string ToString()
        {
            return $"{version} , {year}";
        }

    }

    class Program
    {

        public static Random random;
        //метод измнения цвета текста
        public static void TextColor(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
 
        public static string DeleteOtherChars(string str)
        {
            string stttr = ",.:!";
            for (var i = 0; i < str.Length;)
            {
                if (stttr.Contains(str[i]))
                {
                    str = str.Remove(i, 1);
                }
                else i++;
            }
            return str;
        }

        public static string DeleteMoreSpaces(string str)
        {
            for (int i = 0; i < str.Length - 1;)
            {
                if (str[i] == ' ' && str[i + 1] == ' ')
                {
                    str = str.Remove(i, 1);
                }
                else i++;
            }
            return str;
        }
        public static string ReplaceChars(string str)
        {
            for (int i = 0; i < str.Length;)
            {
                if (str[i] == ' ')
                {
                    str=str.Replace(" ","[space]");
                }
                else i++;
            }
            return str;
        }
        public static string ToUpper(string str)
        {
            for (int i = 0; i < str.Length;i++)
            { 
                    str = str.ToUpper();
            }
            return str;
        }
        public static string ToLower(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                str = str.ToLower();
            }
            return str;
        }

        static void Main(string[] args)
        {
            random = new Random(DateTime.Now.Second);
            User user = new User();

            Software software = new Software()
            {
                version = random.Next(1, 20),
                year = random.Next(2000, 2020),
                //присвоение делегату анонимного метода
                doUpgrade = (obj) =>
                {
                    var version = obj.version;
                    obj.version++;
                    TextColor(ConsoleColor.Blue, $"1 Version updated: {obj.version}");
                },
                doWork=(obj)=>
                {
                    var year = obj.year;
                    TextColor(ConsoleColor.Blue, $"1 Year of version: {year}");
                }
            };
            void ShowInfo(Software obj)
            {
                Console.WriteLine(obj.ToString());
            }
            
            software.doUpgrade += ShowInfo;
            user.upgrade += software.doUpgrade;
            user.DoUpgrade(software);
            user.work += software.doWork;
            user.DoWork(software);



            //последовательная обработка, используя Func
            Func<string, string> str = (s) => s;
            string str2 = str("...i am  ,,,, v!ery : happ...y!");
            Console.WriteLine(str2);
            str = DeleteOtherChars;//удаление лишних элементов
            str2 = str(str2);
            Console.WriteLine(str2);
            str = DeleteMoreSpaces;//удаление долгих пробелов
            str2 = str(str2);
            Console.WriteLine(str2);
            str = ReplaceChars;//замена элемента
            str2 = str(str2);
            Console.WriteLine(str2);
            str = ToUpper;//перевод регистра
            str2 = str(str2);
            Console.WriteLine(str2);
            str = ToLower;//перевод регистра
            str2 = str(str2);
            Console.WriteLine(str2);
            Console.WriteLine("END!");




        }
    }
}
