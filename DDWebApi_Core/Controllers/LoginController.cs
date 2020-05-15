using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDWebApi_Core.Entities.Dtos;
using DDWebApi_Core.Entities.Models;
using DDWebApi_Core.JWT;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDWebApi_Core.Controllers
{
    /// <summary>
    /// 登录控制器
    /// </summary>
    public class LoginController : CommonBaseController
    {
        private readonly ITokenHelper tokenHelper = null;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_tokenHelper"></param>
        public LoginController(ITokenHelper _tokenHelper)
        {
            tokenHelper = _tokenHelper;
        }
        /// <summary>
        /// 登录测试
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnModel Login([FromBody]UserDto user)
        {
            var ret = new ReturnModel();
            try
            {
                if (string.IsNullOrWhiteSpace(user.LoginID) || string.IsNullOrWhiteSpace(user.Password))
                {
                    ret.Code = 201;
                    ret.Msg = "用户名密码不能为空";
                    return ret;
                }

                if (1 == 1)
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>
                    {
                        { "loginID", user.LoginID }
                    };
                    ret.Code = 200;
                    ret.Msg = "登录成功";
                    ret.TnToken = tokenHelper.CreateToken(keyValuePairs);
                }

            }
            catch (Exception ex)
            {
                ret.Code = 500;
                ret.Msg = "登录失败:" + ex.Message;
            }
            return ret;
        }
    }
}