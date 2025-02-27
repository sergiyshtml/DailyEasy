namespace DailyEasy.Models
{
    public class Legging
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Ensure non-null value
        public double Price { get; set; }
        public int CategoriID { get; set; }
        public Categori Categori { get; set; } = null!; // Ensure non-null value
        public int ColorID { get; set; }
        public LeggingColor Color { get; set; } = null!; // Ensure non-null value
        public int SizeID { get; set; }
        public LeggingSize Size { get; set; } = null!; // Ensure non-null value
        public ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();
    }
}

