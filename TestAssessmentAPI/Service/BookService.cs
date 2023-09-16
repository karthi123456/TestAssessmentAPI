using AutoMapper;
using System.Data;
using TestAssessmentAPI.Extensions;
using TestAssessmentAPI.Model.Domain;
using TestAssessmentAPI.Model.Request;
using TestAssessmentAPI.Model.Response;
using TestAssessmentAPI.Repository;

namespace TestAssessmentAPI.Service
{
    public interface IBookService
    {
        public Task<List<Book>> GetBooks();
        public Task<List<Book>> GetBookList();
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
        public async Task<List<Book>> GetBooks()
        {
            List<BookResponse> bookResponses = await _bookRepository.GetBooks();

            return _mapper.Map<List<Book>>(bookResponses);
        }

        public async Task<List<Book>> GetBookList()
        {
            List<BookResponse> bookResponses = await _bookRepository.GetBookList();

            return _mapper.Map<List<Book>>(bookResponses);
        }

        public async Task<int> SaveBookList(List<BookRequest> booksList)
        {
            List<Book> book = _mapper.Map<List<Book>>(booksList);
            DataTable dataTable = DataTableConversion.ToDataTable(book);

            return await _bookRepository.SaveBookList(dataTable);
        }
    }
}