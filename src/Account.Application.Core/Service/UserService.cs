using System.Collections.Generic;
using Account.Application.Core.Entity;
using Account.Application.Core.Interface.Repository;
using Account.Application.Core.Interface.Service;

namespace Account.Application.Core.Service
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        public void Create(User user)
        {
            _userRepository.Create(user);
        }

        public IList<User> Get()
        {
            return _userRepository.Get();
        }

        public User Get(string id)
        {
            return _userRepository.Get(id);
        }

        public void Remove(string id)
        {
            _userRepository.Remove(id);
        }

        public void Update(User user)
        {
            _userRepository.Update(user);           
        }
    }
}
