using Eng_assessment.Configuration;
using Eng_assessment.Repositories.Base;
using Eng_assessment.Repositories.Interface;
using Models.Entities.User;

namespace Eng_assessment.Repositories
{
    public class UserRepository : RootRepository<User>, IUserRepository
    {
        public UserRepository(MyDbContext dbContext) : base(dbContext)
        {

        }
    }
}
