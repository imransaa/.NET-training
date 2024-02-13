using assignment.Controllers.Interfaces;
using assignment.Services.Interfaces;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace assignment.Controllers
{
    public abstract class RestController<T, TDto> : ControllerBase, IRestController<TDto> where T : class where TDto : class
    {
        private readonly IGenericService<T, TDto> _service;

        public RestController(IGenericService<T, TDto> service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public virtual async Task<IActionResult> Get()
        {
            try
            {
                var response = _service.Get();
                return Ok(response);
            }   
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public virtual async Task<IActionResult> Get(int id)
        {
            try
            {
                var response = _service.Get(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }
        }

        [HttpPost]
        [Authorize]
        public virtual async Task<IActionResult> Post([FromBody] TDto request)
        {
            try
            {
                var response = _service.Add(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }
        }

        [HttpPut]
        [Authorize]
        public virtual async Task<IActionResult> Put(int id, [FromBody] TDto request)
        {
            try
            {
                var response = _service.Update(id, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public virtual async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = _service.Delete(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }
        }

        [NonAction]
        protected IActionResult InternalServerError(string message = "Internal Server Error")
        {
            return StatusCode(500, message);
        }
    }
}
