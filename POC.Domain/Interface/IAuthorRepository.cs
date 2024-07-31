using POC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Domain.Interface
{
    public interface IAuthorRepository
    {
        Task<Author> GetAuthorByIdAsync(int id);
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task AddAuthorAsync(Author author);
        Task UpdateAuthorAsync(Author author);
    }
}
