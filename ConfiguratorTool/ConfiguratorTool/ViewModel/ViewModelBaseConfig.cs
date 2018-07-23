using CommonNS.Helpers;
using CommonNS.ViewModel;
using ConfiguratorTool.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;

namespace ConfiguratorTool.ViewModel
{
    class ViewModelBaseConfig : ViewModelBase
    {
        private BitmapSource m_image = null;
        /// <summary>
        /// Constructor
        /// </summary>
        public ViewModelBaseConfig()
        {
            // Initialize open image command
            OpenImageCommand = new RelayCommand(OpenImage);
        }
        public ConfiguratorModel ModelData { get; internal set; }

        #region Open image Diaglog
        private RelayCommand m_openImageCommand;
        /// <summary>
        /// Open Image Command
        /// </summary>
        public RelayCommand OpenImageCommand
        {
            get
            {
                return m_openImageCommand;
            }
            internal set
            {
                if (m_openImageCommand != value)
                {

                    m_openImageCommand = value;
                    RaisePropertyChanged("OpenImageCommand");
                }
            }
        }

        /// <summary>
        /// Open Image Command excution
        /// </summary>
        /// <param name="param"></param>
        private void OpenImage(object param)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            // case User click OK
            if (dlg.ShowDialog() == true)
            {
                string selectedFileName = dlg.FileName;
                RawImage = new BitmapImage(new Uri(selectedFileName));
            }
        }
        #endregion

        public BitmapSource RawImage
        {
            get
            {
                return m_image;
            }
            set
            {
                if(m_image != value)
                {
                    m_image = value;
                    RaisePropertyChanged("RawImage");
                }
            }
        }
    }
}
