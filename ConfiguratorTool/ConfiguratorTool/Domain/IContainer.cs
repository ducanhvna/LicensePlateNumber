using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ConfiguratorTool.Domain
{
    /// <summary>
    /// Interface Container
    /// </summary>
    interface IContainer
    {
        /// <summary>
        /// Key
        /// </summary>
        int Key { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Property View
        /// </summary>
        UserControl PropertyView { get; set; }

        /// <summary>
        /// Edit View
        /// </summary>
        UserControl EditView { get; set; }
    }
}
