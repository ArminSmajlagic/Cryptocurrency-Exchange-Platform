using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modeli.trading.Security.Requests
{
    public class ConfirmationRequest
    {
        public int user_id { get; set; }
        public string code { get; set; }
    }
}
