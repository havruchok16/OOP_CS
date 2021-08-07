using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
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

namespace CS_8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string str;
        string connectionString;
        bool fl = false;
        DataTable myTable;
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter1;

        public MainWindow()
        {
            InitializeComponent(); 
            connectionString = "Data Source=YANA; Initial Catalog = H_MyBase; Integrated Security = True";

            Script.Items.Add("Все строки и столбцы");
            Script.Items.Add("Количество_заказанного_товара>2");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string sqlExpression = "SELECT * FROM ПРОДАЖИ";
                myTable = new DataTable();
                command = new SqlCommand(sqlExpression, connection);
                adapter1 = new SqlDataAdapter(command);
                adapter1.Fill(myTable);
                MyBaseGrid.ItemsSource = myTable.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        //процедуры
        private void Procedure_Click(object sender, RoutedEventArgs e)
        {
            if (fl==false)
                MessageBox.Show("Хранимая процедура была выполнена!");
            else
                GetProcessors();
        }
        //работа с процедурами
        private void GetProcessors()
        {
            string sqlExpression = "sp_GetUsers";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    str = $"{reader.GetName(1)}\t{reader.GetName(2)}\t{reader.GetName(3)}\t\n";

                    while (reader.Read())
                    {
                        object type = reader.GetValue(1);
                        object processor = reader.GetValue(2);
                        object size = reader.GetValue(3);
                        str += $"{type}\t\t{processor}\t\t\t{size}\t\n";
                    }
                }
                MessageBox.Show(str);
                reader.Close();
                Window_Loaded(new object(), new RoutedEventArgs());
            }
            fl = true;
        }
        //обновить бд
        private void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter1);
            adapter1.Update(myTable);
        }
        //кнопка обновления бд
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }
        //кнопка удаления
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MyBaseGrid.SelectedItems != null)
            {
                for (int i = 0; i < MyBaseGrid.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = MyBaseGrid.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
            UpdateDB();
        }
        //работа с запросами
        string script = "";
        private void Script_Click(object sender, RoutedEventArgs e)
        {
            SqlTransaction tx = null;
            if (Script.SelectedIndex == 0)
                script = "SELECT * FROM ПРОДАЖИ";
            else
                script = "SELECT * FROM ПРОДАЖИ WHERE (Количество_заказанного_товара>2)";

            try
            {
                if (script != "")
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(script, connection);
                        tx = connection.BeginTransaction();
                        command.Transaction = tx;
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            str = $"{reader.GetName(1)}\t{reader.GetName(3)}\t{reader.GetName(4)}\t{reader.GetName(2)}\t\t\t\t\t\t\n";

                            while (reader.Read())
                            {
                                object department = reader.GetValue(1);
                                object number = reader.GetValue(3);
                                object price = reader.GetValue(4);
                                object data = reader.GetValue(2);
                                str += $"{department}\t\t\t{number}\t\t{price}\t{data}\t\n";
                            }
                        }
                        MessageBox.Show(str);
                        reader.Close();

                        tx.Commit();
                    }
                }
                else
                {
                    MessageBox.Show("enter script!");
                }
                Window_Loaded(new object(), new RoutedEventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tx.Rollback();
            }
        }
    }
}
