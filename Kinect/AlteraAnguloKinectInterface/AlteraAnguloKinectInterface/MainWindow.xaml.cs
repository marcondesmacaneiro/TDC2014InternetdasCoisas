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
using Microsoft.Kinect;

namespace AlteraAnguloKinectInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private KinectSensor kinect;

        public MainWindow()
        {
            InitializeComponent();
            this.kinect = InicializadorKinect(0);
        }

        

        private void  AtualizarValores()
        {
            this.kinect.ElevationAngle = Convert.ToInt32(slider.Value);
            label.Content = this.kinect.ElevationAngle;
            

        }

        private void slider_DragCompleted(object sender, EventArgs e)
        {
            AtualizarValores();
        }

        public static KinectSensor InicializadorKinect(int anguloInicialElevacao)
        {
            KinectSensor kinect = KinectSensor.KinectSensors.First(sensor => sensor.Status == KinectStatus.Connected);
            kinect.Start();
            kinect.ElevationAngle = anguloInicialElevacao;
            return kinect;
        }

    }
}
