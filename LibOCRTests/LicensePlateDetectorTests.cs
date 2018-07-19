using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibOCR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibOCR.Tests
{
    [TestClass()]
    public class LicensePlateDetectorTests
    {
        [TestMethod()]
        public void LicensePlateDetectorTest()
        {
            var objectTest = new LicensePlateDetector(@"D:\Downloads\LicencePlateRecognition\GUI-Prototype\testData\image002.png");
            objectTest.DetectLicensePlate()

        }
    }
}