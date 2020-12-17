using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_10
{
    public class Student
    {
        public string name;
        public string lastName;
        public int math;
        public int prog;
        public int ks;
        public int average;
        public int Average
        {
            get
            {
                return math + prog + ks;
            }
        }
        public override string ToString()
        {
            return $"{name} {lastName}";
        }
        public Student(string name, string lastName,int math,int prog,int ks)
        {
            this.name = name;
            this.lastName = lastName;
            this.math = math;
            this.prog = prog;
            this.ks = ks;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            //var result = from item in months
            //             where item.Length <= 5
            //             select item;
            Console.WriteLine("1.1");
            var result = months.Where(item => item.Length <= 5);
            foreach(var item in result)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine("1.2");
            string[] months2 = { "December", "January", "February", "June", "July", "August" };
            var result2 = months.Intersect(months2);
            foreach (var item in result2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine("1.3");
            var result3 = months.OrderBy(item => item);
            foreach (var item in result3)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine("1.4");
            var result4 = months.Where(item => item.Length >= 4 && item.Contains("u"));
            foreach (var item in result4)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("2.0");
            List<Student> students = new List<Student>();
            Student st = new Student("ngklmah", "anewgfm", 10, 9, 10);
            Student st2 = new Student("dfsfyagh", "fghwef", 5, 3, 4);
            Student st3 = new Student("yojhtj", "jhgf", 6, 3, 7);
            Student st4 = new Student("gafuihi", "sgfkj", 8, 10, 5);
            Student st5 = new Student("kjasdfhv", "jhwagawfg", 10, 3, 8);
            Student st6 = new Student("rtyasdui", "yuwefew", 5, 9, 8);
            students.Add(st);
            students.Add(st2);
            students.Add(st3);
            students.Add(st4);
            students.Add(st5);
            students.Add(st6);
            foreach (var item in students)
            {
                Console.Write(item.ToString() + "; ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("3.1");
            //список студентов, имеющих неудовлетворительные оценки
            var result5 = students.Where(item => item.math < 4 || item.prog < 4 || item.ks < 4);
            foreach (var item in result5)
            {
                Console.Write(item.ToString() + "; ");
            }
            Console.WriteLine();

            Console.WriteLine("3.2");
            //список студентов, у которых сумма баллов выше заданной
            var result6 = students.Where(item => (item.math + item.prog + item.ks)>=16);
            foreach (var item in result6)
            {
                Console.Write(item.ToString() + "; ");
            }
            Console.WriteLine();

            Console.WriteLine("3.3");
            //количество студентов с 10-ками
            var result7 = students.Count(item => item.math >= 10 || item.prog >= 10 || item.ks >= 10);
            Console.WriteLine(result7);

            Console.WriteLine("3.4");
            //список студентов, упорядоченных по алфавиту
            var result8 = students.OrderBy(item => item.lastName);
            foreach (var item in result8)
            {
                Console.Write(item.ToString() + "; ");
            }
            Console.WriteLine();

            Console.WriteLine("3.5");
            //4 первых студента с самой высокой успеваемостью 
            var result9 = students.OrderBy(item => item.Average).Take(4);
            foreach (var item in result9)
            {
                Console.Write(item.ToString() + "; ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("4.0");
            var result10 = students.Where(item => item.math > 6).OrderBy(item => item.name).Reverse().Take(2).Select(item => item);
            foreach (var item in result10)
            {
                Console.Write(item.ToString() + "; ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("5.0");
            List<Stud> stud = new List<Stud>()
            {
                 new Stud {Name="Yana", Lastname="Belstu"},
                 new Stud {Name="Lera", Lastname="MGLU"},
                 new Stud {Name="Vika", Lastname="Belstu"}
            };
            List<Edu> edu = new List<Edu>()
            {
                 new Edu { Name = "Belstu", Firstname ="Minsk" },
                 new Edu { Name = "MGLU", Firstname ="Orsha" }
            };
           

            var result11 = stud.Join(edu, 
                  p => p.Lastname, // свойство-селектор объекта из первого набора
                  t => t.Name, // свойство-селектор объекта из второго набора
                  (p, t) => new { Name = p.Name, Lastname = p.Lastname, Firstname = t.Firstname }); // результат

            foreach (var item in result11)
                Console.WriteLine($"{item.Name} - {item.Lastname} ({item.Firstname})");
        }
    }
    class Stud
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
    }
    class Edu
    {
        public string Name { get; set; }
        public string Firstname { get; set; }
    }
}
