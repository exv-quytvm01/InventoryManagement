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

namespace InventoryManagement.Application.Featurers.Products.Commands.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand,Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IImageStorageService _imageStorageService;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(
            IProductRepository productRepository,
            IImageStorageService imageStorageService,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _imageStorageService = imageStorageService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.Get(request.ProductDto.Id);
            if (request.Image is not null)
            {
                await _imageStorageService.DeleteImageAsync(product.Image);
                product.Image = await _imageStorageService.SaveImageAsync(request.Image);
            } 
            _mapper.Map(request.ProductDto, product);
            await _productRepository.Update(product);
            return Unit.Value;
        }
    }
}
