using System;
using System.Text;
using System.Collections.Generic;
using Abaci.JPI.Tests.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abaci.JPI.Tests
{
    /// <summary>
    /// Summary description for TestRemovePayloadFactory
    /// </summary>
    [TestClass]
    public class TestRemovePayloadFactory
    {
        public TestRemovePayloadFactory()
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
        public void TestPayloadRetrievalStub()
        {
            // expected
            string root_path = "https://abaci.jpi.tests";
            string sub_path = "testpayloadretrieval";
            string path = string.Format("{0}/{1}", root_path, sub_path);
            string payload_str = "{\"data\": [\n {\"content\": \"test 1\"\n}, {\"content\": \"test 2\"\n}]}";
            Dictionary<string, string> payloads = new Dictionary<string, string>()
            {
                {path, payload_str}
            };
            // create factory and endpoint
            RemotePayloadFactoryStub factory = new RemotePayloadFactoryStub("https://abaci.jpi.tests", payloads);
            // retrieve payload
            List <TestPayload> payload = factory.Get<List<TestPayload>>();
            // test
            Assert.AreEqual(2, payload.Count, "Payload count mismatch");
            Assert.AreEqual("test 1", payload[0].Content);
            Assert.AreEqual("test 2", payload[1].Content);
        }
    }
}
