using assignment.Data;
using assignment.Dto;
using assignment.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private UnitOfWork _unitOfWork;
        private IMapper _mapper;

        public DocumentTypeController(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/<DocumentTypeController>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                var types = _unitOfWork.DocumentTypeRepository.GetAll();
                var typeDto = _mapper.Map<IEnumerable<TypeDto>> (types);

                return Ok(typeDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        // POST api/<DocumentTypeController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] TypeDto typeDto)
        {
            try
            {
                DocumentType type = _unitOfWork.DocumentTypeRepository.GetType(typeDto.Type);

                if (type != null)
                {
                    return BadRequest("Document Type already exits");
                }

                type = _mapper.Map<DocumentType>(typeDto);

                _unitOfWork.DocumentTypeRepository.Add(type);
                _unitOfWork.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE api/<DocumentTypeController>/5
        [HttpDelete("{typeName}")]
        [Authorize]
        public IActionResult Delete([FromRoute]string typeName)
        {
            try
            {
                DocumentType type = _unitOfWork.DocumentTypeRepository.GetType(typeName);

                if(type == null)
                {
                    return BadRequest("Document Type does not exit");
                }

                _unitOfWork.DocumentTypeRepository.Delete(type);
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
