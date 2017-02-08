using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Backend2.ViewModels;
using System.Linq;

namespace Backend2.Controllers
{
    static class Users{
        public static List<string> users = new List<string>();
    }
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        // GET api/values
        [HttpPost]
        public void Loggin(string user)
        {
            Users.users.Add(user);
        }

        // GET api/values/5
        [HttpDelete]
        public void Logout(string user)
        {
            Users.users.Remove(user);
        }

    }
}
