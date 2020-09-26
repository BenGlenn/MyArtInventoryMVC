using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArt.Data
{
    public class Art
    {
        [Key]
        public int ArtID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string DateOfCreation { get; set; }
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
        public string Location { get; set; }
        [Required]
        public bool Sold { get; set; }

        public string Note { get; set; }
    }

    public enum Style
    {
        Abstract,
        Figurative,
        Geometric,
        Minimalist,
        Nature,
        Pop,
        Portraiture,
        Still_Life,
        Surrealist,
        Typography,
        Urban,
        Other,
    }
    public enum Medium
    {
        Oil,
        Acylic,
        Watercolor,
        Pastel,
        Photography,
        Mixed_Media,
        Pen,
        Pencil,
        Chalk,
        Markers,

    }
}

