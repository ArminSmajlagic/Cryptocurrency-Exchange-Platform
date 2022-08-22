using database.trading.DB_Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.trading.DB_Models.Security
{
    public class user_confirmation
    {
        [Key]
        public int id { get; set; }
        public string code { get; set; }
        public int userId { get; set; }
        public user user { get; set; }
        public DateTime timeStamp { get; set; }
        public bool confirmed { get; set; }
    }
}
