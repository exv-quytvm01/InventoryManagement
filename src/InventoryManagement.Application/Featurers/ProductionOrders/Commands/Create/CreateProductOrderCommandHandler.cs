using AutoMapper;
using ExampleProject.Core.Entities;
using InventoryManagement.Application.Dto.ProductionOrderDetails;
using InventoryManagement.Application.IRepository;
using MediatR;

namespace InventoryManagement.Application.Featurers.ProductionOrders.Commands.Create
{
    public class CreateProductOrderCommandHandler : IRequestHandler<CreateProductOrderCommand,Unit>
    {
        private readonly IProductionOrderRepository _repository;
        private readonly IProductionOrderDetailRepository _detailRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public CreateProductOrderCommandHandler(
            IProductionOrderRepository repository, 
            IProductionOrderDetailRepository detailRepository, 
            IStockRepository stockRepository, 
            IMapper mapper
        ){
            _repository = repository;
            _detailRepository = detailRepository;
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateProductOrderCommand request, CancellationToken cancellationToken)
        {
            float sum = 0;
            ProductionOrder po = new ProductionOrder() { 
                SupplierId = request.ProductOrderDto.SupplierId,
                Date = request.ProductOrderDto.Date
            };
            po = await _repository.Add(po); 
            foreach(CreateProductionOrderDetailDto Item in request.ProductOrderDto.ListProductOrders)
            {
                Item.ProductionOrderId = po.Id;
                var item = _mapper.Map<ProductionOrderDetail>(Item);
                await _detailRepository.Add(item);
                
                sum += item.OrderQuantity * item.Price;
            }
            po.total_anmt = sum;
            await _repository.Update(po);
            return Unit.Value;
        }
    }
}
