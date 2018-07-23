using ConfiguratorTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ConfiguratorTool.Helpers
{
    interface ITabItemViewModel
    {
        /// <summary>
        /// ModelData
        /// </summary>
        ConfiguratorModel ModelData { get;  set; }

        /// <summary>
        /// Raw car image
        /// </summary>
        BitmapSource RawImage { get; set; }
    }
}
