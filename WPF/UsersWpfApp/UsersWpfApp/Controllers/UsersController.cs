using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using UsersWpfApp.Helpers;

namespace UsersWpfApp
{
    public class UsersController : ApiController
    {
       
        [HttpPost]
        public void Post([FromBody] UserInfo user)
        {
            var userInfo = UsersDataContext.GetInstance().UsersInfo.FirstOrDefault(u => u.page == user.page);
            if (userInfo == null)
                UsersDataContext.GetInstance().UsersInfo.Add(user);
        }


    }
}
