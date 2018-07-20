using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Vlc.DotNet.Forms;

namespace LibOCR
{
    public partial class CameraViewer : UserControl
    {
        private static DirectoryInfo vlcDirectory;
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
        public CameraViewer()
        {
            InitializeComponent();

            this.vlcPlayer = new VlcControl();
            ((System.ComponentModel.ISupportInitialize)(this.vlcPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // vlcPlayer
            // 
            this.vlcPlayer.BackColor = System.Drawing.Color.Black;
            this.vlcPlayer.Location = new System.Drawing.Point(17, 4);
            this.vlcPlayer.Name = "vlcPlayer";
            this.vlcPlayer.Size = new System.Drawing.Size(255, 189);
            this.vlcPlayer.Spu = -1;
            this.vlcPlayer.TabIndex = 0;
            this.vlcPlayer.Text = "vlcControl1";
            this.vlcPlayer.VlcLibDirectory = null;
            this.vlcPlayer.VlcMediaplayerOptions = null;
           
            this.Controls.Add(vlcPlayer);
            this.vlcPlayer.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
                   | AnchorStyles.Left)
                   | AnchorStyles.Right)));
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
                vlcPlayer.VlcLibDirectory = vlcDirectory;

                vlcPlayer.EndInit();

                // vlcPlayer.MediaPlayer.Play(new Uri("rtsp://192.168.0.101/onvif1"));
                if (cameraURi != null)
                {
                    vlcPlayer.Play(cameraURi);
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
        public new CameraState Capture(string filePath)
        {
            try
            {
                // Call TakeSnapshot
                vlcPlayer.TakeSnapshot(filePath);

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
