/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel;

namespace Ext.Net.MVC
{
    public partial class HasManyAssociationAttribute : AbstractAssociationAttribute
    {
        /// <summary>
        /// True to automatically load the related store from a remote source when instantiated. Defaults to false.
        /// </summary>
        [DefaultValue(false)]
        public virtual bool AutoLoad
        {
            get;
            set;
        }

        /// <summary>
        /// Optionally overrides the default filter that is set up on the associated Store. If this is not set, a filter is automatically created which filters the association based on the configured foreignKey. See intro docs for more details. Defaults to undefined
        /// </summary>
        [DefaultValue(null)]
        public virtual string FilterProperty
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the foreign key on the associated model that links it to the owner model. Defaults to the lowercased name of the owner model plus "_id", e.g. an association with a where a model called Group hasMany Users would create 'group_id' as the foreign key.
        /// </summary>
        [DefaultValue(null)]
        public virtual string ForeignKey
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the function to create on the owner model to retrieve the child store. If not specified, the pluralized name of the child model is used.
        /// </summary>
        [DefaultValue(null)]
        public virtual string Name
        {
            get;
            set;
        }
        
        protected override AbstractAssociation CreateAssociation()
        {
            return new HasManyAssociation { ForeignKey = this.ForeignKey, FilterProperty = this.FilterProperty, AutoLoad = this.AutoLoad, Name = this.Name };
        }
    }
}