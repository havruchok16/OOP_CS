using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_5
{
    class Menu : Control
    {
        int countButton;
        int menuWidth;
        int menuHeight;
        string menuColor;
        Button button;

        public Menu()
        {
            this.countButton = 0;
            this.menuWidth = 100;
            this.menuHeight = 100;
            this.menuColor = "pink";
            this.button = new Button();
        }

        public Menu(int but, int w, int h, string menuClr, string buttonColor, string buttonText, string textColor)
        {
            this.countButton = but;
            this.menuWidth = w;
            this.menuHeight = h;
            this.menuColor = menuClr;
            this.button = new Button(w, h / but, buttonColor, buttonText, textColor);
        }

        public int CountButton
        {
            get { return countButton; }
            set { countButton = value; }
        }

        public int MenuWidth
        {
            get { return menuWidth; }
            set { menuWidth = value; }
        }

        public int MenuHeight
        {
            get { return menuHeight; }
            set { menuHeight = value; }
        }

        public string MenuColor
        {
            get { return menuColor; }
            set { menuColor = value; }
        }

        public Button Button
        {
            get { return button; }
        }

        public override void type()
        {
            Console.WriteLine("Menu");
        }

        public override string ToString()
        {
            string str = "Size of Menu: " + MenuWidth + "x" + MenuHeight +"\tColor of Menu:" + MenuColor + "\tCount Buttons: " + CountButton;
            return str;
        }
    }
}
