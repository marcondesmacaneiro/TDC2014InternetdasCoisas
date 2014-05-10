using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetoKinect
{
    
    public partial class MainWindow : Window
    {
        private bool MaoDireita;
        private bool MaoEsquerda;
        private bool PeDireito;
        private bool PeEsquerdo;
        private KinectSensor kinect;


        public MainWindow()
        {
            InitializeComponent();
            inicializar();
        }

        private void inicializar()
        {
            this.kinect = InicializadorKinect(10);
            this.kinect.SkeletonFrameReady += KinectEvent;
            this.kinect.SkeletonStream.Enable();
        }


        public static KinectSensor InicializadorKinect(int anguloInicialElevacao)
        {
            KinectSensor kinect = KinectSensor.KinectSensors.First(sensor => sensor.Status == KinectStatus.Connected);
            kinect.Start();
            kinect.ElevationAngle = anguloInicialElevacao;
            return kinect;
        }

        private void KinectEvent(object sender, SkeletonFrameReadyEventArgs e)
        {
            using (SkeletonFrame quadroAtual = e.OpenSkeletonFrame())
            {

                //delay ??
                if (quadroAtual != null)
                {
                    ExecutaComandos(quadroAtual );
                }
            }
        }

        private void ExecutaComandos(SkeletonFrame frame)
        {
            Skeleton[] esqueletos = new Skeleton[6];
            frame.CopySkeletonDataTo( esqueletos );
            Skeleton usuario = esqueletos.FirstOrDefault(esqueleto => esqueleto.TrackingState == SkeletonTrackingState.Tracked);

            if (usuario != null) 
            {
                Joint head      = usuario.Joints[JointType.Head];
                Joint HandRight = usuario.Joints[JointType.HandRight];
                Joint HandLeft  = usuario.Joints[JointType.HandLeft];

                Joint FootRight = usuario.Joints[JointType.FootRight];
                Joint FootLeft  = usuario.Joints[JointType.FootLeft];
                Joint KneeRight = usuario.Joints[JointType.KneeRight];
                Joint KneeLeft  = usuario.Joints[JointType.KneeLeft];

                
                bool isHandRight = HandRight.Position.Y > head.Position.Y;
                bool isHandLeft  = HandLeft.Position.Y  > head.Position.Y;
                bool isFootRight = FootRight.Position.Y > KneeLeft.Position.Y;
                bool isFootLeft  = FootLeft.Position.Y  > KneeRight.Position.Y;
                

                if (isHandRight != MaoDireita)
                {
                    MaoDireita = isHandRight;
                    if (MaoDireita)
                    {
                        String url = "http://192.168.100.110?ve=1";
                        WebBrowser wb = new WebBrowser();
                        wb.Navigate(url);
                    }
                    else
                    {
                        String url = "http://192.168.100.110?ve=0";
                        WebBrowser wb = new WebBrowser();
                        wb.Navigate(url);
                    }
                }


                if (isHandLeft != MaoEsquerda)
                {
                    MaoEsquerda = isHandLeft;
                    if (MaoEsquerda)
                    {
                        String url = "http://192.168.100.110?vd=1";
                        WebBrowser wb = new WebBrowser();
                        wb.Navigate(url);
                    }
                    else
                    {
                        String url = "http://192.168.100.110?vd=0";
                        WebBrowser wb = new WebBrowser();
                        wb.Navigate(url);
                    }
                }
                if (isFootRight != PeDireito)
                {
                    PeDireito = isFootRight;
                    if (PeDireito)
                    {
                        String url = "http://192.168.100.110?am=1";
                        WebBrowser wb = new WebBrowser();
                        wb.Navigate(url);
                    }
                    else
                    {
                        String url = "http://192.168.100.110?am=0";
                        WebBrowser wb = new WebBrowser();
                        wb.Navigate(url);
                    }
                }
                /*if (isFootLeft != PeEsquerdo)
                {
                    PeEsquerdo = isFootLeft;
                    if (PeEsquerdo)
                    {
                        String url = "http://192.168.100.110?am=1";
                        WebBrowser wb = new WebBrowser();
                        wb.Navigate(url);
                    }
                    else
                    {
                        String url = "http://192.168.100.110?am=0";
                        WebBrowser wb = new WebBrowser();
                        wb.Navigate(url);
                    }
                }*/

            }
        }
    }
}