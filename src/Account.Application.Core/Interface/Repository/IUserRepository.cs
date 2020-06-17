using Account.Application.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Application.Core.Interface.Repository
{
    public interface IUserRepository
    {
        IList<User> Get();
        User Get(string id);
        void Create(User user);
        void Update(string id, User user);
        void Remove(string id);
    }
}
