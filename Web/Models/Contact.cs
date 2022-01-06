using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="The {0} is required")]
        [StringLength(15, ErrorMessage ="The length for the {0} field has to be between {2} and {1}", MinimumLength=4)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} is required")]        
        public string Email { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Creation date")]
        public DateTime? CreationDate { get; set; }

        [Required]
        public int CategoryId { get; set; } 
        public Category Category { get; set; }
    }
}
