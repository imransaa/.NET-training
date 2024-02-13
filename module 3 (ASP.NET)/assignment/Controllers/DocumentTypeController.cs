using assignment.Controllers.Interfaces;
using assignment.Data;
using assignment.Dto;
using assignment.Models;
using assignment.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : RestController<DocumentType, TypeDto>, IDocumentTypeController
    {
        private readonly IDocumentTypeService _service;

        public DocumentTypeController(IDocumentTypeService service) : base(service)
        {
            _service = service;
        }

        [NonAction]
        public override async Task<IActionResult> Get(int id)
        {
            return await base.Get(id);
        }

        [NonAction]
        public override async Task<IActionResult> Put(int id, TypeDto request)
        {
            return await base.Put(id, request);
        }

        [NonAction]
        public override async Task<IActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }

        [HttpDelete("{typeName}")]
        [Authorize]
        public async Task<IActionResult> Delete(string typeName)
        {
            try
            {
                var response = _service.Delete(typeName);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }
        }
    }
}
