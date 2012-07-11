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
    public partial class LoadMask
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : BaseItem.Builder<LoadMask, LoadMask.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new LoadMask()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(LoadMask component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(LoadMask.Config config) : base(new LoadMask(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(LoadMask component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to create a single-use mask that is automatically destroyed after loading (useful for page loads), False to persist the mask element reference for multiple uses (e.g., for paged data widgets). Defaults to false.
			/// </summary>
            public virtual LoadMask.Builder ShowMask(bool showMask)
            {
                this.ToComponent().ShowMask = showMask;
                return this as LoadMask.Builder;
            }
             
 			/// <summary>
			/// The text to display in a centered loading message box (defaults to 'Loading...').
			/// </summary>
            public virtual LoadMask.Builder Msg(string msg)
            {
                this.ToComponent().Msg = msg;
                return this as LoadMask.Builder;
            }
             
 			/// <summary>
			/// The CSS class to apply to the loading message element (defaults to 'x-mask-loading').
			/// </summary>
            public virtual LoadMask.Builder MsgCls(string msgCls)
            {
                this.ToComponent().MsgCls = msgCls;
                return this as LoadMask.Builder;
            }
             
 			/// <summary>
			/// Optional Store to which the mask is bound. The mask is displayed when a load request is issued, and hidden on either load success, or load fail.
			/// </summary>
            public virtual LoadMask.Builder StoreID(string storeID)
            {
                this.ToComponent().StoreID = storeID;
                return this as LoadMask.Builder;
            }
             
 			/// <summary>
			/// Whether or not to use a loading message class or simply mask the bound element. Defaults to: true
			/// </summary>
            public virtual LoadMask.Builder UseMsg(bool useMsg)
            {
                this.ToComponent().UseMsg = useMsg;
                return this as LoadMask.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public LoadMask.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.LoadMask(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public LoadMask.Builder LoadMask()
        {
            return this.LoadMask(new LoadMask());
        }

        /// <summary>
        /// 
        /// </summary>
        public LoadMask.Builder LoadMask(LoadMask component)
        {
            return new LoadMask.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public LoadMask.Builder LoadMask(LoadMask.Config config)
        {
            return new LoadMask.Builder(new LoadMask(config));
        }
    }
}