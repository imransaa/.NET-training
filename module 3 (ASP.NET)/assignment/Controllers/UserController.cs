using assignment.Data;
using assignment.Data.Interfaces;
using assignment.Dto;
using assignment.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly UnitOfWork _unitOfWork;

        public UserController(UnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _config = config;
        }

        // POST api/<GroupController>/signin
        [HttpPost("signin")]
        public async Task<IActionResult> Signin([FromBody] SigninDto signin)
        {
            try
            {
                User user = _unitOfWork.UserRepository.GetUserByEmail(signin.Email);

                if (user == null)
                {
                    return BadRequest("User Doesn't exist");
                }

                if(!VerifyPassword(signin.Password, user.HashedPassword, StringToByteArray(user.Salt)))
                {
                    return Unauthorized();
                }

                TokenDto token = new TokenDto { Token = GetToken(user) };

                return Ok(token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        // POST api/<GroupController>/signup
        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupDto signup)
        {
            try
            {
                User user = _mapper.Map<User>(signup);

                if (_unitOfWork.UserRepository.GetUserByEmail(user.Email) != null)
                {
                    return BadRequest("User Already exists");
                }

                user.HashedPassword = HashPasword(signup.Password, out var salt);
                user.Salt = Convert.ToHexString(salt);

                _unitOfWork.UserRepository.Add(user);
                _unitOfWork.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE api/<GroupController>/5
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteUser()
        {
            try
            {
                int id = int.Parse(this.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

                if (_unitOfWork.UserRepository.GetById(id) == null)
                {
                    return BadRequest("User Doesn't exist");
                }

                _unitOfWork.UserRepository.Delete(id);
                _unitOfWork.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        private string HashPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }

        bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);

            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }

        private byte[] StringToByteArray(string hex)
        {
            if (hex.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

            byte[] arr = new byte[hex.Length >> 1];

            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            }

            return arr;
        }

        private int GetHexVal(char hex)
        {
            int val = (int)hex;
            return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }

        private string GetToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(2),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
