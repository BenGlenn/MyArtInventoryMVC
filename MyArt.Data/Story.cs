using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArt.Data
{
    public class Story
    {
        [Key]
        public int StoryId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [ForeignKey("Art")]
        public int ArtID { get; set; }
        public virtual Art Art { get; set; }

        [Required]
        [Display(Name = "Add Your Story Here")]
        public string Text { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
