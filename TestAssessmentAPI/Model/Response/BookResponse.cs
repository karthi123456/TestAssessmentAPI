namespace TestAssessmentAPI.Model.Response
{
    public class BookResponse
    {
        public string? Publisher { get; set; }
        public string? Title { get; set; }
        public string? AuthorFirstName { get; set; }
        public string? AuthorLastName { get; set; }
        public decimal Price { get; set; }
        public int? Year { get; set; }

        public string MLACitation
        {
            get
            {
                // Format the MLA citation
                string citation = $"{AuthorLastName}, {AuthorFirstName}. \"{Title}.\" {Publisher}, {Year}.";
                return citation;
            }
        }

        public string ChicagoCitation
        {
            get
            {
                // Format the Chicago citation
                string citation = $"{AuthorLastName}, {AuthorFirstName}. {Title}. {Publisher}, {Year}. {Price:C}";
                return citation;
            }
        }
    }
}
