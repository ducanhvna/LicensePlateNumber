using System;
using System.Collections.Generic;
using System.IO;
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

namespace LibOCR
{
    /// <summary>
    /// Interaction logic for CameraViewerWPF.xaml
    /// </summary>
    public partial class CameraViewerWPF : UserControl
    {
        public static void ConfigVLC(string directory)
        {
            //replace this path with an appropriate one
            //new DirectoryInfo(@"c:\Program Files (x86)\VideoLAN\VLC\");
            vlcDirectory = new DirectoryInfo(directory);
        }
        private static DirectoryInfo vlcDirectory;
        public CameraViewerWPF()
        {
            InitializeComponent();
            Focusable = true;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && e.ClickCount == 2)
            {
                MessageBox.Show("Double click");
            }
        }
        #region Config camera
        public void configCamera(string uri)
        {
            cameraURi = new Uri(uri);
        }
        #endregion

        #region Show camera
        private Uri cameraURi = null;
        public void ShowCamera()
        {
            if (vlcDirectory != null)
            {
                vlcPlayer.MediaPlayer.VlcLibDirectory = vlcDirectory;

                vlcPlayer.MediaPlayer.EndInit();

                // vlcPlayer.MediaPlayer.Play(new Uri("rtsp://192.168.0.101/onvif1"));
                if (cameraURi != null)
                {
                    vlcPlayer.MediaPlayer.Play(cameraURi);
                }
            }
        }
        #endregion
    }
}
