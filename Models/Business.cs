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
        public int BusinessPhone { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Email")]
        public string BusinessEmail { get; set; }


        [DisplayName("Business Owner")]
        public BusinessOwner BusinessOwner { get; set; }

        [DisplayName("Registry Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime RegistryDate { get; set; }


        [DisplayName("Is Active?")]
        public bool IsActive { get; set; } = true;
    }
}