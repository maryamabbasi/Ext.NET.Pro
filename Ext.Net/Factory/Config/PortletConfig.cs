/********
 * @version   : 2.0.0.rc2 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Portlet
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public Portlet(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit Portlet.Config Conversion to Portlet
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator Portlet(Portlet.Config config)
        {
            return new Portlet(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Panel.Config 
        { 
			/*  Implicit Portlet.Config Conversion to Portlet.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator Portlet.Builder(Portlet.Config config)
			{
				return new Portlet.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
        }
    }
}