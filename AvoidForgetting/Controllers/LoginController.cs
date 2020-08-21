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
        /// axios get测试
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public CommonResponse GetInfo()
        {
            return new CommonResponse { 
                Code = 0,
                Data = "zz",
                Message  = "请求成功" 
            };
        }
    }
}