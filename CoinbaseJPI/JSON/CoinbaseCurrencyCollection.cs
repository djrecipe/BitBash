using Newtonsoft.Json;

namespace Abaci.JPI.Coinbase.JSON
{
    [JsonObject(MemberSerialization.OptIn)]
    [Endpoint(SubPath = "currencies")]
    public class CoinbaseCurrencyCollection : PayloadCollection<CoinbaseCurrency>
    {
    }
}
