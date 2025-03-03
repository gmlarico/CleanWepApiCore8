using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Blogs.Querys.GetBlogs
{
    public class GetBlogQuery : IRequest<List<BlogVm>>
    {
    }

    //public record GetBlogQuery : IRequest<List<BlogVm>>
    //{
    //}
}
