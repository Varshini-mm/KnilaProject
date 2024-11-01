using KnilaProject.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace KnilaProject.Database
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options)
        {

        }
        public DbSet<BookEntity> Tbl_Books { get; set; }
    }
}
