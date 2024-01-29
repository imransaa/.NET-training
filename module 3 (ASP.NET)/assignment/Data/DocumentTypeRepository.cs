using assignment.Data.Interfaces;
using assignment.Models;

namespace assignment.Data
{
    public class DocumentTypeRepository : GenericRepository<DocumentType>, IDocumentTypeRepository
    {
        public DocumentTypeRepository(AppDbContext context) : base(context)
        {
            
        }

        public DocumentType GetType(string type)
        {
            return _dbSet.FirstOrDefault(x => x.Type == type);
        }
    }
}
