using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArt.Data
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }
        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        [ForeignKey("Client")]
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }

        [Required]
        [ForeignKey("Art")]
        public int ArtID { get; set; }
        public virtual Art Art { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int ValuedAt { get; set; }
        [Required]
        public int SellingPrice  { get; set; }
        [Required]
        public int VenderCommission { get; set; }

        [Required]
        public DateTime DateOfTransaction { get; set; }
    }
}
