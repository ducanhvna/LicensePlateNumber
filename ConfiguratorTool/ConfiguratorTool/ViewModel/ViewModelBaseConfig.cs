using CommonNS.Helpers;
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
using System.Windows.Controls;
//using System.Windows.Media;
using System.Windows.Shapes;
using openalprnet;
using System.Drawing;
using System.Drawing.Imaging;
using Rectangle = System.Drawing.Rectangle;

namespace ConfiguratorTool.ViewModel
{
    internal class ViewModelBaseConfig : ViewModelBase, ITabItemViewModel
    {
        private BitmapSource m_image = null;
        private ObservableCollection<ObjectContainer> m_Properties;
        private ObjectContainer m_SelectedContainer;
        private RelayCommand m_SelectedContainerCommand;
        private ObservableCollection<Rect> m_ListArea = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public ViewModelBaseConfig()
        {
            // Initialize Properties
            InitalizeRawImageProperties();

            // Initialize SelectContainer command
            SelectContainerCommand = new RelayCommand(SelectContainer);

            // Dumy List License Plate Area
            DumyListLicensePlateArea();
        }

        #region List License Plate Number Area
        /// <summary>
        /// Dumy list area
        /// </summary>
        private void DumyListLicensePlateArea()
        {
            ListLicensePlateArea = new ObservableCollection<Rect>()
            {
                new Rect(10,10, 30,40),

                new Rect(60,10, 30,40)
            };
        }
        /// <summary>
        /// List License Plate Area Postion
        /// </summary>
        public ObservableCollection<Rect> ListLicensePlateArea
        {
            get
            {
                return m_ListArea;
            }
            set
            {
                if(m_ListArea !=value)
                {
                    m_ListArea = value;
                    RaisePropertyChanged("ListLicensePlateArea");
                }
            }
        }
        #endregion

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
                    Angle = 0;
                    rotatedImage = m_image;
                    CropImage();
                }
            }
        }

        private int frametop;
        private int framebottom;
        private int frameleft;
        private int frameright;
        private BitmapSource rotatedImage;
        private int angle;
        private BitmapSource licenceplate;

        public BitmapSource RotatedImage
        {
            get
            {
                return rotatedImage;
            }
            set
            {
                if(rotatedImage != value)
                {
                    rotatedImage = value;
                    RaisePropertyChanged("RotatedImage");
                    CropImage();
                }
            }
        }

        public int Angle
        {
            get
            {
                return angle;
            }
            set
            {
                if (angle != value)
                {
                    RaisePropertyChanged("Angle");
                    //DoTheRotation();
                }
            }
        }
        public BitmapSource LicencePlate
        {
            get { return licenceplate; }
            set
            {
                if(licenceplate != value)
                {
                    licenceplate = value;
                    RaisePropertyChanged("LicencePlate");
                    Regconize();
                }
            }
        }
        Bitmap GetBitmap(BitmapSource source)
        {
            Bitmap bmp = new Bitmap(
              source.PixelWidth,
              source.PixelHeight,
              PixelFormat.Format32bppPArgb);
            BitmapData data = bmp.LockBits(
              new Rectangle(System.Drawing.Point.Empty, bmp.Size),
              ImageLockMode.WriteOnly,
              PixelFormat.Format32bppPArgb);
            source.CopyPixels(
              Int32Rect.Empty,
              data.Scan0,
              data.Height * data.Stride,
              data.Stride);
            bmp.UnlockBits(data);
            return bmp;
        }
        private void Regconize()
        {
            var alpr = new AlprNet("us", "openalpr.conf.defaults", "runtime_data");
            if (!alpr.IsLoaded())
            {
                Console.WriteLine("OpenAlpr failed to load!");
                return;
            }
            // Optionally apply pattern matching for a particular region
            alpr.DefaultRegion = "vn2";

            AlprResultsNet results = alpr.Recognize(GetBitmap( LicencePlate));
            int i = 0;
            foreach (var result in results.Plates)
            {
                Console.WriteLine("Plate {0}: {1} result(s)", i++, result.TopNPlates.Count);
                Console.WriteLine("  Processing Time: {0} msec(s)", result.ProcessingTimeMs);
                foreach (var plate in result.TopNPlates)
                {
                    Console.WriteLine("  - {0}\t Confidence: {1}\tMatches Template: {2}", plate.Characters,
                                      plate.OverallConfidence, plate.MatchesTemplate);
                }
            }


            //var alpr2 = new AlprNet("us", "openalpr.conf", "runtime_data");
            //if (!alpr2.IsLoaded())
            //{
            //    Console.WriteLine("OpenAlpr failed to load!");
            //    return;
            //}
            //// Optionally apply pattern matching for a particular region
            //alpr2.DefaultRegion = "vn";

            ////var results2 = alpr2.Recognize("123.jpg");
            //var results2 = alpr2.Recognize("77.jpg");
            //i = 0;
            //foreach (var result in results2.Plates)
            //{
            //    Console.WriteLine("Plate {0}: {1} result(s)", i++, result.TopNPlates.Count);
            //    Console.WriteLine("  Processing Time: {0} msec(s)", result.ProcessingTimeMs);
            //    foreach (var plate in result.TopNPlates)
            //    {
            //        Console.WriteLine("  - {0}\t Confidence: {1}\tMatches Template: {2}", plate.Characters,
            //                          plate.OverallConfidence, plate.MatchesTemplate);
            //    }
            //}
        }

        public void CropImage()
        {
            // Create an Image element.
            //Image croppedImage = new Image();
            //croppedImage.Width = 200;
            //croppedImage.Margin = new Thickness(5);

            // Create a CroppedBitmap based off of a xaml defined resource.
            CroppedBitmap cb = new CroppedBitmap(
               RawImage,
               new Int32Rect(30, 20, 105, 50));       //select region rect
            LicencePlate = cb;                 //set image source to cropped
        }
        //public void DoTheRotation()
        //{
        //    var image = new Canvas();
        //    image.Width = RawImage.PixelWidth;
        //    image.Height = RawImage.PixelHeight;
        //    image.Background = new ImageBrush(RawImage);
        //    image.RenderTransform = new RotateTransform(angle);
        //    RenderTargetBitmap rtb = new RenderTargetBitmap(RawImage.PixelWidth, RawImage.PixelHeight, RawImage.DpiX, RawImage.DpiY, RawImage.Format);
        //    rtb.Render(image);
        //    RotatedImage = rtb;
        //}

        public string ImagePath { get; set; }
        public int ImageHeight { get; }
        public int ImageWidth { get; }

        /// <summary>
        /// Frame Top
        /// </summary>
        public int FrameTop
        {
            get { return frametop; }
            set
            {
                if (frametop != value)
                {
                    frametop = value;
                    RaisePropertyChanged("FrameTop");
                }
            }
        }

        /// <summary>
        /// From Bottom
        /// </summary>
        public int FrameBottom
        {
            get
            {
                return framebottom;
            }
            set
            {
                if (framebottom != value)
                {
                    framebottom = value;
                    RaisePropertyChanged("FrameBottom");

                }
            }
        }

        /// <summary>
        /// Frame Left
        /// </summary>
        public int FrameLeft
        {
            get
            {
                return frameleft;
            }
            set
            {
                if (frameleft != value)
                {
                    frameleft = value;
                    RaisePropertyChanged("FrameLeft");
                }
            }
        }

        /// <summary>
        /// Frame right
        /// </summary>
        public int FrameRight
        {
            get
            {

                return frameright;
            }
            set
            {
                if (frameright != value)
                {
                    frameright = value;
                    RaisePropertyChanged("FrameRight");
                }
            }
        }
    }
}
