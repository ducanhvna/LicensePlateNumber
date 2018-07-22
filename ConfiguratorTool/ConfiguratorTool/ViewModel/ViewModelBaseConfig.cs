using CommonNS.ViewModel;
using ConfiguratorTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguratorTool.ViewModel
{
    class ViewModelBaseConfig : ViewModelBase
    {
        public ConfiguratorModel ModelData { get; internal set; }
    }
}
