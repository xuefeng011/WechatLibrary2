using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model;
using WechatLibrary.Model.Message.Request.Normal;

namespace WechatLibrary.Init
{
    public partial class Init
    {
        public static void InitHandler(Type type, ConcurrentDictionary<string, Delegate> constructorDelegates, ConcurrentDictionary<string, MethodInfo> processRequestMethods)
        {
            using (WechatEntities entities = new WechatEntities())
            {
                var query = entities.WechatAccounts.Where(temp => type.Namespace.StartsWith(temp.Namespace) == true);
                foreach (var wechatAccount in query)
                {
                    try
                    {
                        // 获取无参构造函数。
                        var constructor = type.GetConstructor(Type.EmptyTypes);

                        // 获取 ProcessRequest 方法。
                        var processRequest = type.GetMethod("ProcessRequest");

                        if (constructor != null && processRequest != null)
                        {
                            // 生成构造函数委托。
                            var constructorDelegate = Expression.Lambda(Expression.New(constructor)).Compile();

                            bool addConstructorDelegate = constructorDelegates.TryAdd(wechatAccount.WechatId, constructorDelegate);

                            bool addProcessRequestMethod = processRequestMethods.TryAdd(wechatAccount.WechatId, processRequest);

                            if (addConstructorDelegate == false && addProcessRequestMethod == true)
                            {
                                // 添加 ProcessRequest 方法成功，但添加构造函数委托失败。
                                processRequestMethods.TryRemove(wechatAccount.WechatId, out processRequest);
                            }

                            if (addConstructorDelegate == true && addProcessRequestMethod == false)
                            {
                                // 添加构造函数委托成功，但添加 ProcessRequest 方法失败。
                                constructorDelegates.TryRemove(wechatAccount.WechatId, out constructorDelegate);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }
        }

        public static void InitHandler(Type type, ConcurrentDictionary<string, ConcurrentDictionary<string, Delegate>> constructorDelegates, ConcurrentDictionary<string, ConcurrentDictionary<string, MethodInfo>> processRequestMethods)
        {
            using (WechatEntities entities = new WechatEntities())
            {
                var query = entities.WechatAccounts.Where(temp => type.Namespace.StartsWith(temp.Namespace) == true);
                foreach (var wechatAccount in query)
                {
                    try
                    {
                        // 获取无参构造函数。
                        var constructor = type.GetConstructor(Type.EmptyTypes);

                        // 获取 ProcessRequest 方法。
                        var processRequest = type.GetMethod("ProcessRequest");

                        if (constructor != null && processRequest != null)
                        {
                            // 生成构造函数委托。
                            var constructorDelegate = Expression.Lambda(Expression.New(constructor)).Compile();

                            var key = type.Name.Replace("Handler", string.Empty).ToLower();

                            if (constructorDelegates.ContainsKey(wechatAccount.WechatId) == false)
                            {
                                constructorDelegates.TryAdd(wechatAccount.WechatId, new ConcurrentDictionary<string, Delegate>());
                            }

                            bool addConstructorDelegate = constructorDelegates[wechatAccount.WechatId].TryAdd(key, constructorDelegate);

                            if (processRequestMethods.ContainsKey(wechatAccount.WechatId) == false)
                            {
                                processRequestMethods.TryAdd(wechatAccount.WechatId, new ConcurrentDictionary<string, MethodInfo>());
                            }

                            bool addProcessRequestMethod = processRequestMethods[wechatAccount.WechatId].TryAdd(key, processRequest);

                            if (addConstructorDelegate == false && addProcessRequestMethod == true)
                            {
                                // 添加 ProcessRequest 方法成功，但添加构造函数委托失败。
                                processRequestMethods[wechatAccount.WechatId].TryRemove(key, out processRequest);
                            }

                            if (addConstructorDelegate == true && addProcessRequestMethod == false)
                            {
                                // 添加构造函数委托成功，但添加 ProcessRequest 方法失败。
                                constructorDelegates[wechatAccount.WechatId].TryRemove(key, out constructorDelegate);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }
        }
    }
}
