using Microsoft.Kinect;
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

namespace ColorGame
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

        /**
         * Gera as frequencias 1 - 50
         */
        public static void geraFrequencia(int level)
        {
            System.Console.WriteLine("LEVEL: "+ level );
            Random rdn = new Random();
            for (int i = 0; i <= level; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    System.Console.WriteLine(rdn.Next(3) + 1);
                }
                System.Console.WriteLine("========");    
            }
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            geraFrequencia( Convert.ToInt32(txt_level.Text) );
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            
        }


    }
}
