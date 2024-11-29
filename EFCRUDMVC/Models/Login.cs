using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFCRUDMVC.Models
{
    public partial class Login
    {
        public Login()
        {
            Users = new HashSet<Users>();
        }

        public int LoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
