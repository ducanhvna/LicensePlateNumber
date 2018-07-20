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
        /// <summary>
        /// Setup related library VLC
        /// </summary>
        /// <param name="directory">VLC 32 bit folder path in computer</param>
        public static void ConfigVLC(string directory)
        {
            //replace this path with an appropriate one
            //new DirectoryInfo(@"c:\Program Files (x86)\VideoLAN\VLC\");
            // Assign directory tor variable vlc Directory
            vlcDirectory = new DirectoryInfo(directory);
        }
        private static DirectoryInfo vlcDirectory;

        /// <summary>
        /// Constructor
        /// </summary>
        public CameraViewerWPF()
        {
            // InitializeComponent
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

        /// <summary>
        /// ConfigCamera
        /// </summary>
        /// <param name="uri"></param>
        public void ConfigCamera(string uri)
        {
            // Set uri to carmerURi
            cameraURi = new Uri(uri);
        }
        #endregion

        #region Show camera
        private Uri cameraURi = null;

        /// <summary>
        /// ShowCamera
        /// </summary>
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

        /// <summary>
        /// Take snap shot of camera and save to filePath
        /// </summary>
        /// <param name="filePath">file Path</param>
        /// <returns>
        /// CameraState
        /// </returns>
        public CameraState Capture(string filePath)
        {
            try
            {
                // Call TakeSnapshot
                vlcPlayer.MediaPlayer.TakeSnapshot(filePath);

                // Success
                return CameraState.Success;
            }
            catch
            {
                // Failure
                return CameraState.CaptureError;
            }
        }
        #endregion
    }
}
