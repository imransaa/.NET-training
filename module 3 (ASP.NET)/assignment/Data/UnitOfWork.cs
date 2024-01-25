using assignment.Models;

namespace assignment.Data
{
    public class UnitOfWork
    {
        private AppDbContext _context;

        public GenericRepository<User> UserRepository { get; }
        public GenericRepository<Group> GroupRepository { get; }
        public GenericRepository<Document> DocumentRepository { get; }
        public GenericRepository<DocumentType> DocumentTypeRepository { get; }
        public GenericRepository<GroupAuthorization> GroupAuthorizationRepository { get; }
        public GenericRepository<UserAuthorization> UserAuthorizationRepository { get; }
        public GenericRepository<AuthorizationRole> AuthorizationRoleRepository { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            UserRepository = new GenericRepository<User>(context);
            GroupRepository = new GenericRepository<Group>(context);
            DocumentRepository = new GenericRepository<Document>(context);
            DocumentTypeRepository = new GenericRepository<DocumentType>(context);
            GroupAuthorizationRepository = new GenericRepository<GroupAuthorization>(context);
            UserAuthorizationRepository = new GenericRepository<UserAuthorization>(context);
            AuthorizationRoleRepository = new GenericRepository<AuthorizationRole>(context);
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}
