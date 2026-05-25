using System.ComponentModel.DataAnnotations;

namespace MVC_Fiorella_All.ViewModels.Expert
{
    public class ExpertCreateVM
    {
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(30)]
        public string Job { get; set; }
    }
}
