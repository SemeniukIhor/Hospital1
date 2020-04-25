using System;
using System.Collections.Generic;
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

namespace Store_M
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            TextBox textBox = (TextBox)sender;
            var production = textBox.Text;
            var qwert = $"insert into Product ([Name],[Date]) values('{production}',' ')";
            var conecnionsString = @"Data Source =.\SQLEXPRESS; Initial Catalog = Hospital;Integrated Security=true;";
            using (SqlConnection sql = new SqlConnection(conecnionsString))
            {
                SqlCommand sqlCommand = new SqlCommand(qwert, sql);
                sql.Open();
                sqlCommand.ExecuteNonQuery();
            }

                
             
        }

       

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var qwert = "Select Name from Product";
            var conecnionsString = @"Data Source =.\SQLEXPRESS; Initial Catalog = Hospital;Integrated Security=true;";
            using (SqlConnection sql = new SqlConnection(conecnionsString))
            {
                SqlCommand sqlCommand = new SqlCommand(qwert, sql);
                sql.Open();
                var d = sqlCommand.ExecuteReader();
                int i = 0;
                while (d.Read())
                {
                    this.Output.Text = d[0].ToString();
                    i++;
                }

            }
        }
    }
}
