using Dapper;
using System.Data;
using TestAssessmentAPI.Context;
using TestAssessmentAPI.Model.Domain;
using TestAssessmentAPI.Model.Response;

namespace TestAssessmentAPI.Repository
{

    public interface IBookRepository
    {
        public Task<List<Book>> GetBooks();
        public Task<List<Book>> GetBookList();
        public Task<int> SaveBookList(DataTable saveDataTable);
    }

    public class BookRepository : IBookRepository
    {
        private readonly DapperContext _dapperContext;
        public BookRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<List<Book>> GetBooks()
        {
            using var connection = _dapperContext.CreateConnection();
            var books = await connection.QueryAsync<Book>("SP_GetBooks");

            return books.ToList();
        }

        public async Task<List<Book>> GetBookList()
        {
            using var connection = _dapperContext.CreateConnection();
            var books = await connection.QueryAsync<Book>("SP_GetBookList");

            return books.ToList();
        }

        public async Task<int> SaveBookList(DataTable saveDataTable)
        {
            using var connection = _dapperContext.CreateConnection();
            {

                return await connection.ExecuteAsync("Insert_BookData",
                    new { BookData = saveDataTable.AsTableValuedParameter("BookType") },
                        commandType: CommandType.StoredProcedure);

            }
        }
    }
}