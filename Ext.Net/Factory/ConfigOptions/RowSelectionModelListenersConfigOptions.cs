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
    public partial class RowSelectionModelListeners
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
                
                list.Add("beforeDeselect", new ConfigOption("beforeDeselect", new SerializationOptions("beforedeselect", typeof(ListenerJsonConverter)), null, this.BeforeDeselect ));
                list.Add("deselect", new ConfigOption("deselect", new SerializationOptions("deselect", typeof(ListenerJsonConverter)), null, this.Deselect ));
                list.Add("beforeSelect", new ConfigOption("beforeSelect", new SerializationOptions("beforeselect", typeof(ListenerJsonConverter)), null, this.BeforeSelect ));
                list.Add("select", new ConfigOption("select", new SerializationOptions("select", typeof(ListenerJsonConverter)), null, this.Select ));

                return list;
            }
        }
    }
}