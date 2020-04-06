using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProjectPetey.Models
{
    public class AccountViewModel
    {
    }

    public class ViewModel
    {
        public int Pid { get; set; }
        public string Pname { get; set; }
        public string Pimages { get; set; }
        public decimal? Pprice { get; set; }

        public int Prid { get; set; }
        public string Prname { get; set; }
        public string Primages { get; set; }
        public decimal? Prprice { get; set; }


        public int Tid { get; set; }
        public string Tname { get; set; }
        public string Timages { get; set; }
        public decimal? Tprice { get; set; }

        public int order_id { get; set; }
        public DateTime? time { get; set; }
        public int Order_Id { get; internal set; }
    }

    class MyViewModel
    {
        public List<ViewModel> SemesterFaculties { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }


    public class RegisterViewModel
    {

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string e_mail { get; set; }

        [Required]
        [Display(Name = "Fullname")]
        public string Fullname { get; set; }


        [Required]
        [Display(Name = "Sex")]
        public string Sex { get; set; }

        [Required]
        [Display(Name = "Birthdate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }


        [Required]
        [Display(Name = "Phone_No")]
        public string Phone_No { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "iframe")]
        public string iframe { get; set; }
    }


    public class RegistershopViewModel
    {

        [Required]
        [Display(Name = "Shop_Name")]
        public string Shop_Name { get; set; }


        [Required(ErrorMessage = "Please select a product")]
        [Display(Name = "Name_Bank")]
        public string Name_Bank { get; set; }
        public System.Web.Mvc.SelectList BankName { get; set; }

        [Required]
        [Display(Name = "Name_Owner")]
        public string Fullname { get; set; }


        [Required]
        [Display(Name = "Id_Bank")]
        public string Id_Bank { get; set; }

        [Required]
        [Display(Name = "Card_No")]
        public string Card_No { get; set; }

        [Required]
        [Display(Name = "Images")]
        public string Images { get; set; }

        [Required]
        [Display(Name = "UserType")]
        public string UserType { get; set; }

    }
}
