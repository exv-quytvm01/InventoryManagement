using InventoryManagement.Application.IRepository;
using InventoryManagement.Core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Identities.Create
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand,bool>
    {
        private readonly IAcountRepository _acountRepository;
        private readonly IImageStorageService _imageStorageService;

        public CreateEmployeeCommandHandler(
            IAcountRepository acountRepository, 
            IImageStorageService imageStorageService)
        {
            _acountRepository = acountRepository;
            _imageStorageService = imageStorageService;
        }

        public async Task<bool> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var path = await _imageStorageService.SaveImageAsync(request.viewadd.Image);
            var result = await _acountRepository.CreateUser(request.viewadd.EmployeeDto, path);
            return result;
        }
    }
}
