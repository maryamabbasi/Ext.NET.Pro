/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web;

namespace Ext.Net
{
    internal class HtmlStringLiteralControl : LiteralControl
    {
#if MVC
        IHtmlString htmlString;

        public HtmlStringLiteralControl () : base() 
        {
        }

        public HtmlStringLiteralControl(IHtmlString htmlString) : base()
        {
            this.htmlString = htmlString;
        }
                
        protected override void Render(HtmlTextWriter output)
        {
            output.Write(this.htmlString.ToHtmlString());
        }
#endif
    }
}