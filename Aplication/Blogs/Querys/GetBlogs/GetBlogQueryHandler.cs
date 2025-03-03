using AutoMapper;
using Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Blogs.Querys.GetBlogs
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogVm>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        //Implementamos la capa domain interface
        public GetBlogQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<List<BlogVm>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository.GetAllBlogsAsync();
            //var BlogList = blogs.Select(x => new BlogVm
            //{
            //    Author = x.Author,
            //    Name = x.Name,
            //    Description = x.Description,
            //    Id = x.Id
            //}).ToList();

            //Uso de models
            var BlogList = _mapper.Map<List<BlogVm>>(blogs);

            return BlogList;
        }
    }
}
