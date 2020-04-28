using Store_M.Models;
using Store_M.Servises;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private readonly string PATH = $"{Environment.CurrentDirectory}\\medData.json";
        private BindingList<MedModel> medData;
        private FileIOservise FileIOservise;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FileIOservise = new FileIOservise(PATH);
            try
            {
                medData = FileIOservise.Load();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            medData = FileIOservise.Load();
            mEdicine.ItemsSource = medData;
            medData.ListChanged += MedData_ListChanged;
        }

        private void MedData_ListChanged(object sender, ListChangedEventArgs e)
        {
          if(e.ListChangedType==ListChangedType.ItemAdded||e.ListChangedType==ListChangedType.ItemDeleted||e.ListChangedType==ListChangedType.ItemChanged)
            {
                try
                {
                    FileIOservise.SaveData(sender);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }

       



        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //    TextBox textBox = (TextBox)sender;
        //    var production = textBox.Text;
        //    var qwert = $"insert into Product ([Name],[Date]) values('{production}',' ')";
        //    var conecnionsString = @"Data Source =.\SQLEXPRESS; Initial Catalog = Hospital;Integrated Security=true;";
        //    using (SqlConnection sql = new SqlConnection(conecnionsString))
        //    {
        //        SqlCommand sqlCommand = new SqlCommand(qwert, sql);
        //        sql.Open();
        //        sqlCommand.ExecuteNonQuery();
        //    }



        //}


        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var qwert = "Select Name from Product";
        //    var conecnionsString = @"Data Source =.\SQLEXPRESS; Initial Catalog = Hospital;Integrated Security=true;";
        //    using (SqlConnection sql = new SqlConnection(conecnionsString))
        //    {
        //        SqlCommand sqlCommand = new SqlCommand(qwert, sql);
        //        sql.Open();
        //        var d = sqlCommand.ExecuteReader();

        //        DataTable dataTable = new DataTable();
        //        dataTable.Load(d);


        //        Table.ItemsSource = dataTable.Rows;


        //    }
        //}


    }
}
