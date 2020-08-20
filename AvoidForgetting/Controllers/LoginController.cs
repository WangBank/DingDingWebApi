using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvoidForgetting.Entities.Dtos;
using AvoidForgetting.Entities.Models;
using AvoidForgetting.JWT;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvoidForgetting.Controllers
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
                if (string.IsNullOrWhiteSpace(user.username) || string.IsNullOrWhiteSpace(user.password))
                {
                    ret.Code = -1;
                    ret.Msg = "用户名密码不能为空";
                    return ret;
                }

                if (1 == 1)
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>
                    {
                        { "username", user.username }
                    };
                    ret.Code = 0;
                    ret.Msg = "登录成功";
                    ret.Result = tokenHelper.CreateToken(keyValuePairs);
                }

            }
            catch (Exception ex)
            {
                ret.Code = -1;
                ret.Msg = "登录失败:" + ex.Message;
            }
            return ret;
        }

        /// <summary>
        /// axios get测试
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ReturnModel GetInfo()
        {
            return new ReturnModel { 
                Code = 0,
                Data = "zz",
                Msg  = "请求成功" 
            };
        }
    }
}