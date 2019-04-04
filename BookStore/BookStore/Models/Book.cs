namespace BookStore.Models
{
    public class Book
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string Available { get; set; }
    }
}