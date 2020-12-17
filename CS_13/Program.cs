using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CS_13
{
    [Serializable]
    public class Decoration
    {
        bool haveDecor;
        string backgroundColor;

        public Decoration()
        {
        }

        public Decoration(bool dec, string color)
        {
            this.haveDecor = dec;
            this.backgroundColor = color;
        }

        public bool Decor
        {
            get { return haveDecor; }
            set { haveDecor = value; }
        }

        public string BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; }
        }

        public override string ToString()
        {
            string str = "Decoration:: " + Decor + "; Background: " + BackgroundColor;
            return str;
        }
    }
    
    [Serializable]
    public class Figure : Decoration
    {
        string color;
        bool stroke;

        public Figure()
        {
        }

        public Figure(string col, bool str)
        {
            this.color = col;
            this.stroke = str;
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public bool Stroke
        {
            get { return stroke; }
            set { stroke = value; }
        }

        public override string ToString()
        {
            string str = "Color of Figure: " + Color + "; Stroke: " + Stroke;
            return str;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tTask 1");

            Console.WriteLine("---BinaryFormatter---");

            Figure figure = new Figure("black", false);

            //сериализация через бинарный формат
            BinaryFormatter formatter = new BinaryFormatter();
            //получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("figure.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, figure);
                Console.WriteLine("object is serialized");
            }

            //десериализация из файла figure.dat
            using (FileStream fs = new FileStream("figure.dat", FileMode.OpenOrCreate))
            {
                Figure newFigure = (Figure)formatter.Deserialize(fs);
                Console.WriteLine("object is deserialized");
                Console.WriteLine($"Objects color: {newFigure.Color} and stroke: {newFigure.Stroke}");
            }

            Console.WriteLine("---Json---");

            Decoration decoration = new Decoration(true, "pink");

            //сериализация через json формат
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Decoration));
            using (FileStream fs = new FileStream("decoration.json", FileMode.OpenOrCreate)) 
            {
                jsonFormatter.WriteObject(fs, decoration);
                Console.WriteLine("object is serialized");
            }
            //десериализация
            using (FileStream fs = new FileStream("decoration.json", FileMode.OpenOrCreate))
            {
                Decoration newDecoration = (Decoration)jsonFormatter.ReadObject(fs);
                Console.WriteLine("object is deserialized");
                Console.WriteLine($"Objects have decorations: {newDecoration.Decor} and Background-color: {newDecoration.BackgroundColor}");
            }



            Console.WriteLine("---XML---");

            Decoration decoration2 = new Decoration(false, "white");

            //сериализация через xml формат
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(Decoration));
            using (FileStream fs = new FileStream("decoration.xml", FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(fs, decoration2);
                Console.WriteLine("object is serialized");
            }
            //десериализация
            using (FileStream fs = new FileStream("decoration.xml", FileMode.OpenOrCreate))
            {
                Decoration newDecoration2 = xmlFormatter.Deserialize(fs) as Decoration;
                Console.WriteLine("object is deserialized");
                Console.WriteLine($"Objects have decorations: {newDecoration2.Decor} and Background-color: {newDecoration2.BackgroundColor}");
            }



            Console.WriteLine("---SOAP---");

            Decoration decoration3 = new Decoration(true, "black");

            //сериализация через soap формат
            SoapFormatter soapFormatter = new SoapFormatter();
            using (FileStream fs = new FileStream("decoration.soap", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(fs, decoration3);
                Console.WriteLine("object is serialized");
            }
            // десериализация
            using (FileStream fs = new FileStream("decoration.soap", FileMode.OpenOrCreate))
            {
                Decoration newDecoration3 = (Decoration)soapFormatter.Deserialize(fs);
                Console.WriteLine("object is deserialized");
                Console.WriteLine($"Objects have decorations: {newDecoration3.Decor} and Background-color: {newDecoration3.BackgroundColor}");
            }



            Console.WriteLine("\n\tTask 2");

            //сериализация/десериализация массива объектов
            Figure figure2 = new Figure("white", true);
            Figure figure3 = new Figure("gray", true);
            Figure figure4 = new Figure("blue", false);

            Figure[] array = new Figure[] { figure2, figure3, figure4 };

            //сериализация через бинарный формат
            BinaryFormatter formatterArrays = new BinaryFormatter();
            //получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("array.dat", FileMode.OpenOrCreate))
            {
                formatterArrays.Serialize(fs, array);
                Console.WriteLine("objects is serialized");
            }

            //десериализация из файла array.dat
            using (FileStream fs = new FileStream("array.dat", FileMode.OpenOrCreate))
            {
                Figure[] newFigureArray = (Figure[])formatterArrays.Deserialize(fs);
                Console.WriteLine("objects is deserialized");
                foreach (Figure fig in newFigureArray)
                {
                    Console.WriteLine($"Objects color: {fig.Color} and stroke: {fig.Stroke}");
                }
            }


            Console.WriteLine("\n\tTask 3");

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("decoration.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            //выбор всех дочерних узлов
            XmlNodeList childnodes = xRoot.SelectNodes("*");
            foreach (XmlNode n in childnodes)
            {
                Console.WriteLine(n.OuterXml);
            }


            Console.WriteLine("\n\tTask 4");

            XDocument xdoc = new XDocument();

            //создаем первый элемент
            XElement student1 = new XElement("student");
            //создаем атрибуты
            XAttribute studentsNameAttr = new XAttribute("name", "Yana");
            XAttribute studentsCourseAttr = new XAttribute("course", 2);
            //добавляем атрибуты в первый элемент
            student1.Add(studentsNameAttr);
            student1.Add(studentsCourseAttr);

            //создаем второй элемент
            XElement student2 = new XElement("student");
            //создаем атрибуты
            XAttribute students2NameAttr = new XAttribute("name", "Yuliana");
            XAttribute students2CourseAttr = new XAttribute("course", 3);
            //добавляем атрибуты во второй элемент
            student2.Add(students2NameAttr);
            student2.Add(students2CourseAttr);


            //создаем корневой элемент
            XElement students = new XElement("students");
            //добавляем в корневой элемент
            students.Add(student1);
            students.Add(student2);
            //добавляем корневой элемент в документ
            xdoc.Add(students);
            //сохраняем документ
            xdoc.Save("students.xml");

            XDocument xdoc2 = XDocument.Load("students.xml");
            var items = from st in xdoc2.Element("students").Elements("student")
                        where st.Attribute("course").Value == "2"
                        select new Student
                        {
                            name = st.Attribute("name").Value,
                            course = st.Attribute("course").Value
                        };

            foreach (var item in items)
            {
                Console.WriteLine($"Student: {item.name} Course: {item.course}");
            }

        }
    }
    class Student
    {
        public string name { get; set; }
        public string course { get; set; }
    }
}
