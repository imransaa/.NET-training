using assignment.Dto;
using Microsoft.AspNetCore.Mvc;

namespace assignment.Controllers.Interfaces
{
    public interface IDocumentTypeController : IRestController<TypeDto>
    {
        Task<IActionResult> Delete(string typeName);
    }
}
