using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhino_Web.Models
{
    [MetadataType(typeof(StudentDataRegisterModel))]
    public partial class StudentData
    {



    }


    public class StudentDataRegisterModel
    {

        [Required]
        [HiddenInput(DisplayValue = false)]
        public Guid StudentId { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only Use Letters and Blank Spaces")]
        public string Name { get; set; }
        [Required]
        public string Roll { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Class")]
        public string _Class { get; set; }
        [Required]
        public string Section { get; set; }
        [Required]
        [Display(Name = "Father's Name")]
        public string Fathers_Name { get; set; }
        [Required]
        [Display(Name = "Mother's Name")]
        public string Mothers_Name { get; set; }

        [Display(Name = "District")]
        public string Parmanent_District { get; set; }

        [Display(Name = "Thana")]
        public string Parmanent_Thana { get; set; }

        [Display(Name = "House No")]
        public string Parmanent_House_No { get; set; }
        [Required]
        [Display(Name = "District")]
        public string Present_District { get; set; }
        [Required]
        [Display(Name = "Thana")]
        public string Present_Thana { get; set; }
        [Required]
        [Display(Name = "House No")]
        public string Present_House_No { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime Date_Of_Birth { get; set; }
        [Display(Name = "Blood Group")]
        public string Blood_Group { get; set; }
        [Required]
        [RegularExpression(@"^(?:\+?88)?01[15-9]\d{8}$", ErrorMessage = "Give Valid Bangladeshi Number")]
        [DataType(DataType.PhoneNumber)]
        public string Parents_Mobile { get; set; }
        [Required]
        public string Picture { get; set; }

        [Required]
        [Display(Name = "Birth Registration Number")]
        public string Birth_Registration_Number { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [HiddenInput(DisplayValue = false)]
        public virtual string UserId { get; set; }


    }
 
}