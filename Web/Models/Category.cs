using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Required")]
        [StringLength(15, ErrorMessage = "The length for the {0} field has to be between {2} and {1}", MinimumLength = 4)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [Display(Name="Creation date")]
        public DateTime? CreationDate { get; set; }
    }
}
