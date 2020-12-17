using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_4
{
    internal class MyArray
    {
        int[] Array;
        int arraySize;
        public MyArray(int size = 10)
        {
            Array = new int[size];
            arraySize = size;
        }

        public int this[int index]
        {
            get
            {
                return Array[index];
            }
            set
            {
                Array[index] = value;
            }
        }
        public int ArraySize
        {
            get
            {
                return arraySize;
            }
            set
            {
                if (value > 0 && value < 100)
                {
                    arraySize = value;
                }
                else
                {
                    arraySize = 1;
                }
            }
        }

        //сложение элементов массивов
        public static MyArray operator +(MyArray arr1, MyArray arr2)
        {

            MyArray buffArray = new MyArray(arr1.ArraySize);

            for (int i = 0; i < arr1.ArraySize; i++)
            {
                buffArray[i] = arr1[i] + arr2[i];
            }

            return buffArray;
        }

        //умножение массивов
        public static MyArray operator *(MyArray arr1, MyArray arr2)
        {

            MyArray buffArray = new MyArray(arr1.ArraySize);

            for (int i = 0; i < arr1.ArraySize; i++)
            {
                buffArray[i] = arr1[i] * arr2[i];
            }

            return buffArray;
        }

        //сравнение элементов массива
        public static bool operator <(MyArray arr1, MyArray arr2)
        {
            bool check = true;
            for (int i = 0; i < arr1.ArraySize; i++)
            {
                if (arr1[i] >= arr2[i])
                {
                    return check = false;
                }
            }
            return check;
        }

        public static bool operator >(MyArray arr1, MyArray arr2)
        {
            bool check = true;
            for (int i = 0; i < arr1.ArraySize; i++)
            {
                if (arr1[i] <= arr2[i])
                {
                    return check = false;
                }
            }
            return check;
        }

        //сравнение элементов массива
        public static bool operator ==(MyArray arr1, MyArray arr2)
        {
            bool check = true;
            for (int i = 0; i < arr1.ArraySize; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return check = false;
                }
            }
            return check;
        }

        public static bool operator !=(MyArray arr1, MyArray arr2)
        {
            bool check = true;
            for (int i = 0; i < arr1.ArraySize; i++)
            {
                if (arr1[i] == arr2[i])
                {
                    return check = false;
                }
            }
            return check;
        }

        //содержание отрицательных элементов
        public static bool operator true(MyArray arr)
        {
            bool check = true;
            for (int i = 0; i < arr.ArraySize; i++)
            {
                if (arr[i]<0)
                {
                    return check = false;
                }
            }
            return check;
        }

        public static bool operator false(MyArray arr)
        {
            bool check = true;
            for (int i = 0; i < arr.ArraySize; i++)
            {
                if (arr[i] > 0)
                {
                    return check = false;
                }
            }
            return check;
        }

        //int() возвращает размер массива
        //explicit-явное преобразование 
        public static explicit operator int(MyArray arr)
        {
            return arr.ArraySize;
        }

        //implicit-явное преобразование 
        public static implicit operator MyArray(int x)
        {
            return new MyArray { arraySize = x };
        }


        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public class Owner
        {
            int id;
            string name;
            string companyName;

            public Owner(int id = 16092001, string name = "Yana Havrukova", string companyName = "Havruchok")
            {
                this.id = id;
                this.name = name;
                this.companyName = companyName;
            }

            public int ID
            {
                get
                {
                    return id;
                }
            }
            public string Name
            {
                get
                {
                    return name;
                }
            }
            public string CompanyName
            {
                get
                {
                    return companyName;
                }
            }

            public void showInfoAboutMe()
            {
                Console.WriteLine("ID: " + ID + "\t Name: " + Name + "\t Company: " + CompanyName);
            }
        }

        public class Date
        {
            int day;
            int month;
            int year;

            public Date(int day = 16, int month = 9, int year = 2001)
            {
                this.day = day;
                this.month = month;
                this.year = year;
            }

            public int Day
            {
                get
                {
                    return day;
                }
                set
                {
                    if (value >= 1 && value <= 31)
                    {
                        day = value;
                    }
                    else
                    {
                        day = 0;
                    }
                }
            }

            public int Month
            {
                get
                {
                    return month;
                }
                set
                {
                    if (value >= 1 && value <= 12)
                    {
                        month = value;
                    }
                    else
                    {
                        month = 0;
                    }
                }
            }

            public int Year
            {
                get
                {
                    return year;
                }
                set
                {
                    if (value > 0 && value <= 2020)
                    {
                        year = value;
                    }
                    else
                    {
                        year = 0;
                    }
                }
            }

            public void showInfoAboutDate()
            {
                Console.WriteLine("Day: " + Day + "\tMonth: " + Month + "\tYear: " + Year);
            }
        }
    }

    internal static class StatisticOperation
    {
        //сумма элементов
        public static MyArray findSumm(MyArray arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.ArraySize; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        //разница между минимальным и максимальным
        public static MyArray difference(MyArray arr)
        {
            int min = arr[0];
            int max = 0;
            for (int i = 0; i < arr.ArraySize; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max - min;
        }

        //количество элементов
        public static MyArray GetLength(MyArray arr)
        {
            return arr.ArraySize;
        }


        //метод расширения
        public static bool IsContains(this string str, char a)
        {
            return str.Contains(a);
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of array:");
            int arraySize = Convert.ToInt32(Console.ReadLine());

            MyArray arr1 = new MyArray(arraySize);
            MyArray arr2 = new MyArray(arraySize);

            Random random = new Random();

            for (int i = 0; i < arr1.ArraySize; i++)
            {
                arr1[i] = random.Next(0, 20);
                arr2[i] = random.Next(0, 20);
            }

            Console.WriteLine("First array");
            for (int i = 0; i < arr1.ArraySize; i++)
            {
                Console.Write(arr1[i] + "\t");
            }
            Console.WriteLine();

            Console.WriteLine("Second array");
            for (int i = 0; i < arr2.ArraySize; i++)
            {
                Console.Write(arr2[i] + "\t");
            }
            Console.WriteLine();


            Console.WriteLine("Multiplication:");
            MyArray multiplication = arr1 * arr2;
            for (int i = 0; i < multiplication.ArraySize; i++)
            {
                Console.Write(multiplication[i] + "\t");
            }
            Console.WriteLine();

            
            Console.WriteLine("Addition:");
            MyArray addition = arr1 + arr2;
            for (int i = 0; i < addition.ArraySize; i++)
            {
                Console.Write(addition[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("Comparison:");
            if (arr1 > arr2)
            {
                Console.WriteLine("First array greater");
            }
            else
            {
                Console.WriteLine("First array smaller");
            }
            Console.WriteLine();


            Console.WriteLine("Comparison2:");
            if (arr1 == arr2)
            {
                Console.WriteLine("First array == second array");
            }
            else
            {
                Console.WriteLine("First array != second array");
            }
            Console.WriteLine();


            Console.WriteLine("Sum of array elements: ");
            int sum = (int)StatisticOperation.findSumm(arr1);
            Console.WriteLine(sum);

            Console.WriteLine("Difference between the elements: ");
            int dif = (int)StatisticOperation.difference(arr1);
            Console.WriteLine(dif);

            Console.WriteLine("Array size: ");
            int length = (int)StatisticOperation.GetLength(arr1);
            Console.WriteLine(length);


            Console.WriteLine("String: ");

            string MyString = "striiiiing";
            bool isContain = MyString.IsContains('t');

            if (isContain)
            {
                Console.WriteLine("elem in string");
            }
            else
            {
                Console.WriteLine("elem is not in string");
            }

            for (int i = 0; i < MyString.Length; i++)
            {
                Console.Write(MyString[i] + " ");
            }
            Console.WriteLine();


            Console.WriteLine("----------------------------------------------------------------------");
            MyArray.Owner Naaame = new MyArray.Owner();
            MyArray.Date Daaate = new MyArray.Date();

            Naaame.showInfoAboutMe();
            Daaate.showInfoAboutDate();
        }
    }
}
