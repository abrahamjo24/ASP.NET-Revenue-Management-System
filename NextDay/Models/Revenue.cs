namespace NextDay.Models
{
    public class Revenue
    {
        public int Id { get; set; }
        public string? Source { get; set; }

        public DateTime CreatedDate { get; set; }
        public string? Owner { get; set; }
        public double Amount { get; set; }
    }
}
