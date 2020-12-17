using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_5
{
    class Library
    {
        LIBRARY[] elem;

        public int Length
        { get { return elem.Length; } }

        public LIBRARY this[int i]
        {
            get
            {
                return elem[i];
            }
            set
            {
                elem[i] = value;
            }
        }
        public LIBRARY[] Elem
        {
            get { return elem; }
        }
        public Library(LIBRARY[] elems)
        {
            elem = elems;
        }

        public void Add(LIBRARY elems)//добавление объектов
        {
            LIBRARY[] buff = new LIBRARY[elem.Length + 1];
            for (int i = 0; i < elem.Length; i++)
            {
                buff[i] = elem[i];
            }
            buff[buff.Length - 1] = elems;
            elem = new LIBRARY[buff.Length];
            for (int i = 0; i < elem.Length; i++)
            {
                elem[i] = buff[i];
            }
        }

        public void Delete(int ind)//удаление объектов
        {
            LIBRARY[] buff = new LIBRARY[elem.Length - 1];
            for (int i = 0, y = 0; i < elem.Length; i++, y++)
            {
                if (ind < 0) 
                {
                    throw new DelExceptions("Удаление несуществующего элемента");
                }
                if (i == ind)
                {
                    if (i == elem.Length - 1)
                    {
                        break;
                    }
                    buff[y] = elem[i + 1];
                    i++;
                }
                else
                {
                    buff[y] = elem[i];
                }
            }
            elem = buff;
        }

        public void Print()//вывод элементов
        {
            for (int i = 0; i < elem.Length; i++)
            {
                Console.WriteLine(elem[i]);
            }
        }
    }
    public abstract class LIBRARY
    {
        private string name;
        private string author;
        private int year;

        public LIBRARY()
        {
            this.name = "Name";
            this.author = "Author";
            this.year = 0;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public int Year
        {
            get { return year; }
            set
            {
                if (value > 0 && value <= 2020)
                {
                    year = value;
                }
                else
                {
                    throw new YearExceptions("Год должен быть больше 0");
                }
            }
        }
        public virtual void Info()
        {
            Console.WriteLine("Name: " + Name + "\tAuthor: " + Author + "\tYear: " + Year);
        }
    }

    class Controller
    {
        public void FindBook(LIBRARY[] array)
        {
            Console.WriteLine("Book in Library");
            foreach (var i in array)
            {
                if (i.GetType() == typeof(Book))
                {
                    Book book = (Book)i;
                    Console.WriteLine(book.Name);
                }
            }
        }

        public void Counter(LIBRARY[] array)
        {
            int count = 0;
            Console.Write("in Library ");
            foreach (var i in array)
            {
                if (i.GetType() == typeof(Journal))
                {
                    count++;
                }
            }
            Console.Write(count);
            Console.WriteLine(" journal(s)");
        }

        public void Сost(LIBRARY[] array)
        {
            int cost = 0;
            Console.Write("Cost: ");
            foreach (var i in array)
            {
                if (i.GetType() == typeof(Book))
                {
                    Book book = (Book)i;
                    cost += (int)book.Cost;
                }
                if (i.GetType() == typeof(Journal))
                {
                    Journal jou = (Journal)i;
                    cost += (int)jou.Cost;
                }
                if (i.GetType() == typeof(Tutorial))
                {
                    Tutorial tut = (Tutorial)i;
                    cost += (int)tut.Cost;
                }
            }
            Console.Write(cost);
            Console.WriteLine(" $");
        }
    }
    public class Book : LIBRARY
    {
        string colorOfBook;
        string titleOfBook;
        int cost;
        public Book()
        {
            this.colorOfBook = "white";
            this.titleOfBook = "BOOK";
            this.cost = 100;
        }
        public Book(string color, string title, int cost)
        {
            if (cost < 0)
            {
                throw new CostExceptions("Стоимость должна быть больше 0");
            }
            else
            {
                this.cost = cost;
            }
            this.colorOfBook = color;
            this.titleOfBook = title;
        }
        public string ColorOfBook
        {
            get { return colorOfBook; }
            set { colorOfBook = value; }
        }
        public string TitleOfBook
        {
            get { return titleOfBook; }
            set { titleOfBook = value; }
        }
        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        public override void Info()
        {
            Console.WriteLine("Name: " + Name + "\tAuthor: " + Author + "\tYear: " + Year + "\tCost:" + cost + "\tColor: " + ColorOfBook + "\tTitle: " + TitleOfBook);
        }


    }

    public class Journal : LIBRARY
    {
        string colorOfJou;
        string titleOfJou;
        int cost;
        public Journal()
        {
            this.colorOfJou = "white";
            this.titleOfJou = "BOOK";
            this.cost = 100;
        }
        public Journal(string col, string tit, int c)
        {
            this.colorOfJou = col;
            this.titleOfJou = tit;
            this.cost = c;
        }
        public string ColorOfJou
        {
            get { return colorOfJou; }
            set { colorOfJou = value; }
        }
        public string TitleOfJou
        {
            get { return titleOfJou; }
            set { titleOfJou = value; }
        }
        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        public override void Info()
        {
            Console.WriteLine("Name: " + Name + "\tAuthor: " + Author + "\tYear: " + Year + "\tCost:" + cost + "\tColor: " + colorOfJou + "\tTitle: " + TitleOfJou);
        }

    }

    partial class Tutorial : LIBRARY
    {
        string colorOfTut;
        string titleOfTut;
        int cost;
        public Tutorial()
        {
            this.colorOfTut = "white";
            this.titleOfTut = "BOOK";
            this.cost = 100;
        }
        public Tutorial(string color, string title, int cost)
        {
            if (cost < 0)
            {
                throw new CostExceptionsTUT("Стоимость должна быть больше 0 !!!");
            }
            else
            {
                this.cost = cost;
            }
            this.colorOfTut = color;
            this.titleOfTut = title;
        }
        public string ColorOfTut
        {
            get { return colorOfTut; }
            set { colorOfTut = value; }
        }
        public string TitleOfTut
        {
            get { return titleOfTut; }
            set { titleOfTut = value; }
        }
        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }
    }

    partial class Tutorial : LIBRARY
    {
        public override void Info()
        {
            Console.WriteLine("Name: " + Name + "\tAuthor: " + Author + "\tYear: " + Year + "\tCost:" + cost + "\tColor: " + colorOfTut + "\tTitle: " + TitleOfTut);
        }
    }

    enum Date
    {
        day = 5,
        month = 11,
        year = 2020
    }
    struct Corporation
    {
        public string name;
        public string corporation;
        public void Infooo()
        {
            Console.WriteLine("Name: " + name + "\t Corporation: " + corporation);
        }
    }

    class CostExceptions : ArgumentException
    {
        public CostExceptions(string message):base(message)
        {
        }
    }
    class YearExceptions : ArgumentException
    {
        public YearExceptions(string message) : base(message)
        {
        }
    }
    class CostExceptionsTUT : ArgumentException
    {
        public CostExceptionsTUT(string message) : base(message)
        {
        }
    }

    class DelExceptions : ArgumentException
    {
        public DelExceptions(string message) : base(message)
        {
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Date day;
            day = Date.day;
            Console.WriteLine("Day: " + (int)day);
            Date month;
            month = Date.month;
            Console.WriteLine("Month: " + (int)month);
            Date year;
            year = Date.year;
            Console.WriteLine("Year: " + (int)year);
            Console.WriteLine();

            Corporation company;
            company.name = "Yana";
            company.corporation = "Havruchok";
            company.Infooo();
            Console.WriteLine();

            Book book = new Book("black", "BOOOOOOK", 300);
            book.Name = "NNN";
            book.Author = "AAA";
            book.Year = 2020;
            book.Info();

            Book book2 = new Book("white", "BOOK", 500);
            book2.Name = "NN";
            book2.Year = 2019;
            book2.Info();

            Journal jou = new Journal("pink", "JOOU", 600);
            jou.Name = "Star";
            jou.Author = "Unknown";
            jou.Year = 2020;
            jou.Info();

            Tutorial tutotial = new Tutorial("yellow", "TUTS", 50);
            tutotial.Name = "Student";
            tutotial.Author = "Belstu";
            tutotial.Year = 1999;
            tutotial.Info();

            Tutorial tutotial2 = new Tutorial("gray", "OOPs", 70);
            tutotial2.Name = "Labs";
            tutotial2.Year = 1989;
            tutotial2.Info();

            Console.WriteLine();
            Console.WriteLine("Array");

            LIBRARY[] array = new LIBRARY[] { book, book2, jou, tutotial };
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }

            Console.WriteLine();
            Library elemFromLibrary = new Library(array);
            elemFromLibrary.Print();
            Console.WriteLine();
            elemFromLibrary.Add(tutotial2);
            elemFromLibrary.Print();
            Console.WriteLine();
            elemFromLibrary.Delete(1);
            elemFromLibrary.Print();
            Console.WriteLine();

            Controller library1 = new Controller();
            library1.FindBook(elemFromLibrary.Elem);
            library1.Counter(elemFromLibrary.Elem);
            library1.Сost(elemFromLibrary.Elem);
            Console.WriteLine();


            Console.WriteLine("LAB EXCEPTIONS");
            Console.WriteLine();

            try
            {
                Book bookEX = new Book("black", "BOOOOOOK", -300);
            }
            catch (CostExceptions ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                Journal jouEX = new Journal("pinks", "JOOUs", 666);
                jouEX.Name = "Stars";
                jouEX.Author = "Unknowns";
                jouEX.Year = -2020;
            }
            catch (YearExceptions ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                Tutorial tutotiaEX = new Tutorial("black", "sss", -70);
                tutotiaEX.Name = "TTTTT";
            }
            catch (CostExceptionsTUT ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }


            try {
                Library elemFromLibrary2 = new Library(array);
                elemFromLibrary2.Delete(-1);
            }
            catch (DelExceptions ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }
            try
            {
                int a = 10;
                int b = 0;
                int result = a / b;
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                object p = "pups";
                int pp = (int)p;
            }
            catch(InvalidCastException ex)
            {
                Console.WriteLine("Error: " + ex.Message);  
            }

            finally
            {
                Console.WriteLine("Finally!");
            }



        }
    }
}

