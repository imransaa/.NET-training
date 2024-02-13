using assignment.Data;
using assignment.Data.Interfaces;
using assignment.Dto;
using assignment.Models;
using assignment.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NuGet.Protocol.Core.Types;

namespace assignment.Services
{
    public class GroupService : GenericService<Group, GroupDto>, IGroupService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGroupRepository _repository;
        private readonly IUserRepository _userRepository;

        public GroupService(IUnitOfWork unitOfWork, IGroupRepository repository, IUserRepository userRepository, IMapper mapper) : base(unitOfWork, repository, mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = repository;
            _userRepository = userRepository;
        }

        public new IEnumerable<GroupDto> Get(int userId)
        {
            IEnumerable<Group> entities = _repository.Get(filter => filter.CreatorId == userId);
            return _mapper.Map<IEnumerable<Group>, IEnumerable<GroupDto>>(entities);
        }

        public GroupMembersDto Get(string groupName, int userId)
        {
            Group? entity = _repository.Get(filter => filter.CreatorId == userId && filter.Name == groupName, "Users").FirstOrDefault();

            if (entity == null)
            {
                throw new Exception("Group not found");
            }

            return _mapper.Map<Group, GroupMembersDto>(entity);
        }

        public GroupDto Add(int userId, GroupDto request)
        {
            var groups = _repository.Get(filter => filter.CreatorId == userId && filter.Name == request.Name);

            if(groups.Count() > 0)
            {
                throw new Exception("Group Already exists");
            }

            Group group = _mapper.Map<Group>(request);
            group.CreatorId = userId;
            _repository.Add(group);
            _unitOfWork.Save();
            return _mapper.Map<GroupDto>(group);
        }

        public GroupDto Update(string groupName, int userId, GroupDto request)
        {
            Group? group = _repository.Get(filter => filter.Name == groupName && filter.CreatorId == userId).FirstOrDefault();

            if (group == null)
            {
                throw new Exception("Group not found");
            }

            _mapper.Map(request, group);
            _repository.Update(group);
            _unitOfWork.Save();
            return _mapper.Map<GroupDto>(group);
        }

        public GroupDto Delete(string groupName, int userId)
        {
            Group? group = _repository.Get(filter => filter.Name == groupName && filter.CreatorId == userId, "Users").FirstOrDefault();

            if (group == null)
            {
                throw new Exception("Group not found");
            }

            _repository.Delete(group);
            _unitOfWork.Save();
            return _mapper.Map<GroupDto>(group);
        }

        public GroupMembersDto AddMember(string memberEmail, string groupName, int userId)
        {
            Group? group = _repository.Get(filter => filter.Name == groupName && filter.CreatorId == userId, "Users").FirstOrDefault();

            if (group == null)
            {
                throw new Exception("Group not found");
            }

            User? user = _userRepository.Get(filter => filter.Email == memberEmail).FirstOrDefault();

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if(user.Id ==  userId)
            {
                throw new Exception("Cant add group owner to group");
            }

            _repository.AddMembers(group.Id, user);
            _unitOfWork.Save();
            return _mapper.Map<Group, GroupMembersDto>(group);
        }

        public GroupMembersDto RemoveMember(string memberEmail, string groupName, int userId)
        {
            Group? group = _repository.Get(filter => filter.Name == groupName && filter.CreatorId == userId, "Users").FirstOrDefault();

            if (group == null)
            {
                throw new Exception("Group not found");
            }

            User? user = _userRepository.Get(filter => filter.Email == memberEmail).FirstOrDefault();

            if (user == null)
            {
                throw new Exception("User not found");
            }

            _repository.RemoveMembers(group.Id, user);
            _unitOfWork.Save();
            return _mapper.Map<Group, GroupMembersDto>(group);
        }
    }
}
