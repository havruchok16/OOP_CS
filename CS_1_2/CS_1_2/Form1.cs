using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_1_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string size = textBox1.Text;
            string[] str = new string[Convert.ToInt32(size)];
            str = textBox2.Lines;
            var order = str.OrderBy(t => t);
            StringWriter writer = new StringWriter();
            foreach (string s in order)
            {
                writer.WriteLine(s);
            }
            textBox3.Text = writer.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int size = Convert.ToInt32(textBox1.Text);
            if (size < 0)
            {
                MessageBox.Show("Введите положительное число");
            }
            else
            {
                string[] str = new string[Convert.ToInt32(size)];
                List<int> list = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    list.Add(rand.Next(10));
                    str[i] = "Радиус круга = " + Convert.ToString(list[i]);
                }
                textBox2.Lines = str;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string size = textBox1.Text;
            string[] str = new string[Convert.ToInt32(size)];
            str = textBox2.Lines;
            var order = str.OrderByDescending(t => t);
            StringWriter writer = new StringWriter();
            foreach (string s in order)
            {
                writer.WriteLine(s);
            }
            textBox3.Text = writer.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string size = textBox1.Text;
            string[] str = new string[Convert.ToInt32(size)];
            str = textBox2.Lines;
            var max = str.Max(t => t);
            textBox3.Text = max.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string size = textBox1.Text;
            string[] str = new string[Convert.ToInt32(size)];
            str = textBox2.Lines;
            var min = str.Min(t => t);
            textBox3.Text = min.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string size = textBox1.Text;
            string[] str = new string[Convert.ToInt32(size)];
            if(Convert.ToInt32(size) < 2)
            {
                MessageBox.Show("Для этого запроса необходимо сгенерировать коллекцию большего размера");
            }
            else
            {
                str = textBox2.Lines;
                var take = str.Take(Convert.ToInt32(size) - 1);
                StringWriter writer = new StringWriter();
                foreach (string s in take)
                {
                    writer.WriteLine(s);
                }
                textBox3.Text = writer.ToString();
            }

        }
    }
}
