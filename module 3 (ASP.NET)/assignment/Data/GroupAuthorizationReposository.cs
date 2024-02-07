using assignment.Data.Interfaces;
using assignment.Models;

namespace assignment.Data
{
    public class GroupAuthorizationReposository : GenericRepository<GroupAuthorization>, IGroupAuthorizationRepository
    {
        public GroupAuthorizationReposository(AppDbContext context) : base(context)
        {
            
        }
    }
}
