using AvoidForgetting.Entities.Dtos;
using AvoidForgetting.Entities.Models;
using AvoidForgetting.JWT;
using JWTToken.Filter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AvoidForgetting.Controllers
{
    /// <summary>
    /// User Api
    /// </summary>
    
    public class UserController : CommonBaseController
    {

        private readonly ITokenHelper tokenHelper = null;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_tokenHelper"></param>
        public UserController(ITokenHelper _tokenHelper)
        {
            tokenHelper = _tokenHelper;
        }

        /// <summary>
        /// 登录测试
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public CommonResponse Login([FromBody] UserDto user)
        {
            var ret = new CommonResponse();
            try
            {
                if (string.IsNullOrWhiteSpace(user.username) || string.IsNullOrWhiteSpace(user.password))
                {
                    ret.Code = -1;
                    ret.Message = "用户名密码不能为空";
                    return ret;
                }

                if (1 == 1)
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>
                    {
                        { "username", user.username }
                    };
                    ret.Code = 0;
                    ret.Message = "登录成功";
                    ret.TokenInfo = tokenHelper.CreateToken(keyValuePairs);
                    ret.Data = "";
                }

            }
            catch (Exception ex)
            {
                ret.Code = -1;
                ret.Message = "登录失败:" + ex.Message;
            }
            return ret;
        }
        /// <summary>
        /// UserInfo
        /// </summary>
        /// <returns></returns>
        [ServiceFilter(typeof(TokenFilter))]
        [HttpGet]
        public CommonResponse Info(string token)
        {
            return new CommonResponse
            {
                Code = 0,
                Data = new UserInfo
                {
                    id = "4291d7da9005377ec9aec4a71ea837f",
                    name = "王bank",
                    avatar = "http://localhost:20000/images/default.gif",
                    menus = @"[{path: '/test',component: 'Layout',children: [{path: 'index',name: 'Test',component: 'test/index',meta: { title: 'test', icon: 'dashboard' }},{ path: '*', redirect: '/404', hidden: true }]}]"
                },
                Message ="获取信息成功"
            };

        }
    }
}