using assignment.Models;
using assignment.Data.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace assignment.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;

        public UserRepository UserRepository { get; }
        public GroupRepository GroupRepository { get; }
        public GenericRepository<Document> DocumentRepository { get; }
        public DocumentTypeRepository DocumentTypeRepository { get; }
        public GenericRepository<GroupAuthorization> GroupAuthorizationRepository { get; }
        public GenericRepository<UserAuthorization> UserAuthorizationRepository { get; }
        public AuthorizationRoleRepository AuthorizationRoleRepository { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            UserRepository = new UserRepository(context);
            GroupRepository = new GroupRepository(context);
            DocumentRepository = new GenericRepository<Document>(context);
            DocumentTypeRepository = new DocumentTypeRepository(context);
            GroupAuthorizationRepository = new GenericRepository<GroupAuthorization>(context);
            UserAuthorizationRepository = new GenericRepository<UserAuthorization>(context);
            AuthorizationRoleRepository = new AuthorizationRoleRepository(context);
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

        public virtual IDbContextTransaction GetTransasction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}
