using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_9
{
    class Program
    {
        public class Student
        {
            public string name;
            public string lastName;
            public Student(string name,string lastName)
            {
                this.name = name;
                this.lastName = lastName;
            }
            public void Info()
            {
                Console.Write(name + " " + lastName + "; ");
            }
        }

        static void Main(string[] args)
        {

            Console.WriteLine("\t Task 1");

            Random random = new Random();
            //необобщенная коллекция
            ArrayList arrayList = new ArrayList();
            int value0 = random.Next(10);
            int value1 = random.Next(10);
            int value2 = random.Next(10);
            int value3 = random.Next(10);
            int value4 = random.Next(10);
            string str = "string";
            Student student = new Student("Yana", "Havrukova");
            arrayList.Add(value0);
            arrayList.Add(value1);
            arrayList.Add(value2);
            arrayList.Add(value3);
            arrayList.Add(value4);
            arrayList.Add(str);
            arrayList.Add(student);
            Console.WriteLine("Length arrayList: " + arrayList.Count);
            arrayList.Remove(value0);
            foreach(object item in arrayList)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
            Console.WriteLine("Length arrayList: " + arrayList.Count);
            bool search=arrayList.Contains(7);
            Console.WriteLine(search);
            search = arrayList.Contains(5);
            Console.WriteLine(search);

            Console.WriteLine("\t Task 2");
            //обобщенная коллекция List
            List<double> list = new List<double>();
            list.Add(1.2);
            list.Add(2.3);
            list.Add(3.4);
            list.Add(4.5);
            list.Add(5.6);
            Console.Write("List: ");
            foreach (double item in list)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
            for (int i = 2; i < list.Count; i++) 
            {
                list.RemoveAt(i);
            }
            Console.Write("List: ");
            foreach (double item in list)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
            list.Add(7.8);
            list.Add(8.9);
            Console.Write("List: ");
            foreach (double item in list)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
            //обобщенная коллекция Stack
            Stack<double> stack = new Stack<double>();
            //заполнение данными из первой коллекции
            for (int i = 0; i < list.Count; i++)
            {
                stack.Push(list[i]);
            }
            Console.Write("Stack: ");
            foreach (double item in stack)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
            search = stack.Contains(1.2);
            Console.WriteLine(search);
            search = stack.Contains(9.2);
            Console.WriteLine(search);

            Console.WriteLine("\t Task 3");
            //обобщенная коллекция List для класса Student
            List<Student> listStudent = new List<Student>();

            Student student1 = new Student("qwe", "asd");
            Student student2 = new Student("rty", "fgh");
            Student student3 = new Student("uio", "jkl");
            listStudent.Add(student1);
            listStudent.Add(student2);
            listStudent.Add(student3);
            Console.Write("listStudent: ");
            foreach (Student item in listStudent)
            {
                item.Info();
            }
            Console.WriteLine();
            for (int i = 1; i < listStudent.Count; i++)
            {
                listStudent.RemoveAt(i);
            }
            Console.Write("listStudent: ");
            foreach (Student item in listStudent)
            {
                item.Info();
            }
            Console.WriteLine();
            Student student4 = new Student("zxc", "mko");
            Student student5 = new Student("vbn", "hsf");
            listStudent.Add(student4);
            listStudent.Add(student5);
            //заполнение данными из первой коллекции
            Stack<Student> stack2 = new Stack<Student>();
            for (int i = 0; i < listStudent.Count; i++)
            {
                stack2.Push(listStudent[i]);
            }
            Console.Write("Stack: ");
            foreach (Student item in stack2)
            {
                item.Info();
            }
            Console.WriteLine();
            search = stack2.Contains(student1);
            Console.WriteLine(search);

            Console.WriteLine("\t Task 4");
            //реализация наблюдаемой коллекции
            ObservableCollection<Student> collection = new ObservableCollection<Student>();
            collection.CollectionChanged += Change;
            collection.Add(student1);
            collection.Add(student2);
            collection.Remove(student1);

        }
        public static void Change(object obj, NotifyCollectionChangedEventArgs e)
        {
            switch(e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine($"Object triggered an event when it was added");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine($"Object triggered an event when it was deleted");
                    break;
                default:
                    break;
            }
        }
    }
}
