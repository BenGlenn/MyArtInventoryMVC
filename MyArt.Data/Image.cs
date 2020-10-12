using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArt.Data
{
    public class Image
    {
        [Key]
        public int ImageID { get; set; }
        [Required]
        public  Guid OwnerID { get; set; }
        [Required]
        public int ArtID { get; set; }
        [ForeignKey("ArtID")]
        public virtual Art Art { get; set; }
        public string ImageTitle { get; set; }
        [Required]
        public byte[] ImageData { get; set; }
    }
}
