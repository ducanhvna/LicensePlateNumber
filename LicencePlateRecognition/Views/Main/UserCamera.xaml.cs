using LibOCR;
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

namespace LicencePlateRecognition.Views.Main
{
    /// <summary>
    /// Interaction logic for UserCamera.xaml
    /// </summary>
    public partial class UserCamera : UserControl
    {
        public UserCamera()
        {
            InitializeComponent();
        }

        private void CameraViewerWPF_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CameraViewerWPF cameraViewer = (CameraViewerWPF)sender;
            cameraViewer.ShowCamera();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cameraViewer1.configCamera("rtsp://192.168.0.101/onvif1");
            cameraViewer1.ShowCamera();

            cameraViewer2.configCamera("rtsp://192.168.0.101/onvif1");
            cameraViewer2.ShowCamera();

            cameraViewer3.configCamera("rtsp://192.168.0.101/onvif1");
            cameraViewer3.ShowCamera();
        }

        private void ConfigCarmera_Click(object sender, RoutedEventArgs e)
        {
           CameraViewerWPF.ConfigVLC(@"c:\Program Files (x86)\VideoLAN\VLC\");
        }
    }
}
