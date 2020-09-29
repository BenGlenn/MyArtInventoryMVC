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
        public int ArtID { get; set; }

        [Required]
        public int ClientID { get; set; }

        [Required]
        [Display(Name = "Where Item Sold")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Art Value")]
        public decimal ValuedAt { get; set; }

        [Required]
        [Display(Name = "Selling Price")]
        public decimal SellingPrice { get; set; }

        [Required]
        [Display(Name = "Vender Fee")]
        public decimal VenderCommission { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfTransaction { get; set; }
    }

    public class SaleListItem
    {
        public int SaleID { get; set; }
        public int ArtID { get; set; }
        public int ClientID { get; set; }
        public string Location { get; set; }
        public decimal ValuedAt { get; set; }
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
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public decimal ValuedAt { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal VenderCommission { get; set; }
        public DateTime DateOfTransaction { get; set; }
    }

    public class SaleEdit
    {
        public int SaleID { get; set; }
        //public int ArtID { get; set; }
        //public int ClientID { get; set; }
        public string Location { get; set; }
        public decimal ValuedAt { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal VenderCommission { get; set; }
        public DateTime DateOfTransaction { get; set; }
    }

}
