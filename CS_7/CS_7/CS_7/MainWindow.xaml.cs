using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CS_7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public class User : DependencyObject
    {
        public static readonly DependencyProperty UsernameProperty;
        public static readonly DependencyProperty YearsProperty;

        static User()
        {
            UsernameProperty = DependencyProperty.Register("Username", typeof(string), typeof(User));

            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.CoerceValueCallback = new CoerceValueCallback(CorrectValue);

            YearsProperty = DependencyProperty.Register("Years", typeof(int), typeof(User), metadata, new ValidateValueCallback(ValidateValue));
        }
        private static object CorrectValue(DependencyObject d, object baseValue)
        {
            int currentValue = (int)baseValue;
            if (currentValue > 100)  // если больше 100, возвращаем 100
                return 100;
            return currentValue; // иначе возвращаем текущее значение
        }

        private static bool ValidateValue(object value)
        {
            int currentValue = (int)value;
            if (currentValue >= 0) // если текущее значение от нуля и выше
                return true;
            return false;
        }
        public string Username
        {
            get { return (string)GetValue(UsernameProperty); }
            set { SetValue(UsernameProperty, value); }
        }
        public int Years
        {
            get { return (int)GetValue(YearsProperty); }
            set { SetValue(YearsProperty, value); }
        }
    }
    public class WindowCommands
    {
        //5
        static WindowCommands()
        {
            Exit = new RoutedCommand("Exit", typeof(MainWindow));
        }
        public static RoutedCommand Exit { get; set; }

    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            this.Close();
        }

        private void Control_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textBlock.Text = textBlock.Text + "sender: " + sender.ToString() + "\n";
            textBlock.Text = textBlock.Text + "source: " + e.Source.ToString() + "\n\n";
        }

        private void Control2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textBlock.Text = textBlock.Text + "sender: " + sender.ToString() + "\n";
            textBlock.Text = textBlock.Text + "source: " + e.Source.ToString() + "\n\n";
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = String.Empty;
        }
    }
}
