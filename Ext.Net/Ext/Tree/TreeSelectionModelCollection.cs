/********
 * @version   : 1.6.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TreeSelectionModelCollection : SingleItemCollection<AbstractTreeSelectionModel>
    {
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(typeof(LazyControlJsonConverter))]
        public AbstractTreeSelectionModel Primary
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
    }
}