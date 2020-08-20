using AvoidForgetting.Entities.Models;
using AvoidForgetting.JWT;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvoidForgetting.Controllers
{
    /// <summary>
    /// 验证token是否过期控制器
    /// </summary>
    public class TokenValidataController:CommonBaseController
    {
        private readonly ITokenHelper tokenHelper = null;

        /// <summary>
        /// 获取配置文件类
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_tokenHelper"></param>
        /// <param name="_configuration"></param>
        public TokenValidataController(ITokenHelper _tokenHelper, IConfiguration _configuration)
        {
            Configuration = _configuration;
            tokenHelper = _tokenHelper;
        }
        /// <summary>
        /// 验证access_token
        /// </summary>
        /// <param name="access_token">身份验证Token</param>
        /// <returns></returns>
        [HttpGet("ValiToken")]
        public ReturnModel ValiToken(string access_token)
        {
            if (string.IsNullOrEmpty(access_token))
            {
                return new ReturnModel
                {
                    Code = 500,
                    Msg = "缺少参数access_token",
                    Result = null,
                };
            }
            var ret = new ReturnModel
            {
                Result = new TnToken()
            };
            
            bool isvilidate = tokenHelper.ValiToken(access_token);
            if (isvilidate)
            {
                ret.Code = 200;
                ret.Msg = "Token验证成功";
                ret.Result.Token = access_token;
            }
            else
            {
                ret.Code = 500;
                ret.Msg = "Token验证失败";
                ret.Result.Token = access_token;
            }
            return ret;
        }
        /// <summary>
        /// 验证Token 带返回状态
        /// </summary>
        /// <param name="access_token">	身份验证Token</param>
        /// <returns></returns>
        [HttpGet("ValiTokenState")]
        public ReturnModel ValiTokenState(string access_token)
        {
            var ret = new ReturnModel
            {
                Result = new TnToken()
            };
            string Issuer = Configuration.GetSection("JWTConfig").GetSection("Issuer").Value;
            string Audience = Configuration.GetSection("JWTConfig").GetSection("Audience").Value;
            string username = "";
            TokenType tokenType = tokenHelper.ValiTokenState(access_token, a => a["iss"] == Issuer && a["aud"] == Audience, action => { username = action["username"]; });
            if (tokenType == TokenType.Fail)
            {
                ret.Code = 202;
                ret.Msg = "token验证失败";
                return ret;
            }
            if (tokenType == TokenType.Expired)
            {
                ret.Code = 205;
                ret.Msg = "token已经过期";
                return ret;
            }

            //..............其他逻辑
            var data = new List<Dictionary<string, string>>();
            var bb = new Dictionary<string, string>
            {
                { "wanghzen", "123456" }
            };
            data.Add(bb);
            ret.Code = 200;
            ret.Msg = "访问成功!";
            ret.Data = data;
            return ret;
        }
    }
}
