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
        public ReturnModel Post()
        {
            var sign = new Sign { Data = "afhgkasghkjasbnvkbva", Type = 1 };
            return new ReturnModel { 
                Code = 0,
                Msg = "请求成功",
                Data = sign
            };
        }
    }
}