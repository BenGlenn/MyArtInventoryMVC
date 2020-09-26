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
        public string Loccation { get; set; }

        [Required]
        [Display(Name = "Art Value")]
        public int ValuedAt { get; set; }

        [Required]
        [Display(Name = "Selling Price")]
        public int SellingPrice { get; set; }

        [Required]
        [Display(Name = "Vender Fee")]
        public int VenderCommission { get; set; }

        [Required]
        [Display(Name = "Date of Sale")]
        public DateTime DateOfTransaction { get; set; }
    }

    public class SaleListItem
    {
        public int SaleID { get; set; }
        public int ArtID { get; set; }
        public int ClientID { get; set; }
        public string Location { get; set; }
        public int ValuedAt { get; set; }
        public int SellingPrice { get; set; }
        public int VenderCommission { get; set; }
        public DateTime DateOfTansaction { get; set; }
        //public Art Art { get; set; }
        public  string Size { get; set; }



    }
}
