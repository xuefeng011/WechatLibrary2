using Common.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WechatLibrary.Model;

namespace WechatLibrary.Core.Signature
{
    /// <summary>
    /// 验证 URL。
    /// </summary>
    public partial class Signature
    {
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

            // 获取数据库的 Token。
            using (WechatEntities entities = new WechatEntities())
            {
                var query = (from temp in entities.WechatAccounts
                             select temp.Token).Distinct();
                tokens.AddRange(query.AsEnumerable());
            }

            // 获取 web.config 的 Token。
            var webConfigToken = ConfigurationManager.AppSettings["Token"];
            if (string.IsNullOrEmpty(webConfigToken) == false)
            {
                if (tokens.Contains(webConfigToken) == false)
                {
                    tokens.Add(webConfigToken);
                }
            }

            if (tokens.Count <= 0)
            {
                return false;
            }
            else
            {
                HttpRequest request = context.Request;

                // 微信加密签名，signature 结合了开发者填写的 token 参数和请求中的 timestamp 参数、nonce 参数。
                string signature = request["signature"] ?? string.Empty;
                // 时间戳。
                string timestamp = request["timestamp"] ?? string.Empty;
                // 随机数。
                string nonce = request["nonce"] ?? string.Empty;

                foreach (string token in tokens)
                {
                    // 将 token、timestamp、nonce 三个参数进行字典序排序并拼接成一个字符串。
                    string validateString = string.Join(string.Empty,
                        new string[] { token, timestamp, nonce }.OrderBy(temp => temp));

                    // 将验证字符串进行 sha1 加密并与 signature 对比，标识该请求来源于微信。
                    bool result = string.Equals(SHA1Helper.GetStringSHA1(validateString), signature,
                        StringComparison.OrdinalIgnoreCase);

                    if (result == true)
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

            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

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
