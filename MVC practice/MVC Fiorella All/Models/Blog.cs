using System.Collections;

namespace MVC_Fiorella_All.Models
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<BlogImage> BlogImages { get; set; }
    }
}
