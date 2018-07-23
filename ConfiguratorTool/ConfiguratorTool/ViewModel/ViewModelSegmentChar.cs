using CommonNS.ViewModel;
using ConfiguratorTool.Helpers;
using ConfiguratorTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ConfiguratorTool.ViewModel
{
    class ViewModelSegmentChar : ViewModelBase, ITabItemViewModel
    {
        /// <summary>
        /// model data
        /// </summary>
        ConfiguratorModel m_modelData = null;

        /// <summary>
        /// Model Data
        /// </summary>
        public ConfiguratorModel ModelData
        {
            get
            { return m_modelData; }
            set
            {
                if(m_modelData != value)
                {
                    m_modelData = value;
                    RaisePropertyChanged("ModelData");
                }
            }
        }

        /// <summary>
        /// raw Image
        /// </summary>
        private BitmapSource m_RawImage = null;

        /// <summary>
        /// Raw Image
        /// </summary>
        public BitmapSource RawImage
        {
            get { return m_RawImage; }
            set
            {
                if(m_RawImage != value)
                {
                    m_RawImage = value;
                    RaisePropertyChanged("RawImage");
                }
            }
        }
    }
}
