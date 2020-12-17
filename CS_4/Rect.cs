using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_5
{
   partial class Rect : Figure, Type
    {
        int opacity;

        public Rect()
        {
            this.opacity = 0;
        }

        public Rect(int opac)
        {
            this.opacity = opac;
        }

        public int Opacity
        {
            get { return opacity; }
            set { opacity = value; }
        }

        public void type()
        {
            Console.WriteLine("Rect");
        }

    }
}
