namespace DailyEasy.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty; // Ensure non-null value
        public int LeggingId { get; set; }
        public Legging Legging { get; set; } = null!; // Ensure non-null value
    }
}

