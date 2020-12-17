using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_5
{
    class Figure : Decoration
    {
        string color;
        bool stroke;

        public Figure()
        {
            this.color = "white";
            this.stroke = false;
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
            string str = "Color og Figure: " + Color + "\tStroke: " + Stroke;
            return str;
        }
    }

    partial class Rect: Figure, Type
    {
        public override string ToString()
        {
            string str = "Opacity: " + Opacity + '%';
            return str;
        }
    }
}
