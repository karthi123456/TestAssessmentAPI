namespace TestAssessmentAPI.Model.Response
{
    public class BookResponse
    {
        public string? Publisher { get; set; }
        public string? Title { get; set; }
        public string? AuthorFirstName { get; set; }
        public string? AuthorLastName { get; set; }
        public decimal Price { get; set; }
    }
}
