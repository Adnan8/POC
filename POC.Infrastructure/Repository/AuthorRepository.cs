using Microsoft.EntityFrameworkCore;
using POC.Domain.Interface;
using POC.Domain.Models;
using POC.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Infrastructure.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly POCDBContext _context;

        public AuthorRepository(POCDBContext context)
        {
            _context = context;
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task AddAuthorAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }
    }
}
