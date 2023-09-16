using Microsoft.AspNetCore.Mvc;
using TestAssessmentAPI.Model.Request;
using TestAssessmentAPI.Service;

namespace TestAssessmentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Route("Books")]
        public async Task<IActionResult> Books()
        {
            try
            {
                var books = await _bookService.GetBooks();

                return Ok(books);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("BookList")]
        public async Task<IActionResult> BookList()
        {
            try
            {
                var books = await _bookService.GetBookList();

                return Ok(books);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost(Name = "Save")]
        public async Task<IActionResult> SaveBook([FromBody] List<BookRequest> bookRequests)
        {
            try
            {
                var books = await _bookService.SaveBookList(bookRequests);

                return Ok(books);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    
}
