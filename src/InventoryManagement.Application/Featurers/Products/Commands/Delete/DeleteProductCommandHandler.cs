using AutoMapper;
using ExampleProject.Core.Entities;
using InventoryManagement.Application.IRepository;
using InventoryManagement.Core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Products.Commands.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand,Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IImageStorageService _imageStorageService;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(
            IProductRepository productRepository,
            IImageStorageService imageStorageService,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _imageStorageService = imageStorageService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(request.Id);
            //string path = product.Image;
            if (product is not null)
            {
                await _imageStorageService.DeleteImageAsync(product.Image);
                await _productRepository.Delete(product);
            }
            
            return Unit.Value;
        }
    }
}
