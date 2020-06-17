using Account.Application.Core.Entity;
using System.Collections.Generic;

namespace Account.Application.Core.Interface.Service
{
    public interface IUserService
    {
        IList<User> Get();
        User Get(string id);
        void Create(User user);
        void Update(string id, User user);
        void Remove(string id);
    }
}
