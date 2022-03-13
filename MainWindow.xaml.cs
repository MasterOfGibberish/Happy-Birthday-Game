using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Media;
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
using System.Windows.Threading;

namespace Not_A_Virus
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

        private void BUTTON_Click(object sender, RoutedEventArgs e)
        {
            string sqlConnection =(@"Data Source =DESKTOP-FGIOSI5\SQLEXPRESS; Initial Catalog = Biblioteka; Integrated Security=true");
            //if (sqlConnection.State == System.Data.ConnectionState.Closed)
            ////    sqlConnection.Open();
            //SqlCommand command2 = new SqlCommand("Update HappyBirday_Game set MusicCode=@Muzika", sqlConnection);

            if (Passwordas.Password !=string.Empty)
            {
                using (SqlConnection RegistrationCon = new SqlConnection(sqlConnection))
                {
                    SqlCommand command = new SqlCommand("UserAdd", RegistrationCon);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", Passwordas.Password.Trim());
                    MessageBox.Show("Sveikas" + " " + Passwordas.Password + ", Su Gimtadieniu!!\n Ir metas pazaisti zaidima", "Congratulations!");
                    Bolionai bolionai = new Bolionai();
                    bolionai.Show();
                    this.Close();
                }
            }
            
            else
            {
                MessageBox.Show("LABEL IS EMPTY!", "WARNING");
                Passwordas.Clear();
            }
           
        }
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                DispatcherTimer dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
                dispatcherTimer.Tick += dispatcherTimerTicker;
                dispatcherTimer.Start();
            }
   
        private int increment = 11;
        private void dispatcherTimerTicker(object sender, EventArgs e)
        {

            increment--;

            Animacija.Content = increment.ToString();
            if (increment == 3)
            {
                Trys.Content = Animacija.Content;
                Trys1.Content = Animacija.Content;
                Trys2.Content = Animacija.Content;

                Trys4.Content = Animacija.Content;
                Trys5.Content = Animacija.Content;
            }

            if (increment == 2)
            {
                Du.Content = Animacija.Content;
                Du1.Content = Animacija.Content;
                Du2.Content = Animacija.Content;
                Du3.Content = Animacija.Content;
                Du4.Content = Animacija.Content;
                Du5.Content = Animacija.Content;
            }

            if (increment == 1)
            {

                Vienas.Content = Animacija.Content;
                Vienas1.Content = Animacija.Content;
                Vienas2.Content = Animacija.Content;
                Vienas3.Content = Animacija.Content;
                Vienas4.Content = Animacija.Content;
                Vienas5.Content = Animacija.Content;
                Vienas6.Content = Animacija.Content;

            }
            if (increment == 1 && Passwordas.Password != "Domas")
            {
                for (int j = 0; j < 4; j++)
                {
                    SoundPlayer play = new SoundPlayer(@"C:\Users\Namai\OneDrive\Desktop\wpf\YouAreAnIdiot.wav");
                    play.Load();
                    play.Play();
                }
                MessageBox.Show("YOUR COMPUTER ENCRYPTED!", "CONGRATULATIONS");
                this.Close();

            }
        }

        private void Animacija_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Bolionai bolionai = new Bolionai();
            bolionai.Show();
            this.Close();
        }
    }
}
