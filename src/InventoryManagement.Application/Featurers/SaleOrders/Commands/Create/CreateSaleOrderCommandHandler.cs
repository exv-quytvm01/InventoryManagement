using AutoMapper;
using ExampleProject.Core.Entities;
using InventoryManagement.Application.Dto.ProductionOrderDetails;
using InventoryManagement.Application.Dto.SaleOrderDetails;
using InventoryManagement.Application.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.SaleOrders.Commands.Create
{
    public class CreateSaleOrderCommandHandler : IRequestHandler<CreateSaleOrderCommand,Unit>
    {
        private readonly ISaleOrderRepository _saleOrderRepository;
        private readonly ISaleOrderDetailRepository _detailRepository;
        private readonly IMapper _mapper;

        public CreateSaleOrderCommandHandler(
            ISaleOrderRepository saleOrderRepository, 
            ISaleOrderDetailRepository detailRepository, 
            IMapper mapper)
        {
            _saleOrderRepository = saleOrderRepository;
            _detailRepository = detailRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateSaleOrderCommand request, CancellationToken cancellationToken)
        {
            float sum = 0;
            SaleOrder so = new SaleOrder()
            {
                CustomerId = request.SaleOrderDto.CustomerId,
                Date = request.SaleOrderDto.Date
            };
            so = await _saleOrderRepository.Add(so);
            foreach (CreateSaleOrderDetailDto Item in request.SaleOrderDto.ListSaleProducts)
            {
                Item.SaleOrderId = so.Id;
                var item = _mapper.Map<SaleOrderDetail>(Item);
                await _detailRepository.Add(item);
                sum += item.OrderQuantity * item.OrderPrice;
            }
            so.total_anmt = sum;
            await _saleOrderRepository.Update(so);
            return Unit.Value;
        }
    }
}
