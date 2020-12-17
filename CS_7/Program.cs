using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_7
{
    interface IOperations<T>
    {
        void Add(T value);
        void Delete(T value);
        void View();
    }

    class MyClass<T> : IOperations<T> where T :  struct
    {
        T[] array;
        public int SizeOfArray { get; set; }
        public MyClass(int size)
        {
            this.SizeOfArray = size;
        }
        public MyClass(int size, T[] arr)
        {
            this.SizeOfArray = size;
            array = new T[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = arr[i];
            }
        }
        public T this [int index]
        {
            get { return array[index]; }
            set
            {
                array[index] = value;
            }
        }
        public void Add(T value)
        {
            T[] buff = new T[this.SizeOfArray + 1];
            for (int i = 0; i < this.SizeOfArray; i++) 
            {
                buff[i] = array[i];
            }
            buff[this.SizeOfArray] = value;
            this.SizeOfArray++;
            array = new T[this.SizeOfArray];
            for (int i = 0; i < this.SizeOfArray; i++)
            {
                array[i] = buff[i];
            }
        }
        public void Delete(T value)
        {
            List<T> buff = new List<T>();
            bool check = true;
            for (int i = 0; i < SizeOfArray; i++)
            {
                if(!array[i].Equals(value))
                {
                    buff.Add(array[i]);
                }
                else
                {
                    check = false;
                }
            }
            if (check == true) 
            {
                throw new MyException("Error//there is no such element.");
            }
            SizeOfArray--;
            array = buff.ToArray();
        }
        public void View()
        {
            Console.Write("Array: ");
            foreach(T i in array)
            {
                Console.Write(i.ToString() + " ");
            }
            Console.WriteLine();
        }
        public void Save()
        {
            string path = @"..\\save.txt";
            FileStream file = new FileStream(path, FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(file);
            for (int i = 0; i < SizeOfArray; i++)
            {
                writer.Write(array[i].ToString() + " ");
            }
            Console.WriteLine("Saving to a file");
            writer.Close();
        }

    }
    class MyException: ArgumentException
    {
        public MyException(string message) : base(message)
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = new int[5] { 1, 3, 5, 7, 9 };
            MyClass<int> arr = new MyClass<int>(myArray.Length, myArray);
            arr.View();
            arr.Add(11);
            arr.View();
            arr.Delete(1);
            arr.View();
            arr.Save();
            try
            {
                arr.Delete(2);
            }
            catch(MyException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally!");
            }
        }
    }
}
