using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4_MVC.Models
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _bookDbContext;

        public BookRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public IEnumerable<Book> GetAllBooks 
        {
            get
            {
                return _bookDbContext.Books;
            }
        }
    }
}
