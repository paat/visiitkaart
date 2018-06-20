using System.Collections.Generic;
using System.Linq;
using VisiitkaartBackend.Data.Models;
using VisiitkaartBackend.Data.Models.Enums;
using Xunit;

namespace VisiitkaartBackend.Tests
{
    public class UserObjectShould
    {

        [Fact]
        public void SetRolesListWhenRoleValueIsSet()
        {
            User user = new User { RoleValue = 128 };

            Assert.NotNull(user.Roles);
        }

        [Theory]
        [InlineData(128, new UserRoleEnum[] { UserRoleEnum.Admin }) ]
        [InlineData(4, new UserRoleEnum[] { UserRoleEnum.StandardUser })]
        [InlineData(32, new UserRoleEnum[] { UserRoleEnum.PrepressShop })]
        [InlineData(132, new UserRoleEnum[] { UserRoleEnum.StandardUser, UserRoleEnum.Admin })]
        public void SetProperRoleEnumsInListWhenRoleCodeIsSet(byte roleValue, UserRoleEnum[] expectedResult)
        {
            User user = new User { RoleValue = roleValue };

            Assert.Equal(expectedResult.ToList(), user.Roles);
        }
    }
}
