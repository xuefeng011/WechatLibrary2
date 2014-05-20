using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Interface.Handler;
using WechatLibrary.Model;
using WechatLibrary.Model.Message.Request;
using WechatLibrary.Model.Message.Response;

namespace WechatLibrary.Core.Init
{
    public partial class Init
    {
        /// <summary>
        /// 初始化文本消息处理类。
        /// </summary>
        /// <param name="textHandlerType">文本消息处理类。</param>
        public static void InitTextHandler(Type textHandlerType)
        {
            using (WechatEntities entities = new WechatEntities())
            {
                var query = entities.WechatAccounts.Where(temp => textHandlerType.Namespace.StartsWith(temp.Namespace));
                foreach (var wechatAccount in query)
                {
                    try
                    {
                        // 获取无参构造函数。
                        var constructor = textHandlerType.GetConstructor(Type.EmptyTypes);
                        // 获取 ProcessRequest 方法。
                        var processRequest = textHandlerType.GetMethod("ProcessRequest");

                        if (constructor != null && processRequest != null)
                        {
                            // 生成构造函数委托。
                            var constructorDelegate = Expression.Lambda(Expression.New(constructor)).Compile();

                            if (Cache.Cache.TextHandlerConstructorDelegates.ContainsKey(wechatAccount.WechatId) == false)
                            {
                                lock (Cache.Cache.TextHandlerConstructorDelegates)
                                {
                                    if (Cache.Cache.TextHandlerConstructorDelegates.ContainsKey(wechatAccount.WechatId) == false)
                                    {
                                        Cache.Cache.TextHandlerConstructorDelegates.Add(wechatAccount.WechatId, constructorDelegate);
                                    }
                                    else
                                    {
                                        throw new TypeInitializationException(typeof(ITextHandler).Name, new Exception("已存在一个实现该接口的类。"));
                                    }
                                }
                            }

                            if (Cache.Cache.TextHandlerProcessRequestMethods.ContainsKey(wechatAccount.WechatId) == false)
                            {
                                lock (Cache.Cache.TextHandlerProcessRequestMethods)
                                {
                                    if (Cache.Cache.TextHandlerProcessRequestMethods.ContainsKey(wechatAccount.WechatId) == false)
                                    {
                                        Cache.Cache.TextHandlerProcessRequestMethods.Add(wechatAccount.WechatId, processRequest);
                                    }
                                    else
                                    {
                                        throw new TypeInitializationException(typeof(ITextHandler).Name, new Exception("已存在一个实现该接口的类。"));
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
        }
    }
}
