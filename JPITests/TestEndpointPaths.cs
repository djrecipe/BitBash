using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abaci.JPI.Tests
{
    /// <summary>
    /// Summary description for TestEndpointPaths
    /// </summary>
    [TestClass]
    public class TestEndpointPaths
    {
        public TestEndpointPaths()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestEndpointPathConstruction()
        {
            // expected result
            string path1_str = "www.google.com";
            string path2_str = "subdomain1";
            string path3_str = "subdomain2";
            string expected_path = string.Format("{0}/{1}/{2}", path1_str, path2_str, path3_str);
            // create endpoint paths
            EndpointPath path1 = new EndpointPath(path1_str);
            EndpointPath path2 = new EndpointPath(path2_str, path1);
            EndpointPath path3 = new EndpointPath(path3_str, path2);
            // test
            Assert.AreEqual(expected_path, path3.GetFullPath(), "Endpoint path mismatch");
        }
    }
}
