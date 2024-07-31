using POC.API.GraphQLSchema.Inputs;
using POC.Application.DTO;
using POC.Application.Service;
using POC.Domain.Interface;
using POC.Domain.Models;

namespace POC.API.Utility
{
    public class Mutation
    {
        private readonly BookService _bookService;
        private readonly AuthorService _authorService;

        public Mutation(BookService bookService, AuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        public async Task<BookDTO> AddBook(BookInput book)
        {
            var bookDto = new BookDTO
            {
                Title = book.Title,
                ISBN = book.ISBN,
                AuthorId = book.AuthorId
            };
            await _bookService.AddBookAsync(bookDto);
            return bookDto;
        }


        public async Task<BookDTO> UpdateBook(BookDTO book)
        {
            await _bookService.UpdateBookAsync(book);
            return book;
        }

        public async Task<AuthorDTO> AddAuthor(AuthorInput author)
        {
            var authorDto = new AuthorDTO
            {
                Name = author.Name,
            };
            await _authorService.AddAuthorAsync(authorDto);
            return authorDto;
        }

        public async Task<AuthorDTO> UpdateAuthor(AuthorDTO author)
        {
            await _authorService.UpdateAuthorAsync(author);
            return author;
        }
    }
}
