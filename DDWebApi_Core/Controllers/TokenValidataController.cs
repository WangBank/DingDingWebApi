using DDWebApi_Core.Entities.Models;
using DDWebApi_Core.JWT;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDWebApi_Core.Controllers
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
        /// 验证Token
        /// </summary>
        /// <param name="tokenStr">token</param>
        /// <returns></returns>
        [HttpGet("ValiToken")]
        public ReturnModel ValiToken(string tokenStr)
        {
            if (string.IsNullOrEmpty(tokenStr))
            {
                return new ReturnModel
                {
                    Code = 500,
                    Msg = "缺少参数tokenStr",
                    TnToken = null,
                };
            }
            var ret = new ReturnModel
            {
                TnToken = new TnToken()
            };
            
            bool isvilidate = tokenHelper.ValiToken(tokenStr);
            if (isvilidate)
            {
                ret.Code = 200;
                ret.Msg = "Token验证成功";
                ret.TnToken.TokenStr = tokenStr;
            }
            else
            {
                ret.Code = 500;
                ret.Msg = "Token验证失败";
                ret.TnToken.TokenStr = tokenStr;
            }
            return ret;
        }
        /// <summary>
        /// 验证Token 带返回状态
        /// </summary>
        /// <param name="tokenStr"></param>
        /// <returns></returns>
        [HttpGet("ValiTokenState")]
        public ReturnModel ValiTokenState(string tokenStr)
        {
            var ret = new ReturnModel
            {
                TnToken = new TnToken()
            };
            string Issuer = Configuration.GetSection("JWTConfig").GetSection("Issuer").Value;
            string Audience = Configuration.GetSection("JWTConfig").GetSection("Audience").Value;
            string loginID = "";
            TokenType tokenType = tokenHelper.ValiTokenState(tokenStr, a => a["iss"] == Issuer && a["aud"] == Audience, action => { loginID = action["loginID"]; });
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
                { "Wyh", "123456" }
            };
            data.Add(bb);
            ret.Code = 200;
            ret.Msg = "访问成功!";
            ret.Data = data;
            return ret;
        }
    }
}
