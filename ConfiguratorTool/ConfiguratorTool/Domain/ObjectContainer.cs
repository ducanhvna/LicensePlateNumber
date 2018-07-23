using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ConfiguratorTool.Domain
{
    class ObjectContainer:IContainer
    {
        private UserControl m_PropertyView = null;
        private UserControl m_EditView = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public ObjectContainer()
        {
            // Initialize sub groups
            SubGroups = new ObservableCollection<ObjectContainer>();
        }
        /// <summary>
        /// Key
        /// </summary>
        public int Key { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// SubGroups
        /// </summary>
        public ObservableCollection<ObjectContainer> SubGroups { get; set; }

        /// <summary>
        /// Property View
        /// </summary>
        public UserControl PropertyView
        {
            get {
                return m_PropertyView;
            }
            set
            {
                if(m_PropertyView != value)
                {
                    m_PropertyView = value;
                }
            }
        }

        /// <summary>
        /// Edit View
        /// </summary>
        public UserControl EditView
        {
            get {
                return m_EditView;
            }
            set
            {
                if(m_EditView != value)
                {
                    m_EditView = value;
                }
            }
        }
    }
}
