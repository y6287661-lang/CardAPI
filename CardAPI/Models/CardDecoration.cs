using API.Models;


namespace CardAPI.Models
{
    public class CardDecoration
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Style { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}