using KnilaProject.IRepository;
using KnilaProject.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KnilaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookrepo)
        {
            _bookRepository = bookrepo;
        }

        //Sorted by Publishers,Author(last,first) then title
        [HttpGet]
        [Route("GetAllBooks")]
        public async Task<List<BookEntity>> GetAllBooks()
        {
            List<BookEntity> GetBooklist = new List<BookEntity>();
            try
            {
                GetBooklist = await _bookRepository.GetAllBooks();
                return GetBooklist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Sorted by Author(last,first) then title
        [HttpGet]
        [Route("GetBooksbyAuthor")]
        public async Task<List<BookEntity>> GetBooksbyAuthor()
        {
            List<BookEntity> getbookbyauth = new List<BookEntity>();
            try
            {
                getbookbyauth = await _bookRepository.GetAllBooksByAuthor();
                return getbookbyauth;
            }
            catch (Exception ex)
            {
                return getbookbyauth;
            }
        }

        //get book price 
        [HttpGet]
        [Route("GetBookPrice")]
        public async Task<decimal> GetAllBookPrice()
        {
            decimal booksPrice = new decimal();
            try
            {
                booksPrice = await _bookRepository.GetBookPrice();
                return booksPrice;
            }
            catch (Exception ex)
            {
                return booksPrice;
            }
        }

        [HttpPost]
        [Route("AddBook")]
        public async Task<string> AddBook(BookEntity bookModel)
        {
            var addbook = string.Empty;
            try
            {
                addbook = await _bookRepository.AddBook(bookModel);
                return addbook;
            }
            catch (Exception ex)
            {
                return addbook;
            }
        }

        [HttpPost]
        [Route("AddBulkbooks")]
        public async Task<string> AddBulkbooks(List<BookEntity> lstBooks)
        {
            var response = string.Empty;
            try
            {
                response = await _bookRepository.AddBulkBook(lstBooks);
                return response;
            }
            catch (Exception ex)
            {
                return response;
            }
        }

        //given Publisher based on the api 1 result otherwise given  the result based on author
        [HttpGet("GetBooksbySort")]
        public async Task<List<BookEntity>> GetBooksbySort(string sortName)
        {
            var books = await _bookRepository.GetBooksbySort(sortName);
            return books;
        }
    }
}
