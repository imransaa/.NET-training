using assignment.Data;
using assignment.Dto;
using assignment.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GroupController(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                int id = int.Parse(this.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
                var groups = _unitOfWork.GroupRepository.GetUserGroups(id).Select(x => _mapper.Map<GroupDetailsDto>(x));

                return Ok(groups);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetGroup(int id)
        {
            try
            {
                int creatorId = int.Parse(this.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

                Group group = _unitOfWork.GroupRepository.GetGroupWithMembers(id);

                if (group == null)
                {
                    return BadRequest("Group Doesn't exist");
                }

                if (group.CreatorId != creatorId)
                {
                    return Unauthorized();
                }

                GroupMembersDto groupMembers = _mapper.Map<GroupMembersDto>(group);

                return Ok(groupMembers);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        [Authorize]
        public IActionResult CreateGroup([FromBody] CreateGroupDto createGroup)
        {
            try
            {
                Group group = _mapper.Map<Group>(createGroup);
                group.CreatorId = int.Parse(this.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

                if(_unitOfWork.GroupRepository.GetGroupWithName(group.CreatorId, group.Name) != null)
                {
                    return BadRequest("Group Already exists");
                }

                _unitOfWork.GroupRepository.Add(group);
                _unitOfWork.Save();

                GroupDetailsDto groupDetails = _mapper.Map<GroupDetailsDto>(group);

                return Ok(groupDetails);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        // POST api/<ValuesController>/member/10
        [HttpPost("member/{id}")]
        [Authorize]
        public IActionResult AddMembers(int id, [FromBody] GroupMemberDto members)
        {
            try
            {
                int creatorId = int.Parse(this.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

                Group group = _unitOfWork.GroupRepository.GetById(id);

                if (group == null)
                {
                    return BadRequest("Group Doesn't exist");
                }

                List<User> users = new List<User>();

                foreach (var email in members.Emails)
                {
                    User user = _unitOfWork.UserRepository.GetUserByEmail(email);
                    if (user == null)
                    {
                        return NotFound($"User with email {email} not found");
                    }
                    else
                    {
                        users.Add(user);
                    }
                }

                foreach (var user in users)
                {
                    _unitOfWork.GroupRepository.AddMembers(id, user);
                }
                _unitOfWork.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE api/<ValuesController>/member/10
        [HttpDelete("member/{id}")]
        [Authorize]
        public IActionResult RemoveMembers(int id, [FromBody] GroupMemberDto email)
        {
            try
            {
                int creatorId = int.Parse(this.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

                Group group = _unitOfWork.GroupRepository.GetById(id);

                if (group == null)
                {
                    return BadRequest("Group Doesn't exist");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteGroup(int id)
        {
            try
            {
                int creatorId = int.Parse(this.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

                Group group = _unitOfWork.GroupRepository.GetById(id);

                if (group == null)
                {
                    return BadRequest("Group Doesn't exist");
                }

                if(group.CreatorId != creatorId)
                {
                    return Unauthorized();
                }

                _unitOfWork.GroupRepository.Delete(group);
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
