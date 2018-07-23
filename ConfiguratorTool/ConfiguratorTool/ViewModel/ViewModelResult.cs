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
    class ViewModelResult : ViewModelBase, ITabItemViewModel
    {
        ConfiguratorModel m_modelData = null;
        /// <summary>
        /// ModelData
        /// </summary>
        public ConfiguratorModel ModelData
        {
            get
            {
                return m_modelData;
            }
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
        /// RawImage
        /// </summary>
        public BitmapSource RawImage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
