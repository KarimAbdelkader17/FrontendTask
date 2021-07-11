using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersWpfApp.Helpers
{
    public  class UsersDataContext
    {
        public List<UserInfo> UsersInfo { get; set; }

        private static UsersDataContext ContextInstance;
        private UsersDataContext()
        {
            UsersInfo = new List<UserInfo>();
        }

        public static UsersDataContext GetInstance()
        {
            if (ContextInstance == null)
                ContextInstance = new UsersDataContext();
            return ContextInstance;
        }

       
    }
}
