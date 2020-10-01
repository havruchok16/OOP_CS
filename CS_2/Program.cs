using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_2
{
    partial class Book
    {
        private string name = "";
        private string author = "";
        private string publication = "";
        private int years = 0;
        public int pages = 0;
        public int price = 0;
        const string textColor = "black";
        private readonly int booksID = 0;//только для чтения
        private static int size = 0;//количество объектов

        public static void infoAboutSize()
        {
            Console.WriteLine("Size:" + size);
        }

        public string NAME
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string AUTHOR
        {
            get { return this.author; }
            set { this.author = value; }
        }

        public string PUBLICATON
        {
            set { this.publication = value; }
        }



    }
    class Program
    { 
        static void Main(string[] args)
        {

        }
    } 
}
