using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using Path = System.IO.Path;

namespace CS_4_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            MyRichTextBox.AddHandler(RichTextBox.DragOverEvent, new DragEventHandler(MyRichTextBox_DragOver), true);
            MyRichTextBox.AddHandler(RichTextBox.DropEvent, new DragEventHandler(MyRichTextBox_Drop), true);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "RichText Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";
            if (sfd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(MyRichTextBox.Document.ContentStart, MyRichTextBox.Document.ContentEnd);
                using (FileStream fs = File.Create(sfd.FileName))
                {
                    if (Path.GetExtension(sfd.FileName).ToLower() == ".rtf")
                        doc.Save(fs, DataFormats.Rtf);
                    else if (Path.GetExtension(sfd.FileName).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                    else
                        doc.Save(fs, DataFormats.Xaml);
                }
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "RichText Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt|All files (*.*)|*.*";

            if (ofd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(MyRichTextBox.Document.ContentStart, MyRichTextBox.Document.ContentEnd);
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    if (Path.GetExtension(ofd.FileName).ToLower() == ".rtf")
                        doc.Load(fs, DataFormats.Rtf);
                    else if (Path.GetExtension(ofd.FileName).ToLower() == ".txt")
                        doc.Load(fs, DataFormats.Text);
                    else
                        doc.Load(fs, DataFormats.Xaml);
                }
            }     
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        }

        private void Color_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock selectedItem = (TextBlock)FontColor.SelectedItem;
            TextSelection selection = MyRichTextBox.Selection;
            if (selectedItem.Text == "111")
            {
                selection.ApplyPropertyValue(RichTextBox.ForegroundProperty, Brushes.Black);
            }
            else if (selectedItem.Text == "222")
            {
                selection.ApplyPropertyValue(RichTextBox.ForegroundProperty, Brushes.Gray);
            }
            else if (selectedItem.Text == "333")
            {
                selection.ApplyPropertyValue(RichTextBox.ForegroundProperty, Brushes.Red);
            }
            else if (selectedItem.Text == "444")
            {
                selection.ApplyPropertyValue(RichTextBox.ForegroundProperty, Brushes.Pink);
            }
            else if (selectedItem.Text == "555")
            {
                selection.ApplyPropertyValue(RichTextBox.ForegroundProperty, Brushes.Violet);
            }
            else if (selectedItem.Text == "666")
            {
                selection.ApplyPropertyValue(RichTextBox.ForegroundProperty, Brushes.SkyBlue);
            }
        }
        private void MyRichTextBox_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.All;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = false;
        }
        private void MyRichTextBox_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] docPath = (string[])e.Data.GetData(DataFormats.FileDrop);

                // По умолчанию открыть как форматированный текст
                var dataFormat = DataFormats.Rtf;

                // Если нажата клавиша Shift, открыть как обычный текст.
                if (e.KeyStates == DragDropKeyStates.ShiftKey)
                {
                    dataFormat = DataFormats.Text;
                }

                System.Windows.Documents.TextRange range;
                System.IO.FileStream fStream;
                if (System.IO.File.Exists(docPath[0]))
                {
                    try
                    {
                        // Откройте документ в RichTextBox.
                        range = new System.Windows.Documents.TextRange(MyRichTextBox.Document.ContentStart, MyRichTextBox.Document.ContentEnd);
                        fStream = new System.IO.FileStream(docPath[0], System.IO.FileMode.OpenOrCreate);
                        range.Load(fStream, dataFormat);
                        fStream.Close();
                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("File could not be opened. Make sure the file is a text file.");
                    }
                }
            }
        }

        private void language_Click(object sender, RoutedEventArgs e)
        {
            string value = (string)((Button)e.OriginalSource).Content;
            if (value == "ENG")
            {
                Symbols.Content = "Символы";
                Open.Content = "Открыть";
                Save.Content = "Сохранить";
                Copy.Text = "Копировать";
                Cut.Text = "Вырезать";
                Paste.Text = "Вставить";
                Undo.Text = "Удалить";
                lan.Content = "РУС";
            }
            if (value == "РУС")
            {
                Symbols.Content = "Symbols";
                Open.Content = "Open";
                Save.Content = "Save";
                Copy.Text = "Copy";
                Cut.Text = "Cut";
                Paste.Text = "Paste";
                Undo.Text = "Undo";
                lan.Content = "ENG";
            }
        }

        private void Func_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock selectedItem = (TextBlock)Func.SelectedItem;

            if (selectedItem.Text == "Copy")
            {
                MyRichTextBox.SelectAll();
                MyRichTextBox.Copy();
            }
            else if (selectedItem.Text == "Paste")
            {
                MyRichTextBox.Paste();
            }
            else if (selectedItem.Text == "Undo")
            {
                MyRichTextBox.Undo();
            }
            else if (selectedItem.Text == "Cut")
            {
                MyRichTextBox.Cut();
            }
        }

        private void MyRichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextRange range = new TextRange(MyRichTextBox.Document.ContentStart, MyRichTextBox.CaretPosition);
            int N = range.Text.Length;
            Number.Content = N.ToString();
        }

        private void button_I_Click(object sender, RoutedEventArgs e)
        {
            string value = (string)((Button)e.OriginalSource).Content;
            TextSelection selection = MyRichTextBox.Selection;
            FontStyle styleState = FontStyles.Normal;
            if (value == "I")
            {
                if (selection.GetPropertyValue(Run.FontStyleProperty) != DependencyProperty.UnsetValue)
                {
                    styleState = (FontStyle)selection.GetPropertyValue(Run.FontStyleProperty);
                }
                if (styleState == FontStyles.Italic)
                {
                    selection.ApplyPropertyValue(Run.FontStyleProperty, FontStyles.Normal);
                }
                else
                {
                    selection.ApplyPropertyValue(Run.FontStyleProperty, FontStyles.Italic);
                }
            }
        }

        private void button_B_Click(object sender, RoutedEventArgs e)
        {
            string value = (string)((Button)e.OriginalSource).Content;
            TextSelection selection = MyRichTextBox.Selection;
            FontWeight weightState = FontWeights.Normal;
            if (value == "B")
            {
                if (selection.GetPropertyValue(Run.FontWeightProperty) != DependencyProperty.UnsetValue)
                {
                    weightState = (FontWeight)selection.GetPropertyValue(Run.FontWeightProperty);
                }
                if (weightState == FontWeights.Normal)
                {
                    selection.ApplyPropertyValue(Run.FontWeightProperty, FontWeights.Bold);
                }
                else
                {
                    selection.ApplyPropertyValue(Run.FontWeightProperty, FontWeights.Normal);
                }
            }
        }

        private void button_U_Click(object sender, RoutedEventArgs e)
        {
            string value = (string)((Button)e.OriginalSource).Content;
            TextSelection selection = MyRichTextBox.Selection;
            TextDecorationCollection currentState = null;
            if (value == "U")
            {
                if (selection.GetPropertyValue(Run.TextDecorationsProperty) != DependencyProperty.UnsetValue)
                {
                    currentState = (TextDecorationCollection)selection.GetPropertyValue(Run.TextDecorationsProperty);
                }

                if (currentState != TextDecorations.Underline)
                {
                    selection.ApplyPropertyValue(Run.TextDecorationsProperty, TextDecorations.Underline);
                }
                else
                {
                    selection.ApplyPropertyValue(Run.TextDecorationsProperty, null);
                }
            }
        }

        private void style_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock selectedItem = (TextBlock)style.SelectedItem;

            if (selectedItem.Text == "aqua")
            {
                Uri uri = new Uri("aqua_style.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            }
            if (selectedItem.Text == "piink")
            {
                Uri uri = new Uri("piink_style.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            }
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Background = new SolidColorBrush(Color.FromArgb(123, 20, 100, 90));
        }
    }
}
