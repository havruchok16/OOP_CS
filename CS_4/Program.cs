using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_5
{


    class Program
    {
        static void Main(string[] args)
        {
            Window window = new Window(1024, 720, true, "pink");
            Figure figure = new Figure("gray", true);
            Rect rect = new Rect(45);
            Menu menu = new Menu(5, 500, 500, "white","pink", "Button", "black");
            menu.Button.type();
            menu.Button.info();
            Console.WriteLine(menu.Button.ToString());
            window.Control.type();
            Console.WriteLine(window.Control.ToString());
            rect.type();
            Console.WriteLine(rect.ToString());
            Type obj = rect as Type; //преобразование типа
            Button obj4 = new Button();
            if (obj != null)
            {
                Console.WriteLine("object implements the Type interface");
                obj.type();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("object does not implements the Type interface"); 
            }
            obj = window as Type; //преобразование типа
            if (obj != null)
            {
                Console.WriteLine("object implements the Type interface");
            }
            else
            {
                Console.WriteLine("object does not implements the Type interface");
            }

            if (menu.Button is Windows) //приведение к типу
            {
                Console.WriteLine("object implements the Windows abstract class");
                Console.WriteLine(menu.Button.ToString());
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("object does not implements the Windows abstract class");
            }

            if (figure is Windows) //приведение к типу
            {
                Console.WriteLine("object implements the Windows abstract class");
            }
            else
            {
                Console.WriteLine("object does not implements the Windows abstract class");
            }

            object[] objects = { window, figure, rect, menu, menu.Button };
            Printer printer = new Printer();
            foreach (var i in objects)
            {
                Type obj3 = i as Type;
                if (obj3 != null)
                {
                    printer.IAmPrinting(obj3);

                }
                else
                {
                    Console.WriteLine("object does not implements the Type interface");
                    Console.WriteLine();
                }

            }
        }
    }

    //одноименные методы в интерфейсе и абстрактном классе
    interface Type
    {
        void type();
    }

    abstract class Windows
    {
        void Increase(ref int w, ref int h)
        {
            w = w * 2;
            h = h * 2;
        }
        public abstract void info();
        public abstract void type();
    }

    class Printer
    {
        public void IAmPrinting(Type obj)
        {
            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj.ToString());
            Console.WriteLine();
        }
    }

}
