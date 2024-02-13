using assignment.Data;
using assignment.Data.Interfaces;
using assignment.Dto;
using assignment.Models;
using assignment.Services.Interfaces;
using AutoMapper;
using NuGet.Protocol.Core.Types;

namespace assignment.Services
{
    public class RoleService : GenericService<AuthorizationRole, RoleDto>, IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorizationRoleRepository _repository;

        public RoleService(IUnitOfWork unitOfWork, IAuthorizationRoleRepository repository, IMapper mapper) : base(unitOfWork, repository, mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = repository;
        }

        public override RoleDto Add(RoleDto request)
        {
            var roles = _repository.Get(filter => filter.Role == request.Role);

            if (roles.Count() != 0)
            {
                throw new Exception("Role already exists");
            }

            return base.Add(request);
        }

        public RoleDto Delete(string roleName)
        {
            var role = _repository.Get(filter => filter.Role == roleName).First();

            if(role == null)
            {
                throw new Exception("Role Not Found");
            }

            _repository.Delete(role);
            _unitOfWork.Save();

            return _mapper.Map<RoleDto>(role);
        }
    }
}
