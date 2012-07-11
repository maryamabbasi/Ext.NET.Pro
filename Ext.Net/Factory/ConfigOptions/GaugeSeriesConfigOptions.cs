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
    public partial class GaugeSeries
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
                
                list.Add("type", new ConfigOption("type", null, null, this.Type ));
                list.Add("angleField", new ConfigOption("angleField", null, "", this.AngleField ));
                list.Add("donut", new ConfigOption("donut", null, 0, this.Donut ));
                list.Add("highlightDuration", new ConfigOption("highlightDuration", null, 150, this.HighlightDuration ));
                list.Add("needle", new ConfigOption("needle", null, false, this.Needle ));
                list.Add("showInLegend", new ConfigOption("showInLegend", null, false, this.ShowInLegend ));
                list.Add("style", new ConfigOption("style", new SerializationOptions(JsonMode.Object), null, this.Style ));
                list.Add("colorSet", new ConfigOption("colorSet", new SerializationOptions(typeof(StringArrayJsonConverter)), null, this.ColorSet ));

                return list;
            }
        }
    }
}