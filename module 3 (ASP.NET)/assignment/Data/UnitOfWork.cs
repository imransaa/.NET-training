using assignment.Models;
using assignment.Data.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace assignment.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;

        public IUserRepository UserRepository { get; }
        public IGroupRepository GroupRepository { get; }
        public IDocumentRepository DocumentRepository { get; }
        public IDocumentTypeRepository DocumentTypeRepository { get; }
        public IGroupAuthorizationRepository GroupAuthorizationRepository { get; }
        public IUserAuthorizationRepository UserAuthorizationRepository { get; }
        public IAuthorizationRoleRepository AuthorizationRoleRepository { get; }

        public UnitOfWork(
            AppDbContext context, 
            IUserRepository userRepository, 
            IGroupRepository groupRepository, 
            IDocumentRepository documentRepository, 
            IDocumentTypeRepository documentTypeRepository,
            IGroupAuthorizationRepository groupAuthorizationRepository,
            IUserAuthorizationRepository userAuthorizationRepository,
            IAuthorizationRoleRepository authorizationRoleRepository)
        {
            _context = context;
            UserRepository = userRepository;
            GroupRepository = groupRepository;
            DocumentRepository = documentRepository;
            DocumentTypeRepository = documentTypeRepository;
            GroupAuthorizationRepository = groupAuthorizationRepository;
            UserAuthorizationRepository = userAuthorizationRepository;
            AuthorizationRoleRepository = authorizationRoleRepository;
        }

        public virtual int Save()
        {
            return _context.SaveChanges();
        }

        public virtual IDbContextTransaction GetTransasction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}
