using MySql.Data.MySqlClient;
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

namespace DesignLogin
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        


        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = user_text.Text;
            string passwd = password_text.Password;

          
            if(username == "" || passwd == "")
            {
                MessageBox.Show("Empty Username & Password !!");   
            }
            else
            {
                MySqlConnection connect = new MySqlConnection("datasource= localhost; database=smarthome;port=3306; username = root; password=");
                connect.Open();
                MySqlCommand query = new MySqlCommand("select * from users where username = '" + username + "' AND password = '" + passwd + "'", connect);
                MySqlDataReader reader = query.ExecuteReader();
                
                if (reader.Read())
                {
                    reader.Close();
                    query.Dispose();
                    connect.Close();
                    MessageBox.Show("Welcome back !!");
                    this.Hide();
                    Drag drag = new Drag();
                    drag.Show();

                }
                else
                {
                    MessageBox.Show("Username And Password Are incorrect try again !!");
                }

                /*
                 * reader.Close();
                query.Dispose();
                connect.Close();
                */
            }
            
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    
}
