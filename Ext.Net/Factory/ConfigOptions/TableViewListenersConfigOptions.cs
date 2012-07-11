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
    public partial class TableViewListeners
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
                
                list.Add("uIEvent", new ConfigOption("uIEvent", new SerializationOptions("uievent", typeof(ListenerJsonConverter)), null, this.UIEvent ));
                list.Add("bodyScroll", new ConfigOption("bodyScroll", new SerializationOptions("bodyscroll", typeof(ListenerJsonConverter)), null, this.BodyScroll ));
                list.Add("rowFocus", new ConfigOption("rowFocus", new SerializationOptions("rowfocus", typeof(ListenerJsonConverter)), null, this.RowFocus ));
                list.Add("cellFocus", new ConfigOption("cellFocus", new SerializationOptions("cellfocus", typeof(ListenerJsonConverter)), null, this.CellFocus ));
                list.Add("beforeCellMouseDown", new ConfigOption("beforeCellMouseDown", new SerializationOptions("beforecellmousedown", typeof(ListenerJsonConverter)), null, this.BeforeCellMouseDown ));
                list.Add("beforeCellMouseUp", new ConfigOption("beforeCellMouseUp", new SerializationOptions("beforecellmouseup", typeof(ListenerJsonConverter)), null, this.BeforeCellMouseUp ));
                list.Add("beforeCellClick", new ConfigOption("beforeCellClick", new SerializationOptions("beforecellclick", typeof(ListenerJsonConverter)), null, this.BeforeCellClick ));
                list.Add("beforeCellDblClick", new ConfigOption("beforeCellDblClick", new SerializationOptions("beforecelldblclick", typeof(ListenerJsonConverter)), null, this.BeforeCellDblClick ));
                list.Add("beforeCellContextMenu", new ConfigOption("beforeCellContextMenu", new SerializationOptions("beforecellcontextmenu", typeof(ListenerJsonConverter)), null, this.BeforeCellContextMenu ));
                list.Add("beforeCellKeyDown", new ConfigOption("beforeCellKeyDown", new SerializationOptions("beforecellkeydown", typeof(ListenerJsonConverter)), null, this.BeforeCellKeyDown ));
                list.Add("cellMouseDown", new ConfigOption("cellMouseDown", new SerializationOptions("cellmousedown", typeof(ListenerJsonConverter)), null, this.CellMouseDown ));
                list.Add("cellMouseUp", new ConfigOption("cellMouseUp", new SerializationOptions("cellmouseup", typeof(ListenerJsonConverter)), null, this.CellMouseUp ));
                list.Add("cellClick", new ConfigOption("cellClick", new SerializationOptions("cellclick", typeof(ListenerJsonConverter)), null, this.CellClick ));
                list.Add("cellDblClick", new ConfigOption("cellDblClick", new SerializationOptions("celldblclick", typeof(ListenerJsonConverter)), null, this.CellDblClick ));
                list.Add("cellContextMenu", new ConfigOption("cellContextMenu", new SerializationOptions("cellcontextmenu", typeof(ListenerJsonConverter)), null, this.CellContextMenu ));
                list.Add("cellKeyDown", new ConfigOption("cellKeyDown", new SerializationOptions("cellkeydown", typeof(ListenerJsonConverter)), null, this.CellKeyDown ));
                list.Add("beforeDrop", new ConfigOption("beforeDrop", new SerializationOptions("beforedrop", typeof(ListenerJsonConverter)), null, this.BeforeDrop ));
                list.Add("drop", new ConfigOption("drop", new SerializationOptions("drop", typeof(ListenerJsonConverter)), null, this.Drop ));

                return list;
            }
        }
    }
}