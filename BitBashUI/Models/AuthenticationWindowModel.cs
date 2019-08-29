using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Abaci.BitBash.UI.Annotations;

namespace Abaci.BitBash.UI.Models
{
    public class AuthenticationWindowModel : INotifyPropertyChanged
    {
        public string URL { get; set; } =
            @"https://www.coinbase.com/oauth/authorize?response_type=code&client_id=2fe7ae2ade4d2b941f4598ddf3b6fa8d8f111ed9500b03f7480617bae9fdc782";
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string property_name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property_name));
        }
    }
}
