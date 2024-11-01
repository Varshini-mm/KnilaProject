using KnilaProject.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace KnilaProject.IRepository
{
    public interface IBookRepository
    {
       Task<List<BookEntity>> GetAllBooks();
       Task<List<BookEntity>> GetAllBooksByAuthor();
       Task<decimal> GetBookPrice();
       Task<String> AddBulkBook(List<BookEntity> lstBooks);
       Task<String> AddBook(BookEntity bookModel);
       Task<List<BookEntity>> GetBooksbySort(string sortName);
    }
}
