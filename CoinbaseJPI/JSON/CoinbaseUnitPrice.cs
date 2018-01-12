using Newtonsoft.Json;

namespace Abaci.JPI.Coinbase.JSON
{
    [JsonObject(MemberSerialization.OptIn)]
    [Endpoint(SubPath = "prices", SingleToken = "data")]
    public class CoinbaseUnitPrice
    {
        #region Instance Properties
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("amount")]
        private string _Price
        {
            set
            {
                double dbl_value = 0.0;
                double.TryParse(value, out dbl_value);
                this.Price = dbl_value;
                return;
            }
        }
        public double Price { get; set; }
        #endregion
    }
}
