using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersWpfApp.WPF.ViewModels
{
    public class UserInfoViewModel
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total_pages { get; set; }
        public int total { get; set; }

        public List<UserViewModel> data { get; set; }
    }
}
