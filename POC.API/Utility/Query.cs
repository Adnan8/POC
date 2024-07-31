using POC.Application.DTO;
using POC.Application.Service;
using POC.Domain.Interface;
using POC.Domain.Models;

namespace POC.API.Utility
{
    public class Query
    {
        private readonly BookService _bookService;
        private readonly AuthorService _authorService;

        public Query(BookService bookService, AuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        public async Task<IEnumerable<BookDTO>> GetBooksAsync()
        {
             return await _bookService.GetAllBooksAsync();
        }
        public async Task<IEnumerable<AuthorDTO>> GetAuthorsAsync()
        {
            return await _authorService.GetAllAuthorsAsync();
        }

    }
}
