using CommonNS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ConfiguratorTool.ViewModel
{
    class ViewModelBaseConfigEditView : ViewModelBase
    {
        public BitmapSource RawImage { get; internal set; }
    }
}
