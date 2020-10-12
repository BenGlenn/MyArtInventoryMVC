using MyArt.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArt.Model
{
    public class ClientCreate
    {
       
        public bool Collector { get; set; }
        [Required]
        [Display(Name = "Fisrt")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
        
        public string Address { get; set; }

        public string City { get; set; }

        public State State { get; set; }
        [Display(Name = "Zip")]
        public int ZipCode { get; set; }


    }

    public class ClientListItem
    {
        [Display(Name = "Client ID")]
        public int ClientID { get; set; }
        public bool Collector { get; set; }
        [Display(Name = "Fisrt Name")]
        public string FirstName  { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }

    public class ClientDetail
    {
        [Display(Name = "Client ID")]
        public int ClientID { get; set; }
        public bool Collector { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public State State { get; set; }
        [Display(Name = "Zip")]
        public int ZipCode { get; set; }

    }

    public class ClientEdit
    {
        [Display(Name = "Client ID")]
        public int ClientID { get; set; }
        public bool Collector { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "First Name")]
        public string LastName { get; set; }
        
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
   
        public string Address { get; set; }
        public string City { get; set; }

        public State State { get; set; }
        [Display(Name = "Zip")]
        public int ZipCode { get; set; }
    }
}
