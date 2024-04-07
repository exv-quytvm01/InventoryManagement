using AutoMapper;
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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,bool>
    {
        private readonly IAcountRepository _acountRepository;
        private readonly IImageStorageService _imageStorageService;
       

        public CreateUserCommandHandler(
            IAcountRepository acountRepository, 
            IImageStorageService imageStorageService
        ){
            _acountRepository = acountRepository;
            _imageStorageService = imageStorageService;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var path = await _imageStorageService.SaveImageAsync(request.Image);
            var user = await _acountRepository.CreateUser(request.employee,path,request.employee.RoleId);
            return user;
        }
    }
}
