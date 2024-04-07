using AutoMapper;
using InventoryManagement.Application.Dto.Identity;
using InventoryManagement.Application.IRepository;
using InventoryManagement.Core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Identities.GetById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserById,CreateEmployeeDto>
    {
        private readonly IAcountRepository _acountRepository;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IAcountRepository acountRepository, IMapper mapper)
        {
            _acountRepository = acountRepository;
            _mapper = mapper;
        }

        public async Task<CreateEmployeeDto> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            var employees = await _acountRepository.GetById(request.Id);
            return _mapper.Map<CreateEmployeeDto>(employees);
        }
    }
}
