using AutoMapper;
using InventoryManagement.Application.Dto;
using InventoryManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Stocks.Queries.GetStocks
{
    public class GetStocksQueryHandler : IRequestHandler<GetStocksQuery,List<StockDto>>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public GetStocksQueryHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<List<StockDto>> Handle(GetStocksQuery request, CancellationToken cancellationToken)
        {
            var stocks = await _stockRepository.GetListStocks();
            return _mapper.Map<List<StockDto>>(stocks);
        }
    }
}
