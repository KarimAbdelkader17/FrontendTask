using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersWpfApp
{
    public class UserInfo
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total_pages { get; set; }
        public int total { get; set; }

        public List<User> data { get; set; }
    }
}
