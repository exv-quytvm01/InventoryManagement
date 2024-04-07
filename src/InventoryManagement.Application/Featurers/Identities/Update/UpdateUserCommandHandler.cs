using AutoMapper;
using ExampleProject.Core.Entities;
using InventoryManagement.Application.IRepository;
using InventoryManagement.Core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Identities.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand,bool>
    {
        private readonly IAcountRepository _repository;
        private readonly IImageStorageService _imageStorageService;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(
            IAcountRepository repository, 
            IImageStorageService imageStorageService,
            IMapper mapper
        )
        {
            _repository = repository;
            _imageStorageService = imageStorageService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById(request.employee.Id);
            if (user == null)
            {
                return false;
            }

            _mapper.Map(request.employee, user);
            if (request.Image != null)
            {
                if (!string.IsNullOrEmpty(user.Image))
                {
                    await _imageStorageService.DeleteImageAsync(user.Image);
                }
                var path = await _imageStorageService.SaveImageAsync(request.Image);
                user.Image = path;
            }
           
            var result = await _repository.UpdateUser(user);
            return result;
        }
    }
}
