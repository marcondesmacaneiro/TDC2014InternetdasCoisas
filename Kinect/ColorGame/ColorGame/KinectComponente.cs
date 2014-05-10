using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace ColorGame
{
    class KinectComponente
    {

        public KinectComponente()
        {
        }

        public KinectComponente(int angulo)
        {
            InicializadorKinect(angulo);
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
