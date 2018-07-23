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
using ConfiguratorTool.Helpers;

namespace ConfiguratorTool.ViewModel
{
    internal class ViewModelBaseConfig : ViewModelBase, ITabItemViewModel
    {
        private BitmapSource m_image = null;
        /// <summary>
        /// Constructor
        /// </summary>
        public ViewModelBaseConfig()
        {
        }
        public ConfiguratorModel ModelData { get; set; }


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
