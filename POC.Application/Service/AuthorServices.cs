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
    public class AuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDTO> GetAuthorByIdAsync(int id)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(id);
            return _mapper.Map<AuthorDTO>(author);
        }

        public async Task<IEnumerable<AuthorDTO>> GetAllAuthorsAsync()
        {
            var author = await _authorRepository.GetAllAuthorsAsync();
            return _mapper.Map<IEnumerable<AuthorDTO>>(author);
        }

        public async Task<AuthorDTO> AddAuthorAsync(AuthorDTO authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            await _authorRepository.AddAuthorAsync(author);
            var resultDto = _mapper.Map<AuthorDTO>(author);
            return resultDto;
        }

        public async Task UpdateAuthorAsync(AuthorDTO authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            await _authorRepository.UpdateAuthorAsync(author);
        }
    }

}
