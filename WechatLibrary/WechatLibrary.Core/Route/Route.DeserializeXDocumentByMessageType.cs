using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatLibrary.Core.Route
{
    public partial class Route
    {
        public void DeserializeXDocumentByMessageType()
        {
            switch (this.RequestMessageType)
            {
                case "text":
                    {
                        break;
                    }
                case "image":
                    {
                        break;
                    }
            }
        }
    }
}
