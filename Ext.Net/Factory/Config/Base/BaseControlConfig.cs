/********
 * @version   : 2.0.0.beta3 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;
using System.Web.UI.WebControls;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public abstract partial class BaseControl
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public partial class Config : IApply
        {
            // Hide default object Methods
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override string ToString()
            {
                return base.ToString();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            new public Type GetType()
            {
                return base.GetType();
            }


            /*  Properties
                -----------------------------------------------------------------------------------------------*/

            /// <summary>
            /// An itemId can be used as an alternative way to get a reference to a component when no object reference is available.
            /// </summary>
            public virtual string ItemID { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [Description("")]
            public virtual bool Enabled { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [Description("")]
            public virtual short TabIndex { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [Description("")]
            public virtual bool IsInForm { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [Description("")]
            public virtual Unit Height { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [Description("")]
            public virtual Unit Width { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [ReadOnly(true)]
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            [Description("")]
            public virtual string ToolTip { get; set; }


            /*  Methods
                -----------------------------------------------------------------------------------------------*/

            /// <summary>
            /// 
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            [Description("")]
            public object ApplyIf(object obj)
            {
                return this.Apply(obj);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="obj"></param>
            /// <returns></returns>
            [Description("")]
            public T Apply<T>(object obj) where T : IApply
            {
                return (T)this.Apply(obj);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            [Description("")]
            public object Apply(object obj)
            {
                return X.Apply(this, obj);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            [Description("")]
            public virtual string ToScript()
            {
                return JSON.Serialize(this);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="config"></param>
            /// <returns></returns>
            [Description("")]
            public static Config ToConfig(string config)
            {
                return JSON.Deserialize<Config>(config); 
            }

            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="TConfig"></typeparam>
            /// <param name="config"></param>
            /// <returns></returns>
            [Description("")]
            public static TConfig ToConfig<TConfig>(string config)
                where TConfig : Config
            {
                return JSON.Deserialize<TConfig>(config) as TConfig;
            }
        }
    }
}