using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model;

namespace WechatLibrary.Core.Init
{
    public partial class Init
    {
        public static void InitLocationHandlerDelegate(Type locationHandlerType)
        {
            using (WechatEntities entities = new WechatEntities())
            {
                var query = entities.WechatAccounts.Where(temp => temp.Namespace == locationHandlerType.Namespace);
                foreach (var wechatAccount in query)
                {
                    var constructor = locationHandlerType.GetConstructor(Type.EmptyTypes);
                    if (constructor != null)
                    {
                        // 生成构造函数委托。
                        var constructorDelegate = Expression.Lambda(Expression.New(constructor)).Compile();
                        lock (Cache.Cache.LocationHandlerDelegates)
                        {
                            if (Cache.Cache.LocationHandlerDelegates.ContainsKey(wechatAccount.WechatId) == false)
                            {
                                Cache.Cache.LocationHandlerDelegates.Add(wechatAccount.WechatId, constructorDelegate);
                            }
                            else
                            {
                                throw new TypeInitializationException("ILocationHandler", new Exception("已存在一个实现该接口的类。"));
                            }
                        }
                    }
                }
            }
        }
    }
}
