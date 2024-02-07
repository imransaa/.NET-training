using assignment.Models;

namespace assignment.Data.Interfaces
{
    public interface IDocumentTypeRepository : IGenericRepository<DocumentType>
    {
        DocumentType GetType(string type);
    }
}
