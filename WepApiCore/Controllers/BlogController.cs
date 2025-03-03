using Aplication.Blogs.Commands.CreateBlog;
using Aplication.Blogs.Commands.DeleteBlog;
using Aplication.Blogs.Commands.UpdateBlog;
using Aplication.Blogs.Querys.GetBlogById;
using Aplication.Blogs.Querys.GetBlogs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WepApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await Mediator.Send(new GetBlogQuery());
            return Ok(blogs);   
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await Mediator.Send(new GetBlogByIdQuery() {BlogId = id});

            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCommand command)
        {
            var createBlog = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = createBlog.Id }, createBlog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBlogCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteBlogCommand { Id = id });

            if (result == 0)
            {
                return BadRequest();
            }

            return NoContent();

        }

    }
}
