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
    public partial class CheckboxGroup
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public CheckboxGroup(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit CheckboxGroup.Config Conversion to CheckboxGroup
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator CheckboxGroup(CheckboxGroup.Config config)
        {
            return new CheckboxGroup(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : CheckboxGroupBase.Config 
        { 
			/*  Implicit CheckboxGroup.Config Conversion to CheckboxGroup.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator CheckboxGroup.Builder(CheckboxGroup.Config config)
			{
				return new CheckboxGroup.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private CheckboxGroupListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public CheckboxGroupListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new CheckboxGroupListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private CheckboxGroupDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public CheckboxGroupDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new CheckboxGroupDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}