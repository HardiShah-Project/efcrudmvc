using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFCRUDMVC.Enums
{
    public enum City
    {
        Ahmedabad,
        Rajkot,
        Baroda,
        Surat,
        Delhi,

    }
}

namespace EFCRUDMVC.Models
{
    public class CheckBoxRequired : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is bool)
            {
                return (bool)value;
            }

            return false;
        }
    }

    public class AgeValidation : ValidationAttribute
    {
        int _minimumAge;
        int _maximumAge;

        public AgeValidation(int minimumAge, int maximumAge)
        {
            _minimumAge = minimumAge;
            _maximumAge = maximumAge;
        }

        public override bool IsValid(object value)
        {
            int age = 0;
            age = DateTime.Now.Year - Convert.ToDateTime(value).Year;
            if (age >= _minimumAge && age <= _maximumAge)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class tblUsers
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        public string Gender { get; set; }

        [Display(Name = "I accept the above terms and conditions.")]
        [CheckBoxRequired(ErrorMessage = "Please accept the terms and condition.")]
        public bool Privacy { get; set; }

        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Birthdate is Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [AgeValidation(18, 75, ErrorMessage = "Age must be between 18 - 75.")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "PhoneNo is Required")]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        public int LoginId { get; set; }
        public virtual Login Login { get; set; }

    }
}