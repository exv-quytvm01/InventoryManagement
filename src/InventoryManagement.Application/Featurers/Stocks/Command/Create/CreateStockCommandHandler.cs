using AutoMapper;
using ExampleProject.Core.Entities;
using InventoryManagement.Application.Dto;
using InventoryManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Stocks.Command.Create
{
    public class CreateStockCommandHandler : IRequestHandler<CreateStockCommand, StockDto>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public CreateStockCommandHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<StockDto> Handle(CreateStockCommand request, CancellationToken cancellationToken)
        {
            var stock = _mapper.Map<Stock>(request.Stock);
            var stock1 =  await _stockRepository.Add(stock);
            return _mapper.Map<StockDto>(stock1);
        }
    }
}
