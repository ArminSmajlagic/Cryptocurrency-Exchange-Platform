using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modeli.trading.Security.Verification
{
    public class UserConfirmation
    {
        public int id { get; set; }
        public string code { get; set; }
        public int userId { get; set; }
        public DateTime timeStamp { get; set; }
    }
}
