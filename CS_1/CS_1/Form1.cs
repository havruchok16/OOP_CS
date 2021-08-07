using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string a = textBox1.Text;
                string c = textBox2.Text;
                string nc = textBox3.Text;
                a = a.Replace(c, nc);
                textBox6.Text = a;
            }
            catch
            {
                MessageBox.Show("Вы не ввели строку и/или символ");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string a = textBox1.Text;
                string c = textBox4.Text;
                a = a.Replace(c, "");
                textBox6.Text = a;
            }
             catch
            {
                MessageBox.Show("Вы не ввели строку и/или символ");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string a = textBox1.Text;
                string ind = textBox5.Text;
                int index = Convert.ToInt32(ind);
                if (index < 0 || index > a.Length) 
                {
                    MessageBox.Show("Индекс выходит за пределы");
                }
                else
                {
                    string str = a.Substring(index, 1);
                    textBox6.Text = str;
                }
            }
            catch
            {
                MessageBox.Show("Вы не ввели строку и/или индекс");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            int length = a.Length;
            textBox6.Text = length.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            string check = "EeUuOoAaIiУуЕеыАаОоЭэЯяИиЮю";
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (check.Contains(Convert.ToString(a[i])))
                {
                    count++;
                }
            }

            textBox6.Text = Convert.ToString(count);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            string check = "EeUuOoAaIiУуЕеыАаОоЭэЯяИиЮю";
            int count = 0;
            int count_space = 0;
            int count_dot = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (!check.Contains(Convert.ToString(a[i])))
                {
                    count++;
                }
                if (a[i] == 32)
                {
                    count_space++;
                }
                if (a[i] == 46)
                {
                    count_dot++;
                }
            }
            count -= count_space;
            count -= count_dot;
            textBox6.Text = Convert.ToString(count);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == '.')
                {
                    count++;
                }
            }
            textBox6.Text = Convert.ToString(count);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            int count = 0;

            if (a.Length > 0)
            {
                count = 1;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] == ' ' || (a[i] == ' ' && a[i + 1] == ' '))
                    {
                        count++;
                    }
                }
            }
            else 
            { 
                count = 0;
            }
            textBox6.Text = Convert.ToString(count);
        }
    }
}
