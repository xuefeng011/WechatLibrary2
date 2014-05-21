using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Common.Security;
using WechatLibrary.Model;
using System.Configuration;
using WechatLibrary.Model.Return;

namespace WechatLibrary.Signature
{
    /// <summary>
    /// 验证 URL。
    /// </summary>
    public partial class Signature
    {
        /// <summary>
        /// 指示 URL 验证是否成功。
        /// </summary>
        /// <param name="signature">微信加密签名，signature 结合了开发者填写的 token 参数和请求中的 timestamp 参数、nonce 参数。</param>
        /// <param name="timestamp">时间戳。</param>
        /// <param name="nonce">随机数。</param>
        /// <param name="token">Token。</param>
        /// <returns>是否验证成功。</returns>
        public static bool IsSignature(string signature, string timestamp, string nonce, string token)
        {
            signature = signature ?? string.Empty;
            timestamp = timestamp ?? string.Empty;
            nonce = nonce ?? string.Empty;
            token = token ?? string.Empty;

            // 将 token、timestamp、nonce 三个参数进行字典排序并拼接成一个字符串。
            string validateString = string.Join(string.Empty,
                new string[] { token, timestamp, nonce }.OrderBy(temp => temp));

            // 将验证字符串进行 sha1 加密并与 signature 对比，标识该请求来源自微信。
            bool result = string.Equals(SHA1Helper.GetStringSHA1(validateString), signature,
                StringComparison.OrdinalIgnoreCase);
            return result;
        }

        /// <summary>
        /// 指示 URL 验证是否成功。
        /// </summary>
        /// <param name="context">验证的 Http 上下文。</param>
        /// <returns>验证是否成功。</returns>
        /// <exception cref="System.ArgumentNullException"><c>context</c> 为 null。</exception>
        public static bool IsSignature(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            List<string> tokens = new List<string>();

            // 获取数据库中所有的 Token。
            using (WechatEntities entities = new WechatEntities())
            {
                var query = (from temp in entities.WechatAccounts
                             select temp.Token).Distinct();
                tokens.AddRange(query.AsEnumerable());
            }

            // 获取 config 中的 Token。
            var configToken = ConfigurationManager.AppSettings["Token"];
            if (string.IsNullOrEmpty(configToken) == false)
            {
                if (tokens.Contains(configToken) == false)
                {
                    tokens.Add(configToken);
                }
            }

            if (tokens.Count <= 0)
            {
                return false;
            }
            else
            {
                HttpRequest request;
                try
                {
                    request = context.Request;
                }
                catch (HttpException ex)
                {
                    return false;
                }


                // 微信加密签名，signature 结合了开发者填写的 token 参数和请求中的 timestamp 参数、nonce 参数。
                string signature = request["signature"] ?? string.Empty;
                // 时间戳。
                string timestamp = request["timestamp"] ?? string.Empty;
                // 随机数。
                string nonce = request["nonce"] ?? string.Empty;

                foreach (var token in tokens)
                {
                    if (IsSignature(signature, timestamp, nonce, token) == true)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 根据 URL 验证返回内容给微信服务器。验证失败时返回 error 字符串。
        /// </summary>
        /// <param name="context">验证的 Http 上下文。</param>
        /// <exception cref="System.ArgumentNullException"><c>context</c> 为 null。</exception>
        public static void DoSignature(HttpContext context)
        {
            DoSignature(context, "error");
        }

        /// <summary>
        /// 根据 URL 验证返回内容给微信服务器。
        /// </summary>
        /// <param name="context">验证的 Http 上下文。</param>
        /// <param name="validateFailureReturn">验证失败时返回的字符串。</param>
        /// <exception cref="System.ArgumentNullException"><c>context</c> 为 null。</exception>
        public static void DoSignature(HttpContext context, string validateFailureReturn)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            HttpRequest request;
            HttpResponse response;

            try
            {
                request = context.Request;
                response = context.Response;
            }
            catch (HttpException)
            {
                return;
            }

            string echostr = request["echostr"];

            if (string.IsNullOrEmpty(echostr) == false && IsSignature(context) == true)
            {
                response.Write(echostr);
            }
            else
            {
                response.Write(validateFailureReturn);
            }
            response.ContentType = "text/plain";
            response.End();
        }
    }
}
