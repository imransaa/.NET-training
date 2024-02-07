using assignment.Data.Interfaces;
using assignment.Dto;
using assignment.Models;
using assignment.Services.Interfaces;
using AutoMapper;

namespace assignment.Services
{
    public class UserService : GenericService<User, UserDto>, IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;
        private readonly IAuthService _authService;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IAuthService authService) : base(unitOfWork, unitOfWork.UserRepository, mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = unitOfWork.UserRepository;
            _authService = authService;
        }

        public TokenDto Signin(SigninDto signin)
        {
            var users = _repository.Get(filter => filter.Email == signin.Email);

            if(users.Count() == 0)
            {
                throw new Exception("User Doesn't Exists");
            }

            User user = users.First();

            if (!_authService.VerifyPassword(signin.Password, user.HashedPassword, user.Salt))
            {
                throw new Exception("Invalid credentials");
            }

            TokenDto token = new TokenDto { Token = _authService.GetToken(user) };

            return token;
        }
        
        public UserDto Signup(SignupDto signup)
        {
            var users = _repository.Get(filter => filter.Email == signup.Email);

            if (users.Count() > 0)
            {
                throw new Exception("User Already Exists");
            }

            User user = _mapper.Map<User>(signup);

            user.HashedPassword = _authService.HashPasword(signup.Password, out var salt);
            user.Salt = salt;

            _repository.Add(user);
            _unitOfWork.Save();

            return _mapper.Map<UserDto>(user);  
        }
    }
}
