using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace empty.Models

{
    [MetadataType(typeof(Companymetadata))]
    public partial class Company
    {
        //add new properties

        [Display(Name ="Confirm Email")]
        [Required]
        //[Compare("Email",ErrorMessage ="Email is not matched")]
        public string confEmail { get; set; }

        [Display(Name = "Confirm Password")]
        [Required]
        //[Compare("password", ErrorMessage = "Password is not matched")]
        public string confPassword { get; set; }

    }

    public class Companymetadata
    {
        //edit properties
        [Display(Name ="ID")]
        public int CID { get; set; }
        
        [Display(Name = "company name")]
        [Required]
        public string Cname { get; set; }
        [Required]
        public string Ctype { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:D}", ApplyFormatInEditMode = false)]
        public Nullable<System.DateTime> EDate { get; set; }
        [Required]
        //[StringLength (15,MinimumLength =8,ErrorMessage ="should between 8-15 chars")]
        //[RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{8,64})", ErrorMessage ="password is not a strong password")]
        public string password { get; set; }
        [DisplayFormat(DataFormatString ="{0:N}",ApplyFormatInEditMode =false)]
        [Range(10000, 1000000, ErrorMessage = "should be between 10000 and 1000000")]
        public Nullable<int> capital { get; set; }
        public string logo { get; set; }
        [Display(Name = "Website")]
     
        public string Curl { get; set; }

    }
}