/********
 * @version   : 2.0.0.rc2 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    public partial class FieldContainerDirectEvents : ContainerDirectEvents
    {
        public FieldContainerDirectEvents() { }

        public FieldContainerDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent fieldErrorChange;

        /// <summary>
        /// Fires when the active error message is changed for any one of the Ext.form.Labelable instances within this container.
        /// Parameters
        /// item : Ext.form.FieldAncestor
        /// field : Ext.form.Labelable
        ///     Labelable instance whose active error was changed
        /// error : String
        ///     The active error message
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "field")]
        [ListenerArgument(2, "error")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("fielderrorchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the active error message is changed for any one of the Ext.form.Labelable instances within this container.")]
        public virtual ComponentDirectEvent FieldErrorChange
        {
            get
            {
                return this.fieldErrorChange ?? (this.fieldErrorChange = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent fieldValidityChange;

        /// <summary>
        /// Fires when the validity state of any one of the Ext.form.field.Field instances within this container changes.
        /// Parameters
        /// item : Ext.form.FieldAncestor
        /// field : Ext.form.Labelable
        ///     Field instance whose validity changed
        /// isValid : bool
        ///     The field's new validity state
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "field")]
        [ListenerArgument(2, "isValid")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("fieldvaliditychange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the validity state of any one of the Ext.form.field.Field instances within this container changes.")]
        public virtual ComponentDirectEvent FieldValidityChange
        {
            get
            {
                return this.fieldValidityChange ?? (this.fieldValidityChange = new ComponentDirectEvent(this));
            }
        }
    }
}
