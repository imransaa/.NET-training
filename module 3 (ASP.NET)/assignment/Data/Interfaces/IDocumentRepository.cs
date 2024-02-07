using assignment.Models;

namespace assignment.Data.Interfaces
{
    public interface IDocumentRepository : IGenericRepository<Document>
    {
        Document GetDocumentDetails(int id);
        Document GetDocumentWithDetails(int creatorId, string name, string type);
    }
}
