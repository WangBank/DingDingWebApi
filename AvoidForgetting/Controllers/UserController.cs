using AvoidForgetting.Entities.Dtos;
using JWTToken.Filter;
using Microsoft.AspNetCore.Mvc;

namespace AvoidForgetting.Controllers
{
    /// <summary>
    /// User Api
    /// </summary>
    [ServiceFilter(typeof(TokenFilter))]
    public class UserController : CommonBaseController
    {
        /// <summary>
        /// UserInfo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public UserInfo Info()
        {
            return new UserInfo {
                id = "4291d7da9005377ec9aec4a71ea837f",
                name = "天野远子",
                username ="admin",
                avatar = "",
                status = 1,
                telephone = "17854238990",
                lastLoginIp = "192.168.100.123",
                lastLoginTime = 1534837621348,
                creatorId = "admin",
                createTime = 1497160610259,
                deleted = 0,
                roleId = "admin"
            };

        }
    }
}