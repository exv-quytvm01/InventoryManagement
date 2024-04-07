using AutoMapper;
using ExampleProject.Core.Entities;
using InventoryManagement.Application.Dto.Products;
using InventoryManagement.Application.IRepository;
using InventoryManagement.Core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Products.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IImageStorageService _imageStorageService;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(
            IProductRepository productRepository, 
            IImageStorageService imageStorageService, 
            IMapper mapper)
        {
            _productRepository = productRepository;
            _imageStorageService = imageStorageService;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.ProductDto);
            product.Image = await _imageStorageService.SaveImageAsync(request.ProductDto.Image);
            //product.Image = "qtqetpt";
            product = await _productRepository.Add(product);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
