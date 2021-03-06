/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Text;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>    
    [Description("")]
    public partial class NodeCollection : BaseItemCollection<Node>, ICustomConfigSerialization
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        [ConfigOption(JsonMode.ObjectAllowEmpty)]
        public Node Primary
        {
            get
            {
                if (this.Count > 0)
                {
                    return this[0];
                }
                
                return null;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public NodeCollection() : this(false) { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public NodeCollection(bool single)
        {
            this.SingleItemMode = single;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string ToJson()
        {
            StringBuilder sb = new StringBuilder(256);
            bool comma = false;
            sb.Append("[");

            foreach (Node node in this)
            {
                if (comma)
                {
                    sb.Append(",");
                }

                sb.Append(new ClientConfig().Serialize(node));

                comma = true;
            }
            sb.Append("]");

            return sb.ToString();
        }

        public string ToScript(System.Web.UI.Control owner)
        {
            return this.ToJson();
        }
    }
}