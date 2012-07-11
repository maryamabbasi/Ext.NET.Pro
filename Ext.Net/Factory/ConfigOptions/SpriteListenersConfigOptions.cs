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
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SpriteListeners
    {
        /// <summary>
        /// 
        /// </summary>
		[Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
        [JsonIgnore]
        public override ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = base.ConfigOptions;
                
                list.Add("click", new ConfigOption("click", new SerializationOptions("click", typeof(ListenerJsonConverter)), null, this.Click ));
                list.Add("mouseUp", new ConfigOption("mouseUp", new SerializationOptions("mouseup", typeof(ListenerJsonConverter)), null, this.MouseUp ));
                list.Add("mouseDown", new ConfigOption("mouseDown", new SerializationOptions("mousedown", typeof(ListenerJsonConverter)), null, this.MouseDown ));
                list.Add("mouseOver", new ConfigOption("mouseOver", new SerializationOptions("mouseover", typeof(ListenerJsonConverter)), null, this.MouseOver ));
                list.Add("mouseOut", new ConfigOption("mouseOut", new SerializationOptions("mouseout", typeof(ListenerJsonConverter)), null, this.MouseOut ));
                list.Add("render", new ConfigOption("render", new SerializationOptions("render", typeof(ListenerJsonConverter)), null, this.Render ));

                return list;
            }
        }
    }
}