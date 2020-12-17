using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_5
{
    class Window
    {
        int windowWidth;
        int windowHeight;
        readonly int ID;
        Decoration decoration;
        Control control;

        public Window()
        {
            this.windowHeight = 1600;
            this.windowWidth = 900;
            this.decoration = new Decoration();
            this.control = new Control();
            ID = windowHeight * windowWidth;
        }

        public Window(int w, int h, bool dec, string color)
        {
            this.windowWidth = w;
            this.windowHeight = h;
            this.decoration = new Decoration(dec, color);
            this.control = new Control();
            ID = windowHeight * windowWidth;
        }

        public int Width
        {
            get { return windowWidth; }
            set { windowWidth = value; }
        }

        public int Height
        {
            get { return windowHeight; }
            set { windowHeight = value; }
        }

        public Decoration Decoration
        {
            get { return decoration; }
        }

        public Control Control
        {
            get { return control; }
        }

        public override bool Equals(object obj)
        {
            Window window = (Window)obj;
            return (this.Height == window.Height && this.Width == window.Width);
        }

        public override int GetHashCode()
        {
            return ID;
        }

        public override string ToString()
        {
            string str = "Width: " + this.Width + "\tHeight: " + this.Height;
            return str;
        }
    }
}
