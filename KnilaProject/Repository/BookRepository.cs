using KnilaProject.IRepository;
using KnilaProject.Model.Models;
using KnilaProject.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KnilaProject.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDBContext _dbContext;

        public BookRepository(BookDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<BookEntity>> GetAllBooks()
        {
            return await _dbContext.Tbl_Books.OrderBy(e => e.Publisher)
                .ThenBy(e => e.AuthorFirstName).ThenBy(e => e.AuthorLastName)
                .ThenBy(e => e.Title).ToListAsync();
        }
        public async Task<List<BookEntity>> GetAllBooksByAuthor()
        {
            return await _dbContext.Tbl_Books.OrderBy(e => e.AuthorFirstName)
                .ThenBy(e => e.AuthorLastName).ThenBy(e => e.Title).ToListAsync();
        }
        public async Task<string> AddBook(BookEntity bookModel)
        {
            await _dbContext.Tbl_Books.AddAsync(bookModel);
            _dbContext.SaveChanges();
            return "Book Added Successfully";
        }

        public async Task<string> AddBulkBook(List<BookEntity> lstBooks)
        {
            await _dbContext.Tbl_Books.AddRangeAsync(lstBooks);
            _dbContext.SaveChanges();
            return "Book List Added Successfully";
        }
        public async Task<decimal> GetBookPrice()
        {
            return await _dbContext.Tbl_Books.Select(s => s.Price).SumAsync();
        }

        public async Task<List<BookEntity>> GetBooksbySort(string sortName)
        {
            var books = await _dbContext.Tbl_Books
           .FromSqlRaw("EXEC Sp_Getbooksbysorting @SortName = {0}", sortName)
           .ToListAsync();
            return books;
        }
    }
}
