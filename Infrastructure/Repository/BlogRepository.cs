using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _blogDbContext;

        public BlogRepository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        public async Task<Blog> CreateAsync(Blog blog)
        {
            try
            {
                await _blogDbContext.Blogs.AddAsync(blog);
                int rowsAffected = await _blogDbContext.SaveChangesAsync();

                if (rowsAffected > 0)
                {
                    return blog; // Éxito
                }
                else
                {
                    throw new Exception("El blog no se guardó en la base de datos.");
                }
            }
            catch (DbUpdateException dbEx)
            {
                // Extraer mensaje detallado de la base de datos
                var innerException = dbEx.InnerException?.Message ?? dbEx.Message;
                throw new Exception($"Error al guardar en la base de datos: {innerException}", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado: {ex.Message}", ex);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _blogDbContext.Blogs
                   .Where(model => model.Id == id)
                   .ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            return await _blogDbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _blogDbContext.Blogs.Where(model => model.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateAsync(int id, Blog blog)
        {
            return await _blogDbContext.Blogs
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, blog.Id)
                    .SetProperty(m => m.Name, blog.Name)
                    .SetProperty(m => m.Description, blog.Description)
                    .SetProperty(m => m.Author, blog.Author)
                    );


        }
    }
}
