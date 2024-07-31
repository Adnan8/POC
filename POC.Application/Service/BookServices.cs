using AutoMapper;
using POC.Application.DTO;
using POC.Domain.Interface;
using POC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Application.Service
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDTO> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            return _mapper.Map<BookDTO>(book);
        }

        public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return _mapper.Map<IEnumerable<BookDTO>>(books);
        }

        public async Task<BookDTO> AddBookAsync(BookDTO bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            await _bookRepository.AddBookAsync(book);
            var resultDto = _mapper.Map<BookDTO>(book); 
            return resultDto; 
        }


        public async Task UpdateBookAsync(BookDTO bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            await _bookRepository.UpdateBookAsync(book);
        }
    }
}
