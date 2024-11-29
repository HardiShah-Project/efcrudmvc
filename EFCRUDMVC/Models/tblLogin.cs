using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFCRUDMVC.Models
{
    public class tblLogin
    {
        public tblLogin()
        {
            Users = new HashSet<tblUsers>();
        }
        public int LoginId { get; set; }

        [Required(ErrorMessage = "User Name is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Passowrd is Required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Invalid Password.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Passowrd is Required")]
        [Compare("Password", ErrorMessage = "Confirm Password doesn't match, Type again!")]
        public string ConfirmPassword { get; set; }
        public virtual ICollection<tblUsers> Users { get; set; }
    }
}