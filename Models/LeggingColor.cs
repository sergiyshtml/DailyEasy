namespace DailyEasy.Models
{
    public class LeggingColor
    {
        public int Id { get; set; }
        public string Color { get; set; } = string.Empty; // Ensure non-null value
        public ICollection<Legging> Leggings { get; set; } = new HashSet<Legging>();
    }
}
