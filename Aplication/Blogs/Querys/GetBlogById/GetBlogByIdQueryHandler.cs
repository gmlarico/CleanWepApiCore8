using Aplication.Blogs.Querys.GetBlogs;
using AutoMapper;
using Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Blogs.Querys.GetBlogById
{
    class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogVm>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        //Implementamos la capa domain interface
        public GetBlogByIdQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<BlogVm> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository.GetByIdAsync(request.BlogId);
            //var BlogList = blogs.Select(x => new BlogVm
            //{
            //    Author = x.Author,
            //    Name = x.Name,
            //    Description = x.Description,
            //    Id = x.Id
            //}).ToList();

            //Uso de models
            var BlogList = _mapper.Map<BlogVm>(blogs);

            return BlogList;
        }
    }
}
