using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WechatLibrary.Model;
using WechatLibrary.Model.AutoResponse;
using WechatLibrary.Model.AutoResponse.Match;
using WechatLibrary.Model.AutoResponse.Result;
using WechatLibrary.Model.Menu;

namespace Mvc4Test.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            using (WechatLibrary.Model.WechatEntities context = new WechatLibrary.Model.WechatEntities())
            {
                if (context.WechatAccounts.Count() <= 0)
                {
                    WechatAccount wechatAccount;

                    context.WechatAccounts.Add(wechatAccount = new WechatAccount()
                    {
                        Id = Guid.NewGuid(),
                        AppId = "123",
                        Secret = "456",
                        Token = "789",
                        Namespace = "Mvc4Test",
                        WechatId = "toUser",
                        Menu = new Menu()
                        {
                            Id = Guid.NewGuid()
                        }
                    });

                    TextMessageMatch match=new TextMessageMatch();
                    MatchResultMapping mapping=new MatchResultMapping();
                    TextAutoResponseResult result=new TextAutoResponseResult();

                    match.Id = Guid.NewGuid();
                    mapping.Id = Guid.NewGuid();
                    result.Id = Guid.NewGuid();

                    match.MatchContent = "random";
                    match.MatchLevel = 0;
                    match.MatchOption = "contains";
                    match.WechatAccount = wechatAccount;
                    match.MatchResultMapping = mapping;

                    mapping.MatchType = "text";
                    mapping.ResultType = "text";
                    mapping.MatchId = match.Id;
                    mapping.ResultId = result.Id;

                    result.Content = "wowowoww";

                    context.TextMessageMatches.Add(match);
                    context.MatchResultMappings.Add(mapping);
                    context.TextAutoResponseResults.Add(result);

                    context.SaveChanges();
                }
            }

            WechatLibrary.Wechat.ProcessRequest();
            return new EmptyResult();
        }
    }
}
