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
using System.Data.SqlClient;
using System.IO;

namespace Parsing
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Pars_Click(object sender, RoutedEventArgs e)
        {
            string command = "insert into Users values(@login)";
            string connectionString = @"Data Source=DBSRV\MAM2022;Initial Catalog=NamsaraevAR_01;Integrated Security=True";
            var text = txtPut.Text;
            using (StreamReader SR = new StreamReader(text))
            {
                if (text == null)
                {
                    MessageBox.Show("Введите данные!");
                }
                else
                {
                    while (SR.Peek() != -1)
                    {
                        SqlConnection connection = new SqlConnection(connectionString);
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(command, connection);
                        string s = SR.ReadLine();
                        char separators = ' ' ;
                        string[] login = s.Split(separators);
                        txtResult.Text = (login[1]);
                        text = txtResult.Text;
                        cmd.Parameters.Add("@login", System.Data.SqlDbType.NVarChar, 30).Value = text;
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
        }
    }
}
