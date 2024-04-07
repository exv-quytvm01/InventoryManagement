using AutoMapper;
using ExampleProject.Core.Entities;
using InventoryManagement.Application.Dto;
using InventoryManagement.Application.IRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Stocks.Queries.GetStocksByPage
{
    public class GetStocksQueryByPageHandler : IRequestHandler<GetStocksQueryByPage,PaginatedListDto<StockDto>>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        private object item1;

        public GetStocksQueryByPageHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedListDto<StockDto>> Handle(GetStocksQueryByPage request, CancellationToken cancellationToken)
        {
            var stocks = _stockRepository.getListByCondition();
            if (!string.IsNullOrEmpty(request.searchString))
            {
                stocks = stocks.Include(s => s.Product).Where(s => s.Product.Title.Contains(request.searchString));
            }

            switch (request.sortOrder)
            {                
                case "date_asc":
                    stocks = stocks.OrderBy(e => e.LastModified);
                    break;
                case "date_desc":
                    stocks = stocks.OrderByDescending(s => s.LastModified);
                    break;
            }
            List<Stock> item1;
            if (!string.IsNullOrEmpty(request.searchString))
            {
                item1 = await stocks.ToListAsync();
            }
            else
            {
                item1 = await stocks.Include(s => s.Product).ToListAsync();
            }
            var item = item1;
                
            if (request.pageNumber < 1)
            {
                request.pageNumber = 1;
            }
            //int pageSize = 5;

            var items = await _stockRepository.CreateAsync(stocks, request.pageNumber, request.pageSize);
            var itemsDto = _mapper.Map<List<StockDto>>(items);
            var pagined = new PaginatedListDto<StockDto>(itemsDto, item.Count, request.pageNumber, request.pageSize);
            return pagined;
        }
    }
}
