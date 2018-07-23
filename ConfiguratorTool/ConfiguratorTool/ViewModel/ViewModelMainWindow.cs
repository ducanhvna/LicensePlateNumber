using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using CommonNS.Helpers;
using CommonNS.ViewModel;
using ConfiguratorTool.Model;
using Microsoft.Win32;

namespace ConfiguratorTool.ViewModel
{
    class ViewModelMainWindow:ViewModelBase
    {
        /// <summary>
        /// Image
        /// </summary>
        private BitmapSource m_image = null;
        /// <summary>
        /// Constructor
        /// </summary>
        public ViewModelMainWindow()
        {
            // Initialize Model
            ModelData = new ConfiguratorModel();

            // Initialize open image command
            OpenImageCommand = new RelayCommand(OpenImage);
        }

        /// <summary>
        /// Model Data
        /// </summary>
        public ConfiguratorModel ModelData {
            get {
                return m_ModelData;
            }
            set
            {
                if(m_ModelData != value)
                {
                    m_ModelData = value;
                    RaisePropertyChanged("ModelData");
                }
            }
        }

        #region Open image Diaglog
        /// <summary>
        /// open Image Command
        /// </summary>
        private RelayCommand m_openImageCommand;

        /// <summary>
        /// model Data
        /// </summary>
        private ConfiguratorModel m_ModelData;

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
        /// Open Image Command execution
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

            // Send Image to Deep Leaning Library 
            // Get List License Plate Area Loction 

            // Show All Plate Area location
        }
        #endregion
        /// <summary>
        /// Raw Image
        /// </summary>
        public BitmapSource RawImage
        {
            get
            {
                return m_image;
            }
            set
            {
                if (m_image != value)
                {
                    m_image = value;
                    RaisePropertyChanged("RawImage");
                }
            }
        }
    }
}
