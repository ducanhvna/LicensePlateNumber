using LibOCR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraWindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();

        }

        private void bntConfigVLC_Click(object sender, EventArgs e)
        {
            CameraViewer.ConfigVLC(@"c:\Program Files (x86)\VideoLAN\VLC\");
        }

        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            cameraViewer1.ConfigCamera("rtsp://192.168.0.101/onvif1");
            cameraViewer1.ShowCamera();
        }

        private void btnCaprture_Click(object sender, EventArgs e)
        {
            cameraViewer1.Capture("test.png");
        }
    }
}
