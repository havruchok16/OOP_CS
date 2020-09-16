using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t Task 1 ");

            //task_1_a
            Console.WriteLine(" a) ");
            int INT = 123;
            uint UINT = 12345;
            short SHORT = -1000;
            ushort USHORT = 1000;
            long LONG = 12345;
            ulong ULONG = 12345678;
            double DOUBLE = 16.1756;
            byte BYTE = 33;
            sbyte SBYTE = -33;
            char CHAR = 'A';
            string STRING = "Sharp";
            bool BOOL = true;
            object OBJECT = "obj";

            Console.WriteLine("Types C#: ");
            Console.WriteLine("int: " + INT + "; uint: " + UINT + "; short: " + SHORT + "; ushort: "
                + USHORT + "; long: " + LONG + "; ulong: " + ULONG + "; double: " + DOUBLE + "; string: "
                + STRING + "; byte: " + BYTE + "; sbyte: " + SBYTE + "; bool: " + BOOL + "; char: "
                + CHAR + "; object: " + OBJECT);

            //task_1_b
            Console.WriteLine(" b) ");
            //явное преобразование
            int a = (int)BYTE;
            uint aa = (uint)BYTE;
            long b = (long)INT;
            ulong bb = (ulong)LONG;
            byte c = (byte)INT;
            sbyte cc = (sbyte)INT;

            Console.WriteLine("conversion (1): ");
            Console.WriteLine("byte in int: " + a + "; int in long: " + b + "; int in byte: " + c);
            Console.WriteLine("byte in uint: " + aa + "; int in ulong: " + bb + "; int in sbyte: " + cc);

            //неявное преобразование
            int d = c;
            uint dd = c;
            long f = a;
            long g = c;
            ulong gg = c;

            Console.WriteLine("conversion (2): ");
            Console.WriteLine("byte in int: " + d + "; int in long: " + f + "; byte in long: " + g);
            Console.WriteLine("byte in uint: " + dd + "; byte in ulong: " + gg);

            //task_1_c
            Console.WriteLine(" c) ");
            int BOX = 1609;
            //boxing
            object O = BOX;
            //unboxing
            int UNBOX = (int)O;
            Console.WriteLine("boxing: " + BOX);
            Console.WriteLine("unboxing: " + UNBOX);

            //task_1_d
            Console.WriteLine(" d) ");
            var VAR = "NotType";
            Console.WriteLine("implicitly typed: " + VAR);

            //task_1_e
            Console.WriteLine(" e) ");
            int? N = null;
            Console.Write("NUllable? : ");
            if (N.HasValue)
            {
                Console.WriteLine(N.Value);
            }
            else
            {
                Console.Write("N is null");
            }
            Console.WriteLine();

            int? M = 17;
            Console.Write("NUllable? : ");
            if (M.HasValue)
            {
                Console.WriteLine(M.Value);
            }
            else
            {
                Console.Write("M is null");
            }




            Console.WriteLine("\t Task 2 ");

            //task_2_a
            Console.WriteLine(" a) ");
            string STR = "My Name";
            string STR2 = "is Yana";
            string STR3 = "My Name";
            Console.WriteLine(STR + "\n" + STR2 + "\n" + STR3 + "\n");
            Console.WriteLine(STR + " and " + STR2);
            if (STR == STR2)
            {
                Console.WriteLine("string is true");
            }
            else
            {
                Console.WriteLine("string is false");
            }
            Console.WriteLine(STR + " and " + STR3);
            if (STR == STR3)
            {
                Console.WriteLine("string is true");
            }
            else
            {
                Console.WriteLine("string is false");
            }

            //task_2_b
            Console.WriteLine(" b) ");
            string s1 = " new ";
            string s2 = " programming ";
            string s3 = " language ";
            Console.WriteLine("Concat: " + String.Concat(s1, s2, s3)); //объединение
            Console.WriteLine("Copy: " + String.Copy(s1)); //копирование строки
            Console.WriteLine("Substring: " + s2.Substring(4, 5)); //выделение подстроки
            string s4 = "It is new programming language";
            Console.WriteLine("Split: " + s4); //разделение строки на слова
            string[] words = s4.Split(new char[] { ' ' });
            foreach (string s in words)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("Insert: " + s4.Insert(6, s1)); //вставка подстроки в заданную позицию
            Console.WriteLine("Remove: " + s4.Remove(0, 5)); //удаление заданной подстроки
            Console.WriteLine("Replace: " + s4.Replace("programming", s1)); //замена заданной подстроки
            Console.WriteLine("ToLower: " + s4.ToLower()); //смена регистра на строчные
            Console.WriteLine("ToUpper: " + s4.ToUpper()); //смена регистра на прописные

            //task_2_c
            Console.WriteLine(" c) ");
            string str1 = String.Empty;
            string str2 = null;
            if (str1 == str2)
            {
                Console.WriteLine("str1==str2");
            }
            else
            {
                Console.WriteLine("str1!=str2");
            }

            //task_2_d
            Console.WriteLine(" d) ");
            StringBuilder STRINGBUI = new StringBuilder("C# is very ");
            Console.WriteLine("STRINGBUI: " + STRINGBUI);
            Console.WriteLine("Length STRINGBUI: " + STRINGBUI.Length);
            STRINGBUI.Append("interesting ");
            Console.WriteLine("STRINGBUI after append: " + STRINGBUI);
            Console.WriteLine("Length STRINGBUI: " + STRINGBUI.Length);
            STRINGBUI.Insert(0, "Language ");
            Console.WriteLine("STRINGBUI after insert: " + STRINGBUI);
            Console.WriteLine("Length STRINGBUI: " + STRINGBUI.Length);
            STRINGBUI.Remove(15, 5);
            Console.WriteLine("STRINGBUI after remove: " + STRINGBUI);
            Console.WriteLine("Length STRINGBUI: " + STRINGBUI.Length);




            Console.WriteLine("\t Task 3 ");

            //task_3_a
            Console.WriteLine(" a) ");
            int[,] arr = new int[3, 3]
            {
                { 1, 2, 3 },
                { 5, 6, 7 },
                { 9, 10, 11 }
            };
            Console.WriteLine("double array: ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }

            //task_3_b
            Console.WriteLine(" b) ");
            string[] NUMBERS = new string[] { "one", "two", "three", "four", "five" };
            Console.WriteLine("Array: ");
            for (int i = 0; i < NUMBERS.Length; i++)
            {
                Console.Write(NUMBERS[i] + "; ");
            }
            Console.WriteLine();
            Console.WriteLine("Length of array: " + NUMBERS.Length);
            Console.Write("input number elem for replace: ");
            int NUM = int.Parse(Console.ReadLine());
            Console.Write("input new elem of array: ");
            for (int i = 0; i < NUMBERS.Length; i++)
            {
                if (i + 1 == NUM)
                {
                    NUMBERS[i] = Console.ReadLine();
                }
            }
            Console.WriteLine("Array after replace: ");
            for (int i = 0; i < NUMBERS.Length; i++)
            {
                Console.Write(NUMBERS[i] + "; ");
            }
            Console.WriteLine();

            //task_3_с
            Console.WriteLine(" с) ");
            int[][] arr2 = new int[3][];
            arr2[0] = new int[2];
            arr2[1] = new int[3];
            arr2[2] = new int[4];

            Console.WriteLine("Input elem of array: ");
            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = 0; j < arr2[i].Length; j++)
                {
                    arr2[i][j] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }

            Console.WriteLine("Array: ");
            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = 0; j < arr2[i].Length; j++)
                {
                    Console.Write(arr2[i][j] + "; ");
                }
                Console.WriteLine();
            }

            //task_3_d
            Console.WriteLine(" d) ");
            var VARARR = new[]
            {
            new[]{15,16,17},
            new[]{17,16,15}
            };
            Console.WriteLine("Array: ");
            for (int i = 0; i < VARARR.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(VARARR[i][j] + "; ");
                }
                Console.WriteLine();
            }
            var VARSTR = new[] { "one", "two", "three" };
            Console.WriteLine("String: ");
            for (int i = 0; i < VARSTR.Length; i++)
            {
                Console.Write(VARSTR[i] + "; ");
            }
            Console.WriteLine();




            Console.WriteLine("\t Task 4 ");

            //task_4_a
            Console.WriteLine(" a) ");
            (int, string, char, string, ulong) CORTEGE1 = (16, "sep", 't', "ember", 160920);

            //task_4_b
            Console.WriteLine(" b) ");
            Console.WriteLine("Cortege: " + CORTEGE1.ToString());
            Console.WriteLine(CORTEGE1.Item1); // 16
            Console.WriteLine(CORTEGE1.Item3); // t
            Console.WriteLine(CORTEGE1.Item4); // ember

            //task_4_c
            Console.WriteLine(" c) ");
            //распаковка кортежа
            int UNPUCK1 = CORTEGE1.Item1;
            string UNPUCK2 = CORTEGE1.Item2;
            char UNPUCK3 = CORTEGE1.Item3;
            string UNPUCK4 = CORTEGE1.Item4;
            ulong UNPUCK5 = CORTEGE1.Item5;
            Console.WriteLine("Cortege after unpuck: " + UNPUCK1 + "; " + UNPUCK2 + "; "
                + UNPUCK3 + "; " + UNPUCK4 + "; " + UNPUCK5);

            //task_4_d
            Console.WriteLine(" d) ");
            //сравнение двух кортежей
            (int cor1, string cor2, char cor3, string cor4, ulong cor5) CORTEGE2 = (16, "day", 'a', "tag", 160916);
            (int cor6, string cor7, char cor8, string cor9, ulong cor0) CORTEGE3 = (16, "day", 'a', "tag", 160916);
            Console.WriteLine(CORTEGE1.CompareTo(CORTEGE2));
            Console.WriteLine(CORTEGE3.CompareTo(CORTEGE2));




            Console.WriteLine("\t Task 5 ");

            var FUNC = FUNCTION();
            Console.WriteLine(FUNC);
            Console.ReadKey();
        }
        private static (int, int, int, char) FUNCTION()
        {
            int[] arraaay = new int[3] { 15, 16, 17 };
            Console.WriteLine( "Array: ");
            for (int i = 0; i < arraaay.Length; i++)
            {
                Console.Write(arraaay[i] + "; ");
            }
            string striiing = "striiing";
            int MAX = arraaay.Max();
            int MIN = arraaay.Min();
            int ARRSUM = arraaay.Sum();
            char ELEM = striiing[0];
            var RESULT = (MAX, MIN, ARRSUM, ELEM);
            Console.WriteLine();
            Console.WriteLine(" RESULT:\nmax, min, sum, elem: ");
            return RESULT;
        }

    }

}
