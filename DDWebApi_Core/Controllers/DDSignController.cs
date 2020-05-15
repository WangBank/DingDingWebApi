using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTToken.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDWebApi_Core.Controllers
{
    /// <summary>
    /// 钉钉鉴权
    /// </summary>
    [Route("GetSign")]
    [ServiceFilter(typeof(TokenFilter))]
    public class DDSignController : CommonBaseController
    {
        /// <summary>
        /// 获取钉钉鉴权码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string Post()
        {
            return "zz";
        }
    }
}