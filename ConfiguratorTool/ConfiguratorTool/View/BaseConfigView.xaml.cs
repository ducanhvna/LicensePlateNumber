using ConfiguratorTool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConfiguratorTool.View
{
    /// <summary>
    /// Interaction logic for BaseConfigView.xaml
    /// </summary>
    public partial class BaseConfigView : UserControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BaseConfigView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// SetPropertyView
        /// </summary>
        /// <param name="propertyView"></param>
        public void SetPropertyView(UserControl propertyView)
        {
            propertyViewContent.Children.Clear();
            if(propertyView != null)
            {
                propertyViewContent.Children.Add(propertyView);
            }
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var treeView = sender as TreeView;
            if (treeView != null)
            {
                ObjectContainer selectedItem = treeView.SelectedItem as ObjectContainer;
                if(selectedItem != null)
                {
                    SetPropertyView(selectedItem.PropertyView);
                }
            }
        }
    }
}
