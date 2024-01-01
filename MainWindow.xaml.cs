using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;


namespace _213001_Final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private object con;

        public MainWindow()
        {
            InitializeComponent();
            LoadGrid();
        }

        public object TextBox1 { get; private set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var fon = new SqlConnection("Data Source=.; Initial Catalog =STD_ENR; Intefrates Security =TRUE");
            string query = "Select * from STD_ENR where Std_Id='" + textbox1.Text + "' and Std_Name = '" + textbox2.Text + "'";
            fon.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, fon);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if((dt.Rows.Count > 0))
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Try to enter correct data");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "";
            textbox2.Text = "";

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var fon = new SqlConnection("Data Source=.; Initial Catalog =STD_ENR; Intefrates Security =TRUE");
            string query = "Select * from STD_ENR where Std_Id='" + textbox1.Text + "' and Std_Name = '" + textbox2.Text + "'";
            fon.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, fon);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if ((dt.Rows.Count > 0))
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Try to enter correct data");
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from STD_ENR table", con);
            DataTable dt = new DataTable();
            DataTable sda = new DataTable();
            object value = con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load();
            con.Close();
            DataGrid.ItemsSourceProperty = dt.DefaultView;

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from STD_ENR where ID = " + textbox1.Text + " ", con);
            try
            {cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted");

            }
            clearData();
            LoadGrid();
            con.Close();
            catch
            {
                 MessageBox.Show(ex.Message);
            }
        }
    }
}