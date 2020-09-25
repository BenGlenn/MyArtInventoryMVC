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
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

    }

    public class ClientListItem
    {
        public int ClientID { get; set; }
        public bool Collector { get; set; }
        public string FistName  { get; set; }
        public string LastName { get; set; }
       
    }

    public class ClientDetail
    {
        public int ClientID { get; set; }
        public bool Collector { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
      
    }

    public class ClientEdit
    {
        public int ClientID { get; set; }
        public bool Collector { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
