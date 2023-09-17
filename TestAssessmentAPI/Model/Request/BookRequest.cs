namespace TestAssessmentAPI.Model.Request
{
    public class BookRequest
    {
        public string? AuthorFirstName { get; set; }
        public string? AuthorLastName { get; set; }
        public string? Title { get; set; }
        public string? Publisher { get; set; }
        public decimal Price { get; set; }
        public int? Year { get; set; }
    }
}
