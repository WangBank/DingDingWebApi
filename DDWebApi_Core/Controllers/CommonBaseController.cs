﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDWebApi_Core.Controllers
{
    /// <summary>
    /// 1 统一跨域处理
    /// 2 统一路由处理
    /// </summary>
    [EnableCors("AllowCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class CommonBaseController : ControllerBase
    {
    }
}