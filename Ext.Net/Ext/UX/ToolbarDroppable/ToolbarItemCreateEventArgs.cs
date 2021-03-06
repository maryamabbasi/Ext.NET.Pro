/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class ToolbarItemCreateEventArgs : EventArgs
    {
        private readonly ParameterCollection extraParams;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ToolbarItemCreateEventArgs(ParameterCollection extraParams)
        {
            this.extraParams = extraParams;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ParameterCollection ExtraParams
        {
            get
            {
                return this.extraParams;
            }
        }

        private AbstractComponent item;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public AbstractComponent Item
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
                ResourceManager.ExtraParamsResponse["ra_item"] = value.ToConfig();
            }
        }

        private int index;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public int Index
        {
            get
            {
                return this.index;
            }
            set
            {
                this.index = value;
                ResourceManager.ExtraParamsResponse["ra_index"] = value.ToString();
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool Success
        {
            get { return ResourceManager.AjaxSuccess; }
            set { ResourceManager.AjaxSuccess = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string ErrorMessage
        {
            get { return ResourceManager.AjaxErrorMessage; }
            set { ResourceManager.AjaxErrorMessage = value; }
        }
    }
}