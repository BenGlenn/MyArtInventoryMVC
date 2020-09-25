﻿using MyArt.Data;
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
       
        public string Title { get; set; }
        [Required]
        [Display(Name = "Date of Creation")]
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
        public int Price { get; set; }
        [Required]
        [Display(Name = "Where is this piece located?")]
        public string Location { get; set; }
        [Required]
        public bool Sold { get; set; }

        public string Note { get; set; }
    }

    public class ArtListItem
    {
        public int ArtID { get; set; }
        public string Title { get; set; }
        public string DateOfCreation { get; set; }

    }

    public class ArtDetail
    {
        public string Title { get; set; }
      
        [Display(Name = "Date of Creation")]
        public string DateOfCreation { get; set; }
    
        public Style Style { get; set; }
      
        public Medium Medium { get; set; }
    
        public string Surface { get; set; }
       
        public string Size { get; set; }
      
        public int Price { get; set; }
 
        [Display(Name = "Where is this piece located?")]
        public string Location { get; set; }
    
        public bool Sold { get; set; }
    }

    public class ArtNoteDetial
    {

        public string Title { get; set; }
  
        public string Note { get; set; }
    }

    public class ArtEdit
    {
        public int ArtID { get; set; }

        public string Title { get; set; }
     
        public string DateOfCreation { get; set; }
     
        public Style Style { get; set; }
       
        public Medium Medium { get; set; }
      
        public string Surface { get; set; }
      
        public string Size { get; set; }
        
        public int Price { get; set; }
       
        public string Location { get; set; }
     
        public bool Sold { get; set; }

        public string Note { get; set; }
    }



}