using AutoMapper;
using InventoryManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Categories.Commands.Delete
{
    public class DeleteCategoryComandHandler : IRequestHandler<DeleteCategoryComand,Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public DeleteCategoryComandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCategoryComand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.Get(request.Id);
            //if (category == null)
            //{

            //}
            await _categoryRepository.Delete(category);
            return Unit.Value;
        }
    }
}
