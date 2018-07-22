using ConfiguratorTool.Model;
using ConfiguratorTool.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ConfiguratorTool.Helpers
{
    static class InternalShare
    {
        public static readonly DependencyProperty DataShareProperty =
            DependencyProperty.RegisterAttached(
                "DataShare",
                typeof(ConfiguratorModel),
                typeof(UserControl),
                new PropertyMetadata(DataShareChange));

        private static void DataShareChange(
            DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {
            var window = d as UserControl;
            if(window!= null)
            if(window.DataContext.GetType()==typeof( ViewModelBaseConfig))
            {
                    var viewModelBaseconfig = window.DataContext as ViewModelBaseConfig;
                    viewModelBaseconfig.ModelData = e.NewValue as ConfiguratorModel;
            }
        }
    }
}
