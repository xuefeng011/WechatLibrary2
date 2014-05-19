using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using WechatLibrary.Model;

namespace WechatLibrary.Core.Init
{
    public partial class Init
    {
        public static void InitImageHandlerDelegate(Type imageHandlerType)
        {
            using (WechatEntities entities = new WechatEntities())
            {
                var query = entities.WechatAccounts.Where(temp => temp.Namespace == imageHandlerType.Namespace);
                foreach (var wechatAccount in query)
                {
                    var constructor = imageHandlerType.GetConstructor(Type.EmptyTypes);
                    if (constructor != null)
                    {
                        // 生成构造函数委托。
                        var constructorDelegate = Expression.Lambda(Expression.New(constructor)).Compile();
                        lock (Cache.Cache.ImageHandlerConstructorDelegates)
                        {
                            if (Cache.Cache.ImageHandlerConstructorDelegates.ContainsKey(wechatAccount.WechatId) == false)
                            {
                                Cache.Cache.ImageHandlerConstructorDelegates.Add(wechatAccount.WechatId, constructorDelegate);
                            }
                            else
                            {
                                throw new TypeInitializationException("IImageHandler", new Exception("已存在一个实现该接口的类。"));
                            }
                        }
                    }
                }
            }
        }
    }
}
