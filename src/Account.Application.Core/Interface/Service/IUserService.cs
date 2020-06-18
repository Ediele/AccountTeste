using Account.Application.Core.Entity;
using System.Collections.Generic;

namespace Account.Application.Core.Interface.Service
{
    public interface IUserService
    {
        IList<User> Get();
        User Get(string id);
        void Create(User user);
        void Update(User user);
        void Remove(string id);
    }
}
