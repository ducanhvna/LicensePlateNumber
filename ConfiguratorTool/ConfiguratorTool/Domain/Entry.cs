using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ConfiguratorTool.Domain
{
    class Entry: IContainer
    {
        public int Key { get; set; }
        public string Name { get; set; }

        public UserControl PropertyView
        {
            get { throw new NotImplementedException(); }
            set
            {
                throw new NotImplementedException();
            }
        }
        public UserControl EditView
        {
            get { throw new NotImplementedException(); }
            set
            {
                throw new NotImplementedException();
            }
        }

    }
}
