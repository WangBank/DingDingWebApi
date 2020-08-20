using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvoidForgetting.Entities.Dtos
{
    /// <summary>
    /// 登录类
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string username { get; set; }
    }

    /// <summary>
    /// UserInfo
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// guid
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string avatar { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string telephone { get; set; }

        /// <summary>
        /// 最后登录ip
        /// </summary>
        public string lastLoginIp { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public long lastLoginTime { get; set; }

        /// <summary>
        /// 创建人id
        /// </summary>
        public string creatorId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public long createTime { get; set; }
         
        /// <summary>
        /// 是否删除 0：未删除 1：已删除
        /// </summary>
        public int deleted { get; set; }

        /// <summary>
        /// 权限id
        /// </summary>
        public string roleId { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public object role { get; set; }

    }

}
