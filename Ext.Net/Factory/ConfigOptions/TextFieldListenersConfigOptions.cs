/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
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
    public partial class TextFieldListeners
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
                
                list.Add("autoSize", new ConfigOption("autoSize", new SerializationOptions("autosize", typeof(ListenerJsonConverter)), null, this.AutoSize ));
                list.Add("keyDown", new ConfigOption("keyDown", new SerializationOptions("keydown", typeof(ListenerJsonConverter)), null, this.KeyDown ));
                list.Add("keyPress", new ConfigOption("keyPress", new SerializationOptions("keypress", typeof(ListenerJsonConverter)), null, this.KeyPress ));
                list.Add("keyUp", new ConfigOption("keyUp", new SerializationOptions("keyup", typeof(ListenerJsonConverter)), null, this.KeyUp ));
                list.Add("iconClick", new ConfigOption("iconClick", new SerializationOptions("iconclick", typeof(ListenerJsonConverter)), null, this.IconClick ));

                return list;
            }
        }
    }
}