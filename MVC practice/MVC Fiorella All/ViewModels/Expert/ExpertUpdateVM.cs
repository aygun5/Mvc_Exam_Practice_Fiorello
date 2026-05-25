namespace MVC_Fiorella_All.ViewModels.Expert
{
    public class ExpertUpdateVM
    {
        public string? Image { get; set; }
        public IFormFile? NewImage { get; set; }
        public string FullName { get; set; }
        public string Job { get; set; }
    }
}
