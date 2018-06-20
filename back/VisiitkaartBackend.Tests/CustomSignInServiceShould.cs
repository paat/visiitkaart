using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using VisiitkaartBackend.Data.Models;
using VisiitkaartBackend.Data.Models.Enums;
using VisiitkaartBackend.Models.Options;
using VisiitkaartBackend.Services;
using VisiitkaartBackend.Services.Interfaces;
using VisiitkaartBackend.Services.Repositories.Interfaces;
using Xunit;

namespace VisiitkaartBackend.Tests
{
    public class CustomSignInServiceShould
    {
        Mock<IUserRepository> _userRepositoryMock;
        IOptions<JwtOptions> _jwtOptions;

        public CustomSignInServiceShould()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _jwtOptions = new OptionsWrapper<JwtOptions>(new JwtOptions() {
                Issuer = "http://localhost:5000",
                Key = "someBigAssKeyForJwt",
                LifeTimeMinutes = "30"
            }); 
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "someString")]
        [InlineData("someString", null)]
        public void ReturnNullValueIfInputIsNull(string username, string password)
        {
            ICustomSignInService service = new CustomSignInService(_userRepositoryMock.Object, _jwtOptions);

            string jwtToken = service.GetJwtToken(username, password);

            Assert.Null(jwtToken);
        }

        [Fact]
        public void ReturnJwtTokenIfPasswordMatches()
        {
            ICustomSignInService service = SignInServiceWithMockedAdminAccount();
   
            string jwtToken = service.GetJwtToken("someUser", "admin123");

            Assert.Contains(".", jwtToken);
        }

        [Fact]
        public void ReturnNullIfPasswordDoesntMatch()
        {
            ICustomSignInService service = SignInServiceWithMockedAdminAccount();

            string jwtToken = service.GetJwtToken("someUser", "wrongPassword");

            Assert.Null(jwtToken);
        }

        private ICustomSignInService SignInServiceWithMockedAdminAccount()
        {
            ICustomSignInService service = new CustomSignInService(_userRepositoryMock.Object, _jwtOptions);

            _userRepositoryMock
                .Setup(r => r.Get("someUser"))
                .Returns(new User()
                {
                    Email = "someUser",
                    PasswordHash = "2iYX3yd5wjY9ZErZzudZ2lXy7MvR46Wb/aHMkGYXlbsVja81",
                    Roles = new List<UserRoleEnum> { UserRoleEnum.Admin },
                });
            return service;
        }
    }
}
