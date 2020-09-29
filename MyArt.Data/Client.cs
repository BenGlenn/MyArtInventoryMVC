using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArt.Data
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public bool Collector { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public State State { get; set; }

        public int ZipCode { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }

    public enum State
    {
        Alabama_AL,
        Alaska_AK,
        Arizona_AZ,
        Arkansas_AR,
        California_CA,
        Colorado_CO,
        Connecticut_CT,
        Delaware_DE,
        Florida_FL,
        Georgia_GA,
        Hawaii_HI,
        Idaho_ID,
        Illinois_IL,
        Indiana_IN,
        Iowa_IA,
        Kansas_KS,
        Kentucky_KY,
        Louisiana_LA,
        Maine_ME,
        Maryland_MD,
        Massachusetts_MA,
        Michigan_MI,
        Minnesota_MN,
        Mississippi_MS,
        Missouri_MO,
        Montana_MT,
        Nebraska_NE,
        Nevada_NV,
        New_Hampshire_NH,
        New_Jersey_NJ,
        New_Mexico_NM,
        New_York_NY,
        North_Carolina_NC,
        North_Dakota_ND,
        Ohio_OH,
        Oklahoma_OK,
        Oregon_OR,
        Pennsylvania_PA,
        Rhode_Island_RI,
        South_Carolina_SC,
        South_Dakota_SD,
        Tennessee_TN,
        Texas_TX,
        Utah_UT,
        Vermont_VT,
        Virginia_VA,
        Washington_WA,
        West_Virginia_WV,
        Wisconsin_WI,
        Wyoming_WY,

    }
}
