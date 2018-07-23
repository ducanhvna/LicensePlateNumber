using ConfiguratorTool.Domain;
using ConfiguratorTool.Model;
using ConfiguratorTool.View;
using ConfiguratorTool.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ConfiguratorTool.Helpers
{
    internal static class InternalShare
    {
        #region Selected Item Property
        internal static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.RegisterAttached(
                "SelectedItem",
                typeof(ObjectContainer),
                typeof(InternalShare),
                new PropertyMetadata(SelectedItemChange));

        private static void SelectedItemChange(DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {
            var window = d as BaseConfigView;
            if(window != null)
            {
                var selectedItem = e.NewValue as ObjectContainer;
                window.SetPropertyView(selectedItem.PropertyView);
            }
        }

        /// <summary>
        /// SetSelected Object Container
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        internal static void SetSelectedItem(UserControl target, ObjectContainer value)
        {
            target.SetValue(SelectedItemProperty, value);
        }
        #endregion
        #region Model Data Share
        /// <summary>
        /// DataShareProperty
        /// </summary>
        internal static readonly DependencyProperty DataShareProperty =
            DependencyProperty.RegisterAttached(
                "DataShare",
                typeof(ConfiguratorModel),
                typeof(InternalShare),
                new PropertyMetadata(DataShareChange));

        /// <summary>
        /// DataShareChange
        /// </summary>
        /// <param name="d">dependence object: UserControl</param>
        /// <param name="e"></param>
        private static void DataShareChange(
            DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {
            var window = d as UserControl;
            if (window != null)
            {
                var viewModel = window.DataContext as ITabItemViewModel;
                if (viewModel != null)
                {
                    viewModel.ModelData = e.NewValue as ConfiguratorModel;
                }
            }
        }

        /// <summary>
        /// SetDataShare
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        internal static void SetDataShare(UserControl target, ConfiguratorModel value)
        {
            target.SetValue(DataShareProperty, value);
        }
        #endregion

        #region Raw Image Sharing 
        public static readonly DependencyProperty ImageShareProperty =
            DependencyProperty.RegisterAttached(
                "ImageShare",
                typeof(BitmapSource),
                typeof(InternalShare),
                new PropertyMetadata(ImageShareChange));

        /// <summary>
        /// ImageShareChange
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void ImageShareChange(DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {
            var window = d as UserControl;
            if (window != null)
            {
                var viewModel = window.DataContext as ITabItemViewModel;
                if (viewModel != null)
                {
                    viewModel.RawImage = e.NewValue as BitmapSource;
                }
            }
        }

        /// <summary>
        /// SetImageShare
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        internal static void SetImageShare(UserControl target, BitmapSource value)
        {
            target.SetValue(ImageShareProperty, value);
        }
        #endregion
    }
}
