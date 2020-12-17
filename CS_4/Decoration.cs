using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_5
{
    class Decoration
    {
        bool haveDecor;
        string backgroundColor;

        public Decoration()
        {
            this.haveDecor = false;
            this.backgroundColor = "black";
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
            string str = "Decoration:: " + Decor + "\tBackgroung: " + BackgroundColor;
            return str;
        }
    }
}
