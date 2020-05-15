﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDWebApi_Core.Entities.Dtos
{
    /// <summary>
    /// 登录类Dto
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string LoginID { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
