using assignment.Data.Interfaces;
using assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace assignment.Data
{
    public class DocumentRepository : GenericRepository<Document>, IDocumentRepository
    {
        public DocumentRepository(AppDbContext context) : base(context)
        {
            
        }

        public Document GetDocumentDetails(int id)
        {
            return _dbSet
                .Include(x => x.GroupAuthorizations)
                .Include(x => x.UserAuthorizations)
                .FirstOrDefault(x => x.Id == id);
        }

        public Document GetDocumentWithDetails(int creatorId, string name, string type)
        {
            return _dbSet
                .Where(x => x.CreatorId == creatorId && x.Name == name && x.Type.Type == type)
                .FirstOrDefault();
        }
    }
}
