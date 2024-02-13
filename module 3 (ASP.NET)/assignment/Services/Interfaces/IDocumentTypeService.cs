using assignment.Dto;
using assignment.Models;

namespace assignment.Services.Interfaces
{
    public interface IDocumentTypeService : IGenericService<DocumentType, TypeDto>
    {
        TypeDto Delete(string typeName);
    }
}
