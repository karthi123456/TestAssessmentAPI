using AutoMapper;
using TestAssessmentAPI.Model.Domain;
using TestAssessmentAPI.Model.Request;
using TestAssessmentAPI.Model.Response;

namespace TestAssessmentAPI.Mapper
{
    public class BookProfile: Profile
    {
        public BookProfile()
        {
            CreateMap<BookResponse, Book>();
            CreateMap<BookRequest, Book>();
            CreateMap<Book, BookResponse>();
            CreateMap<Book, BookRequest>();
        }
    }
}
