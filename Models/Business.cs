using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schedu.Models
{
    public class Business
    {
        [Key]
        public int BusinessId { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        [DisplayName("Business Name")]
        [Required]
        public string BusinessName { get; set; }


        [DisplayName("Phone")]
        //[MaxLength(9, ErrorMessage = "Phone number should only contain 9 digits.")]
        public int BusinessPhone { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Email")]
        public string BusinessEmail { get; set; }


        [Column(TypeName = "nvarchar(35)")]
        [DisplayName("Owner Name")]
        [Required]
        public string OwnerName { get; set; }


        [DisplayName("Owner Phone")]
        //[MaxLength(9, ErrorMessage = "Phone number should only contain 9 digits.")]
        public int OwnerPhone { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Owner Email")]
        [Required]
        public string OwnerEmail { get; set; }


        [DisplayName("Registry Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime RegistryDate { get; set; }


        [DisplayName("Is Active?")]
        public bool IsActive { get; set; } = true;
    }
}