using AutoMapper;
using InventoryManagement.Application.Dto;
using InventoryManagement.Application.Dto.Identity;
using InventoryManagement.Application.IRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Identities.GetUsersByPage
{
    public class GetUsersByPageCommandHandler : IRequestHandler<GetUsersByPageCommand,PaginatedListDto<CreateEmployeeDto>>
    {
        private readonly IAcountRepository _acountRepository;
        private readonly IMapper _mapper;

        public GetUsersByPageCommandHandler(IAcountRepository acountRepository, IMapper mapper)
        {
            _acountRepository = acountRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedListDto<CreateEmployeeDto>> Handle(GetUsersByPageCommand request, CancellationToken cancellationToken)
        {
            var userss = _acountRepository.getListByCondition();
            
            if (!string.IsNullOrEmpty(request.searchString))
            {
                userss = userss.Where(s => s.EmployeeName.Contains(request.searchString));
            }

            switch (request.sortOrder)
            {
                case "name_desc":
                    userss = userss.OrderByDescending(e => e.EmployeeName);
                    break;
                case "date_asc":
                    userss = userss.OrderBy(e => e.LastModified);
                    break;
                case "date_desc":
                    userss = userss.OrderByDescending(s => s.LastModified);
                    break;
            }
            var item1 = await  userss.ToListAsync();
            if (request.pageNumber < 1)
            {
                request.pageNumber = 1;
            }
            //int pageSize = 5;

            var items = await _acountRepository.CreateAsync(userss, request.pageNumber, request.pageSize);
            var itemsDto = _mapper.Map<List<CreateEmployeeDto>>(items);
            var pagined = new PaginatedListDto<CreateEmployeeDto>(itemsDto, item1.Count, request.pageNumber, request.pageSize);
            return pagined;
        }
    }
}
