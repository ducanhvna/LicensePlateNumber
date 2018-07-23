﻿using CommonNS.Helpers;
using CommonNS.ViewModel;
using ConfiguratorTool.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using ConfiguratorTool.Helpers;
using ConfiguratorTool.Domain;
using System.Collections.ObjectModel;
using ConfiguratorTool.View;

namespace ConfiguratorTool.ViewModel
{
    internal class ViewModelBaseConfig : ViewModelBase, ITabItemViewModel
    {
        private BitmapSource m_image = null;
        private ObservableCollection<ObjectContainer> m_Properties;
        private ObjectContainer m_SelectedContainer;
        private RelayCommand m_SelectedContainerCommand;

        /// <summary>
        /// Constructor
        /// </summary>
        public ViewModelBaseConfig()
        {
            // Initialize Properties
            InitalizeRawImageProperties();

            // Initialize SelectContainer command
            SelectContainerCommand = new RelayCommand(SelectContainer);
        }
        #region Selected Container Area

        /// <summary>
        /// SelectContainerCommand
        /// </summary>
        public RelayCommand SelectContainerCommand {
            get
            {
                return m_SelectedContainerCommand;
            }

            internal set {
                if(m_SelectedContainerCommand != value)
                {
                    m_SelectedContainerCommand = value;
                    RaisePropertyChanged("SelectContainerCommand");
                }
                ; } }

        /// <summary>
        /// SelectContainerCommand execution
        /// </summary>
        /// <param name="parameter"></param>
        private void SelectContainer(object parameter)
        {
            var item = parameter as ObjectContainer;
            if(item == null)
            {
                return;
            }

            SelectedContainer = item;

        }
        public ObjectContainer SelectedContainer
        {
            get
            {
                return m_SelectedContainer;
            }
            set
            {
                if(m_SelectedContainer != value)
                {
                    m_SelectedContainer = value;
                    RaisePropertyChanged("SelectedContainer");
                }
            }
        }
        #endregion
        #region Properties Area 

        /// <summary>
        /// Initialize Raw Image Properties
        /// </summary>
        private void InitalizeRawImageProperties()
        {
            // Initialize Object
            RawImageProperties = new ObservableCollection<ObjectContainer>();

            // Initalize Outline Container
            var OutlineContainer = new ObjectContainer()
            {
                Name = "Outline",
                PropertyView = new RawImageOutlinePropertyView()
            };

            // Initalize License Plate Container
            var licensePlateContaner = new ObjectContainer()
            {
                Name = "License Plate Number"
            };

            // Dumy Entry Data For Number Inspection
            var licenseplateArea1 = new ObjectContainer()
            {
                Name = "Area 1"
            };

            
            // Add Contaners
            RawImageProperties.Add(OutlineContainer);
            RawImageProperties.Add(licensePlateContaner);

            // Add license plate to container
            licensePlateContaner.SubGroups.Add(licenseplateArea1);

        }

        /// <summary>
        /// Properties of Raw Image
        /// </summary>
        public ObservableCollection<ObjectContainer> RawImageProperties
        {
            get
            {
                return m_Properties;
            }
            set
            {
                if(m_Properties != value)
                {
                    m_Properties = value;
                    RaisePropertyChanged("RawImageProperties");
                }
            }
        }
        #endregion
        public ConfiguratorModel ModelData { get; set; }


        public BitmapSource RawImage
        {
            get
            {
                return m_image;
            }
            set
            {
                if(m_image != value)
                {
                    m_image = value;
                    RaisePropertyChanged("RawImage");
                }
            }
        }
    }
}