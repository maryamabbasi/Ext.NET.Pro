/********
 * @version   : 2.0.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-24
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.Web.Mvc;

namespace Ext.Net.MVC
{
    /// <summary>
    /// 
    /// </summary>
    public class StoreResult : ActionResult
    {
        /// <summary>
        /// 
        /// </summary>
        public StoreResult() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public StoreResult(object data)
        {
            this.Data = data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="totalCount"></param>
        public StoreResult(object data, int totalCount) : this(data)
        {
            this.Total = totalCount;
        }

        /// <summary>
        /// 
        /// </summary>
        public object Data
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Total
        {
            get;
            set;
        }

        private bool success = true;        

        /// <summary>
        /// 
        /// </summary>
        public bool Success
        {
            get { return this.success; }
            set { this.success = value; }
        }

        /// <summary>
        /// 
        /// </summary>        
        public string Message
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsTree
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            StoreResponseData storeResponse = new StoreResponseData(this.IsTree);
            storeResponse.Data = JSON.Serialize(this.Data);
            storeResponse.Total = this.Total;
            storeResponse.Success = this.Success;
            storeResponse.Message = this.Message;
            storeResponse.Return();
        }
    }
}