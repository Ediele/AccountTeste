using Account.Application.Core.Entity;
using Account.Application.Core.Interface.Repository;
using Account.Infraestructure.Repository.Base;
using Account.Infraestructure.Repository.Interface;

namespace Account.Infraestructure.Repository
{
    public class UserRepository : MongoBaseRepository<User>, IUserRepository
    {
        public UserRepository(IMongoConfigurationSettings settings) : base(settings)
        {

        }
    }
}
