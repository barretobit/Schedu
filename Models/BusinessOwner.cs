using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Schedu.Models
{
    public class BusinessOwner
    {
        [Key]
        public int BusinessOwnerId { get; set; }

        [Column(TypeName = "nvarchar(35)")]
        [DisplayName("Owner Name")]
        [Required]
        public string OwnerName { get; set; }


        [DisplayName("Owner Phone")]
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