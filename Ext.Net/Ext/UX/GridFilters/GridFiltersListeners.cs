/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    [ToolboxItem(false)]
    [TypeConverter(typeof(ListenersConverter))]
    public partial class GridFiltersListeners : ComponentListeners
    {
        private ComponentListener filterUpdate;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "item", typeof(object), "plugin")]
        [ListenerArgument(1, "filter", typeof(object), "filter")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("filterupdate", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener FilterUpdate
        {
            get
            {
                if (this.filterUpdate == null)
                {
                    this.filterUpdate = new ComponentListener();
                }

                return this.filterUpdate;
            }
        }
    }
}