using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvoidForgetting.Entities.Models;
using JWTToken.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvoidForgetting.Controllers
{
    /// <summary>
    /// 鉴权
    /// </summary>
    [ServiceFilter(typeof(TokenFilter))]
    public class SignController : CommonBaseController
    {
        /// <summary>
        /// 获取钉钉鉴权码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public CommonResponse Post()
        {
            var sign = new Sign { Data = "afhgkasghkjasbnvkbva", Type = 1 };
            return new CommonResponse { 
                Code = 0,
                Message = "请求成功",
                Data = sign
            };
        }
    }
}