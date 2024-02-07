using Microsoft.EntityFrameworkCore.Storage;

namespace assignment.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IGroupRepository GroupRepository { get; }
        IDocumentRepository DocumentRepository { get; }
        IDocumentTypeRepository DocumentTypeRepository { get; }
        IGroupAuthorizationRepository GroupAuthorizationRepository { get; }
        IUserAuthorizationRepository UserAuthorizationRepository { get; }
        IAuthorizationRoleRepository AuthorizationRoleRepository { get; }
        int Save();
        IDbContextTransaction GetTransasction();
    }
}
