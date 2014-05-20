using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Interface.Handler;
using WechatLibrary.Model;

namespace WechatLibrary.Core.Init
{
    public partial class Init
    {
        /// <summary>
        /// 初始化图片消息处理类。
        /// </summary>
        /// <param name="imageHandlerType">图片消息处理类。</param>
        public static void InitImageHandler(Type imageHandlerType)
        {
            using (WechatEntities entities = new WechatEntities())
            {
                var query = entities.WechatAccounts.Where(temp => imageHandlerType.Namespace.StartsWith(temp.Namespace));
                foreach (var wechatAccount in query)
                {
                    try
                    {
                        // 获取无参构造函数。
                        var constructor = imageHandlerType.GetConstructor(Type.EmptyTypes);
                        // 获取 ProcessRequest 方法。
                        var processRequest = imageHandlerType.GetMethod("ProcessRequest");

                        if (constructor != null && processRequest != null)
                        {
                            // 生成构造函数委托。
                            var constructorDelegate = Expression.Lambda(Expression.New(constructor)).Compile();

                            if (Cache.Cache.ImageHandlerConstructorDelegates.ContainsKey(wechatAccount.WechatId) == false)
                            {
                                lock (Cache.Cache.ImageHandlerConstructorDelegates)
                                {
                                    if (Cache.Cache.ImageHandlerConstructorDelegates.ContainsKey(wechatAccount.WechatId) == false)
                                    {
                                        Cache.Cache.ImageHandlerConstructorDelegates.Add(wechatAccount.WechatId, constructorDelegate);
                                    }
                                    else
                                    {
                                        throw new TypeInitializationException(typeof(IImageHandler).Name, new Exception("已存在一个实现该接口的类。"));
                                    }
                                }
                            }

                            if (Cache.Cache.ImageHandlerProcessRequestMethods.ContainsKey(wechatAccount.WechatId) == false)
                            {
                                lock (Cache.Cache.ImageHandlerProcessRequestMethods)
                                {
                                    if (Cache.Cache.ImageHandlerProcessRequestMethods.ContainsKey(wechatAccount.WechatId) == false)
                                    {
                                        Cache.Cache.ImageHandlerProcessRequestMethods.Add(wechatAccount.WechatId, processRequest);
                                    }
                                    else
                                    {
                                        throw new TypeInitializationException(typeof(IImageHandler).Name, new Exception("已存在一个实现该接口的类。"));
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
