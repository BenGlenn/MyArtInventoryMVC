using MyArt.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArt.Model
{
    public class SaleCreate
    {
      
        [Required]
        [Display(Name = "Art")]
        public int ArtID { get;  set; }

        [Required]
        [Display(Name = "Client")]
        public int ClientID { get; set; }

        [Required]
       
        public string Location { get; set; }

        [Required]
        [Display(Name = "Art Value")]
        public decimal Price { get; set; }
        
        [Required]
        [Display(Name = "Price")]
        public decimal SellingPrice { get; set; }

        [Required]
        [Display(Name = "Fee")]
        public decimal VenderCommission { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime DateOfTransaction { get; set; }
    }

    public class SaleListItem
    {

       
        public int SaleID { get; set; }
        public int ArtID { get; set; }
        public int ClientID { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal VenderCommission { get; set; }
        public DateTime DateOfTansaction { get; set; }
        //public Art Art { get; set; }
        public  string Size { get; set; }
    }

    public class SaleDetail
    {
        public int SaleID { get; set; }
        public int ArtID { get; set; }
        public int ClientID { get; set; }
        [Display(Name = "Client")]
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal VenderCommission { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Date")]
        public DateTime DateOfTransaction { get; set; }
    }

    public class SaleEdit
    {
        public int SaleID { get; set; }
        public int ArtID { get; set; }
        public int ClientID { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal VenderCommission { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime DateOfTransaction { get; set; }
    }

   
}
