using System.Collections.Generic;
using Abaci.JPI.Coinbase.JSON;

namespace Abaci.JPI.Coinbase
{
    public class CoinbaseJPI
    {
        private RemotePayloadFactory payloadFactory = new RemotePayloadFactory("https://api.coinbase.com/v2");

        public List<CoinbaseCurrency> Get()
        {
            return this.payloadFactory.Get<List<CoinbaseCurrency>>();
        }
    }
}
