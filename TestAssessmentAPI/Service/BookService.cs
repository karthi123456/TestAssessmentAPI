using AutoMapper;
using System.Data;
using TestAssessmentAPI.Extensions;
using TestAssessmentAPI.Model;
using TestAssessmentAPI.Model.Domain;
using TestAssessmentAPI.Model.Request;
using TestAssessmentAPI.Model.Response;
using TestAssessmentAPI.Repository;

namespace TestAssessmentAPI.Service
{
    public interface IBookService
    {
        public Task<List<BookResponse>> GetBooks();
        public Task<List<BookResponse>> GetBookList();
        public Task<int> SaveBookList(List<BookRequest> booksList);
    }

    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<List<BookResponse>> GetBooks()
        {
            List<Book> bookResponses = await _bookRepository.GetBooks();
            List<BookResponse> books =  _mapper.Map<List<BookResponse>>(bookResponses);

            return books;
        }

        public async Task<List<BookResponse>> GetBookList()
        {
            List<Book> bookResponses = await _bookRepository.GetBookList();
            List<BookResponse> books = _mapper.Map<List<BookResponse>>(bookResponses);

            return books;
        }

        public async Task<int> SaveBookList(List<BookRequest> booksList)
        {
            DataTable dataTable = DataTableConversion.ToDataTable(booksList);

            return await _bookRepository.SaveBookList(dataTable);
        }
    }
}