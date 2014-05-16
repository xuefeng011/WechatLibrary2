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
        public static void InitVoiceHandlerDelegate(Type voiceHandlerType)
        {
            using (WechatEntities entities = new WechatEntities())
            {
                var query = entities.WechatAccounts.Where(temp => temp.Namespace == voiceHandlerType.Namespace);
                foreach (var wechatAccount in query)
                {
                    var constructor = voiceHandlerType.GetConstructor(Type.EmptyTypes);
                    if (constructor != null)
                    {
                        // 生成构造函数委托。
                        var constructorDelegate = Expression.Lambda(Expression.New(constructor)).Compile();
                        lock (Cache.Cache.VoiceHandlerDelegates)
                        {
                            if (Cache.Cache.VoiceHandlerDelegates.ContainsKey(wechatAccount.WechatId) == false)
                            {
                                Cache.Cache.VoiceHandlerDelegates.Add(wechatAccount.WechatId, constructorDelegate);
                            }
                            else
                            {
                                throw new TypeInitializationException("IVoiceHandler", new Exception("已存在一个实现该接口的类。"));
                            }
                        }
                    }
                }
            }
        }
    }
}
