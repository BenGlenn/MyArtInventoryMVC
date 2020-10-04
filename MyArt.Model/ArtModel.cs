using MyArt.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArt.Model
{
    public class ArtCreate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public Style Style { get; set; }
        [Required]
        public Medium Medium { get; set; }
        [Required]
        public string Surface { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Art Location")]
        public string Location { get; set; }
        [Required]
        [Display(Name = "Mark Sold")]
        public bool Sold { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Creation")]
        public DateTime DateOfCreation { get; set; }
        [Display(Name = "Story")]
        public string Note { get; set; }

    }

    public class ArtListItem
    {
        public int ArtID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Date of Creation")]
        public DateTime DateOfCreation { get; set; }
        public bool Sold { get; set; }

    }

    public class ArtDetail
    {
        public int ArtID { get; set; }
        public string Title { get; set; }

        [Display(Name = "Date of Creation")]
        public DateTime DateOfCreation { get; set; }

        public Style Style { get; set; }

        public Medium Medium { get; set; }

        public string Surface { get; set; }

        public string Size { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Art location?")]
        public string Location { get; set; }

        public bool Sold { get; set; }
        [Display(Name = "Story")]
        public string Note { get; set; }
    }

    public class ArtNoteDetial
    {
        public int ArtID { get; set; }
        public string Title { get; set; }

        public string Note { get; set; }
    }

    public class ArtEdit
    {
        public int ArtID { get; set; }

        public string Title { get; set; }

        public Style Style { get; set; }

        public Medium Medium { get; set; }

        public string Surface { get; set; }

        public string Size { get; set; }

        public decimal Price { get; set; }

        public string Location { get; set; }

        public bool Sold { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Creation")]
        public DateTime DateOfCreation { get; set; }
        [Display(Name = "Story")]
        public string Note { get; set; }
    }

    public class StoryEdit
    {
        public int ArtID { get; set; }
        public string Title { get; set; }
        [Display(Name = "Story")]
        public string Note { get; set; }
    }

    public class GetArtPriceTotal
    {

        public decimal Price { get; set; }

     
    }


}
