using assignment.Data;
using assignment.Dto;
using assignment.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DocumentController(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/<DocumentController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET api/<DocumentController>/5
        [HttpGet("{id}")]
        public IActionResult GetDocument(int id)
        {
            try
            {
                int userId = int.Parse(this.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

                Document document = _unitOfWork.DocumentRepository.GetDocumentDetails(id);

                if(document == null)
                {
                    return NotFound("Document does not exist");
                }

                string userAuth = HasUserPermission(document, userId);
                IEnumerable<string> groupAuth = HasGroupPermission(document, userId);

                if (document.CreatorId != userId && userAuth == null && groupAuth.Count() == 0)
                {
                    return Unauthorized();
                }

                HashSet<string> authorizations = new HashSet<string>();
                string creatorAuthorization = "owner";
                
                if(document.CreatorId == userId)
                {
                    authorizations.Add(creatorAuthorization);
                }

                if(userAuth != null)
                {
                    authorizations.Add(userAuth);
                }

                foreach (var role in groupAuth)
                {
                    authorizations.Add(role);
                }

                var documentDetails = new
                {
                    Id = document.Id,
                    Name = document.Name,
                    Type = _unitOfWork.DocumentTypeRepository.Get(document.TypeId).Type,
                    Authorizations = authorizations.ToArray()
                };

                return Ok(documentDetails);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Error");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // POST api/<DocumentController>
        [HttpPost]
        public IActionResult CreateDocument([FromBody] DocumentDto documentDto)
        {
            try
            {
                int creatorId = int.Parse(this.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

                Document document = _mapper.Map<Document>(documentDto);
                DocumentType type = _unitOfWork.DocumentTypeRepository.GetType(documentDto.Type);
                
                if(type == null)
                {
                    return NotFound("Document Type does not exist");
                }

                if(_unitOfWork.DocumentRepository.GetDocumentWithDetails(creatorId, document.Name, type.Type) != null)
                {
                    return BadRequest("Document already exists");
                }

                document.Type = type;
                document.CreatorId = creatorId;

                _unitOfWork.DocumentRepository.Add(document);
                _unitOfWork.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        // PUT api/<DocumentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE api/<DocumentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        // POST api/<ValuesController>/auth/10
        [HttpPost("auth/{id}")]
        public IActionResult AddAuth(int id, [FromBody] string value)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE api/<ValuesController>/auth/10
        [HttpDelete("auth/{id}")]
        public IActionResult RemoveAuth(int id, [FromBody] string value)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        private string HasUserPermission(Document document, int userId)
        {
            UserAuthorization authorization = document.UserAuthorizations.Where(x => x.UserId == userId).FirstOrDefault();

            if(authorization != null)
            {
                return authorization.Role.Role;
            }

            return null;
        }

        private IEnumerable<string> HasGroupPermission(Document document, int userId)
        {
            IEnumerable<Group> groups = _unitOfWork.GroupRepository.GetGroupWithMember(userId);
            IEnumerable<GroupAuthorization> authorizations = document.GroupAuthorizations.Where(x => groups.Contains(x.Group));
            return authorizations.Select(x => x.Role.Role);
        }
    }
}
