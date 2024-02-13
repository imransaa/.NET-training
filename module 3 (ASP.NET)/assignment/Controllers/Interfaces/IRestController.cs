using Microsoft.AspNetCore.Mvc;

namespace assignment.Controllers.Interfaces
{
    public interface IRestController<TDto> where TDto : class
    {
        public Task<IActionResult> Get();
        public Task<IActionResult> Get(int id);
        public Task<IActionResult> Post([FromBody] TDto request);
        public Task<IActionResult> Put(int id, [FromBody] TDto request);
        public Task<IActionResult> Delete(int id);
    }
}
