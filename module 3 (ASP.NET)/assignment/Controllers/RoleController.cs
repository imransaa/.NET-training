using assignment.Data;
using assignment.Dto;
using assignment.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private UnitOfWork _unitOfWork;
        private IMapper _mapper;

        public RoleController(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/<RoleController>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                var roles = _unitOfWork.AuthorizationRoleRepository.Get();
                var roleDto = _mapper.Map<IEnumerable<RoleDto>>(roles);

                return Ok(roleDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        // POST api/<RoleController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] RoleDto roleDto)
        {
            try
            {
                AuthorizationRole role = _unitOfWork.AuthorizationRoleRepository.GetRole(roleDto.Role);

                if (role != null)
                {
                    return BadRequest("Role already exits");
                }

                role = _mapper.Map<AuthorizationRole>(roleDto);

                _unitOfWork.AuthorizationRoleRepository.Add(role);
                _unitOfWork.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{roleName}")]
        [Authorize]
        public IActionResult Delete([FromRoute] string roleName)
        {
            try
            {
                AuthorizationRole role = _unitOfWork.AuthorizationRoleRepository.GetRole(roleName);

                if (role == null)
                {
                    return BadRequest("Role does not exit");
                }

                _unitOfWork.AuthorizationRoleRepository.Delete(role);
                _unitOfWork.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
