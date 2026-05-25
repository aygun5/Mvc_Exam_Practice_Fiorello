namespace MVC_Fiorella_All.Models
{
    public class Student : BaseEntity 
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public decimal Grade { get; set; }
        public string Group { get; set; }
        public string Phone { get; set; }
        public string Faculty { get; set; }
    }
}
