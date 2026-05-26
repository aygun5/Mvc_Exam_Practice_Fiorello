using System.ComponentModel.DataAnnotations;

namespace MVC_Fiorella_All.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string EmailOrUserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
