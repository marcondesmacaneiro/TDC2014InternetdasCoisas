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
using System.Windows.Threading;

namespace KinectAcelerometro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {

        private KinectSensor kinect;

        public MainWindow()
        {
            InitializeComponent();
            this.kinect = InicializadorKinect(0);
            InicializarProcesso();
            
        }

        private void AtualizarValorTela()
        {
            Vector4 resultado = this.kinect.AccelerometerGetCurrentReading();
            labelX.Content = Math.Round(resultado.X, 3);
            labelY.Content = Math.Round(resultado.Y, 3);
            labelZ.Content = Math.Round(resultado.Z, 3);
            //kinect = InicializadorKinect(0);
            //kinect.SkeletonFrameReady += KinectEvent;
            //kinect.SkeletonStream.Enable();
        }


        public static KinectSensor InicializadorKinect(int anguloInicialElevacao)
        {
            KinectSensor kinect = KinectSensor.KinectSensors.First(sensor => sensor.Status == KinectStatus.Connected);
            kinect.Start();
            kinect.ElevationAngle = anguloInicialElevacao;
            return kinect;
        }

        private void InicializarProcesso()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            AtualizarValorTela();
        }
    }
}
