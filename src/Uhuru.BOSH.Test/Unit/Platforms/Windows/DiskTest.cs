﻿using Uhuru.BOSH.Agent.Platforms.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Uhuru.BOSH.Agent;
using Newtonsoft.Json;
using Uhuru.BOSH.Agent.Errors;

namespace Uhuru.BOSH.Test.Unit
{
    
    
    /// <summary>
    ///This is a test class for DiskTest and is intended
    ///to contain all DiskTest Unit Tests
    ///</summary>
    [TestClass, DeploymentItem("NLog.config"), DeploymentItem("unity.config")]
    public class DiskTest
    {

        static string settings = @"{
  ""disks"": {
    ""system"": 0,
    ""ephemeral"": 1,
    ""persistent"": {
      ""344"": 2
    }
  }
}";

        /// <summary>
        ///A test for LookupDiskByCid
        ///</summary>
        [TestMethod(), TestCategory("Unit"), Timeout(30000)]
        public void TC001_LookupDiskByCidTest()
        {
            // Arrange
            Config.Settings = JsonConvert.DeserializeObject(settings);
            Config.BaseDir = @"C:\test";
            string cid = "344";
            string expected = "2";
            string actual;

            // Act
            actual = Disk.LookupDiskByCid(cid);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetDataDiskDeviceName
        ///</summary>
        [TestMethod(), TestCategory("Unit"), Timeout(30000)]
        public void TC002_GetDataDiskDeviceNameTest()
        {
            // Arrange
            Config.Settings = JsonConvert.DeserializeObject(settings);
            Config.BaseDir = @"C:\test";
            string expected = "1";
            string actual;

            // Act
            actual = Disk.GetDataDiskDeviceName;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for StorePath
        ///</summary>
        [TestMethod(), TestCategory("Unit"), Timeout(30000)]
        public void TC003_StorePathTest()
        {
            // Arrange
            Config.Settings = JsonConvert.DeserializeObject(settings);
            Config.BaseDir = @"C:\test";
            string expected = @"C:\test\store";
            string actual;

            // Act
            actual = Disk.StorePath;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for BaseDir
        ///</summary>
        [TestMethod(), TestCategory("Unit"), Timeout(30000)]
        public void TC004_BaseDirTest()
        {
            // Arrange
            Config.Settings = JsonConvert.DeserializeObject(settings);
            Config.BaseDir = @"C:\test";
            string expected = @"C:\test";
            string actual;

            // Act
            actual = Disk.BaseDir;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(), TestCategory("Unit"), Timeout(30000)]
        public void TC005_LookupDiskByCidExceptionTest()
        {
            // Arrange
            Config.Settings = JsonConvert.DeserializeObject(settings);
            Config.BaseDir = @"C:\test";
            string cid = "afasd";
            Exception expected = null;
            string actual = null;

            // Act
            try
            {
                actual = Disk.LookupDiskByCid(cid);
            }
            catch (Exception ex)
            {
                expected = ex;
            }
            
            // Assert
            Assert.IsNull(actual);
            Assert.IsNotNull(expected);
            Assert.IsInstanceOfType(expected, typeof(FatalBoshException));
            Assert.IsTrue(expected.Message.Contains("Unknown persistent disk"));
        }
    }
}
