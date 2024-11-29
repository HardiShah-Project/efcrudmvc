using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFCRUDMVC.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public bool Privacy { get; set; }
        public string City { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public int LoginId { get; set; }

        public virtual Login Login { get; set; }
    }
}
