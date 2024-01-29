using assignment.Models;

namespace assignment.Data.Interfaces
{
    public interface IDocumentTypeRepository
    {
        DocumentType GetType(string type);
    }
}
