using Account.Application.Core.Entity;
using Account.Application.Core.Interface.Repository;
using Account.Application.Core.Interface.Service;
using NSubstitute;
using Xunit;

namespace Account.Tests
{
    public class UserServiceTest
    {
        private IUserRepository mock;

        public UserServiceTest()
        {
            mock = Substitute.For<IUserRepository>();

            mock.Get("123456")
                .Returns(s => GetUser());

            mock.Get("67890")
                .Returns(s => null);
        }
            
        public User GetUser()
        {
            var user = new User
            {
                Email = "ediele.gomes@gmail.com",
                Id = "123456"
            };

            return user;
        }

        
        [Fact]
        public void Get_By_Id_Return_Success()
        {
            var user =  mock.Get("123456");

            Assert.Equal("123456", user.Id);

        }

        [Fact]
        public void Get_By_Id_Return_Not_Found()
        {
            var user = mock.Get("67890");

            Assert.Null(user);
        }
    }
}
