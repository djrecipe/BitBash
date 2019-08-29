using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abaci.JPI.Coinbase.Tests
{
    [TestClass]
    public class CoinbaseAuthenticationTests
    {
        private CoinbaseAuthenticationFactory authFactory = null;
        [TestInitialize]
        public void TestInitialize()
        {
            this.authFactory = new CoinbaseAuthenticationFactory();
        }
        [TestMethod]
        public void TestRetrievalTemporaryCode()
        {
            string text = this.authFactory.RequestTemporaryCode();
            Console.WriteLine(text);
        }
    }
}
