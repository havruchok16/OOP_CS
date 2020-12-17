using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_5
{
    sealed class Button : Control, Type  //бесплодный класс
    {
        int buttonWidth;
        int buttonHeight;
        string buttonColor;
        string buttonText;
        string textColor;

        public Button()
        {
            this.buttonWidth = 50;
            this.buttonHeight = 50;
            this.buttonColor = "white";
            this.buttonText = "It is button";
            this.textColor = "black";
        }

        public Button(int w, int h, string bckgrColor, string txt, string txtColor)
        {
            this.buttonWidth = w;
            this.buttonHeight = h;
            this.buttonColor = bckgrColor;
            this.buttonText = txt;
            this.textColor = txtColor;
        }

        public int ButtonWidth
        {
            get { return buttonWidth; }
            set { buttonWidth = value; }
        }

        public int ButtonHeight
        {
            get { return buttonHeight; }
            set { buttonHeight = value; }
        }

        public string ButtonColor
        {
            get { return buttonColor; }
            set { buttonColor = value; }
        }

        public string ButtonText
        {
            get { return buttonText; }
            set { buttonText = value; }
        }

        public string TextColor
        {
            get { return textColor; }
            set { textColor = value; }
        }

        public override void type()
        {
            Console.WriteLine("Button");
        }

        public void info()
        {
            Console.WriteLine("Size of Button: " + ButtonWidth + "x" + ButtonHeight );
        }

        public override string ToString()
        {
            string str = "Size of Button: " + ButtonWidth + "x" + ButtonHeight + "\tText: " + ButtonText + "\tButton color: " + ButtonColor + "\tText color: " + TextColor;
            return str;
        }
    }
}
