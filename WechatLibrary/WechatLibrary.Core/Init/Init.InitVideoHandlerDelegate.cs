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
        public static void InitVideoHandlerDelegate(Type videoHandlerType)
        {
            using (WechatEntities entities = new WechatEntities())
            {
                var query = entities.WechatAccounts.Where(temp => temp.Namespace == videoHandlerType.Namespace);
                foreach (var wechatAccount in query)
                {
                    var constructor = videoHandlerType.GetConstructor(Type.EmptyTypes);
                    if (constructor != null)
                    {
                        // 生成构造函数委托。
                        var constructorDelegate = Expression.Lambda(Expression.New(constructor)).Compile();
                        lock (Cache.Cache.VideoHandlerDelegates)
                        {
                            if (Cache.Cache.VideoHandlerDelegates.ContainsKey(wechatAccount.WechatId) == false)
                            {
                                Cache.Cache.VideoHandlerDelegates.Add(wechatAccount.WechatId, constructorDelegate);
                            }
                            else
                            {
                                throw new TypeInitializationException("IVideoHandler", new Exception("已存在一个实现该接口的类。"));
                            }
                        }
                    }
                }
            }
        }
    }
}
