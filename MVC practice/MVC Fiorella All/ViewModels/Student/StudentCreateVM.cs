using System.ComponentModel.DataAnnotations;

namespace MVC_Fiorella_All.ViewModels.Student
{
    public class StudentCreateVM
    {
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public decimal Grade { get; set; }
        [Required]
        public string Group { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Faculty { get; set; }
    }
}
