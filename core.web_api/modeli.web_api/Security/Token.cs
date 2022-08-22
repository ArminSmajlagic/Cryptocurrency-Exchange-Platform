using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modeli.trading.Security;
public class Token
{
    public int token_id { get; set; }
    public string? value { get; set; }
    public int user_id { get; set; }
    public DateTime issued { get; set; }
    public DateTime expires { get; set; }
    public IEnumerable<string>? allowed_scopes { get; set; }
    public string? error { get; set; }
}

