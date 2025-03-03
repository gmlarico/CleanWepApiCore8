using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator() 
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(10).WithMessage("Nombre no debe de exceder los 100 caracteres");

            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("La descripcion es requerida")
                .MaximumLength(10).WithMessage("Descripcion no debe de exceder los 100 caracteres");

            RuleFor(v => v.Author)
                .NotEmpty().WithMessage("El Autor es requerido.")
                .MaximumLength(10).WithMessage("Autor no debe de exceder los 100 caracteres");


        }


    }
}
