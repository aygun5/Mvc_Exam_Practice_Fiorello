namespace MVC_Fiorella_All.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Product>Products { get; set; }
    }
}
