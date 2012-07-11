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
    public partial class TabPanelListeners
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
                
                list.Add("beforeTabChange", new ConfigOption("beforeTabChange", new SerializationOptions("beforetabchange", typeof(ListenerJsonConverter)), null, this.BeforeTabChange ));
                list.Add("tabChange", new ConfigOption("tabChange", new SerializationOptions("tabchange", typeof(ListenerJsonConverter)), null, this.TabChange ));
                list.Add("beforeTabClose", new ConfigOption("beforeTabClose", new SerializationOptions("beforetabclose", typeof(ListenerJsonConverter)), null, this.BeforeTabClose ));
                list.Add("beforeTabHide", new ConfigOption("beforeTabHide", new SerializationOptions("beforetabhide", typeof(ListenerJsonConverter)), null, this.BeforeTabHide ));
                list.Add("tabClose", new ConfigOption("tabClose", new SerializationOptions("tabclose", typeof(ListenerJsonConverter)), null, this.TabClose ));
                list.Add("beforeTabMenuShow", new ConfigOption("beforeTabMenuShow", new SerializationOptions("beforetabmenushow", typeof(ListenerJsonConverter)), null, this.BeforeTabMenuShow ));

                return list;
            }
        }
    }
}