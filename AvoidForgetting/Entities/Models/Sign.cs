using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvoidForgetting.Entities.Models
{
    /// <summary>
    /// 认证信息
    /// </summary>
    public class Sign
    {
        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public string Data { get; set; }
    }
}
