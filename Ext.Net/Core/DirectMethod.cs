/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Web;

using Ext.Net.Utilities;

namespace Ext.Net
{
    internal class DirectMethod
    {
        private readonly MethodInfo method;
        private ParameterInfo[] methodParams;
        private string name;
        private readonly DirectMethodAttribute attribute;
        private string controlID;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DirectMethod(MethodInfo method, DirectMethodAttribute attribute)
        {
            this.method = method;
            this.attribute = attribute;
        }

        public virtual DirectMethod Clone()
        {
            DirectMethod dm = new DirectMethod(this.method, this.attribute);

            dm.methodParams = this.Params;
            dm.name = this.Name;
            dm.controlID = this.ControlID;

            return dm;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public MethodInfo Method
        {
            get { return method; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ParameterInfo[] Params
        {
            get
            {
                if (this.methodParams == null)
                {
                    this.methodParams = method.GetParameters();
                }

                return methodParams;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Name
        {
            get
            {
                if (this.name == null)
                {
                    this.name = this.Method.Name;
                }

                return name;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string ControlID
        {
            get
            {
                return this.controlID;
            }
            set
            {
                this.controlID = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DirectMethodAttribute Attribute
        {
            get { return attribute; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public object Invoke()
        {
            return this.Invoke(null, HttpContext.Current, null);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public object Invoke(object target)
        {
            return this.Invoke(target, HttpContext.Current, null);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public object Invoke(object target, ParameterCollection args)
        {
            return this.Invoke(target, HttpContext.Current, args);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public object Invoke(object target, HttpContext context, ParameterCollection args)
        {
            object[] parameters = new object[this.Params.Length];
            int index = 0;

            foreach (ParameterInfo param in this.Params)
            {
                string paramValue = args != null ? args[param.Name] : (context.Request.RequestType == "POST" ? context.Request.Form[param.Name] : context.Request[param.Name]);

                if (paramValue == null)
                {
                    throw new ArgumentException("DirectMethod: '{0}', The parameter '{1}' is undefined".FormatWith(method.Name, param.Name));
                }

                if (param.ParameterType == typeof(string))
                {
                    parameters[index++] = paramValue;                    
                }
                else
                {
                    switch(param.ParameterType.Name)
                    {
                        case "Guid":
                            parameters[index++] = new Guid(paramValue);
                            break;
                        default:
                            parameters[index++] = JSON.Deserialize(paramValue, param.ParameterType);
                            break;
                    }
                }
            }

            context.Items["Ext.Net.InsideDirectMethod"] = true;
            
            object result = method.Invoke(target, parameters);
            context.Items.Remove("Ext.Net.InsideDirectMethod");
            
            return result;
        }

        internal static bool IsStaticMethodRequest(HttpRequest request)
        {
            string[] values = request.Headers.GetValues("X-Ext.Net");

            if (values != null)
            {
                foreach (string value in values)
                {
                    if (value.ToLowerInvariant().Contains("staticmethod=true"))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void GenerateProxy(StringBuilder sb, string controlID, string url)
        {
            sb.Append(this.Attribute.Alias.IsEmpty() ? this.Name : this.Attribute.Alias);
            sb.Append(":function(");

            ParameterInfo[] parameters = this.PrepareParams(this.Params);

            foreach (ParameterInfo parameterInfo in parameters)
            {
                sb.Append(parameterInfo.Name);
                sb.Append(",");
            }
            sb.Append("config");
            sb.Append("){");
            sb.Append("return Ext.net.DirectMethod.request(\"");
            sb.Append(this.Name);
            sb.Append("\",Ext.applyIf(config || {}, {");

            int index = 0;
            bool needComma = false;

            if (this.Params.Length>0)
            {
                sb.Append("params:{");

                foreach (ParameterInfo parameterInfo in this.Params)
                {
                    sb.Append(parameterInfo.Name);
                    sb.Append(":");
                    sb.AppendFormat(parameterInfo.Name);
                    index++;

                    if (index < this.Params.Length)
                    {
                        sb.Append(",");
                    }
                }
                sb.Append("}");
                needComma = true;
            }

            if (this.Method.IsStatic)
            {
                sb.Append(needComma ? "," : "");
                sb.Append("specifier:\"static\"");
                sb.AppendFormat(",url:{0}", JSON.Serialize(url));
                needComma = true;
            }
            
            if (controlID.IsNotEmpty())
            {
                sb.Append(needComma ? "," : "");
                sb.AppendFormat("control:\"{0}\"", controlID);
                needComma = true;
            }

            if (this.Attribute.Method == HttpMethod.GET)
            {
                sb.Append(needComma ? "," : "");
                sb.Append("method:\"GET\"");
                needComma = true;
            }

            if (this.Attribute.ShowMask)
            {
                sb.Append(needComma ? "," : "");
                sb.Append("eventMask:{showMask:true");
                
                if (this.Attribute.Msg.IsNotEmpty())
                {
                    sb.Append(",msg:").Append(JSON.Serialize(this.Attribute.Msg));
                }

                if (this.Attribute.MsgCls.IsNotEmpty())
                {
                    sb.Append(",msgCls:").Append(JSON.Serialize(this.Attribute.MsgCls));
                }

                if (this.Attribute.CustomTarget.IsNotEmpty())
                {
                    this.Attribute.Target = MaskTarget.CustomTarget;
                }

                if (this.Attribute.Target != MaskTarget.Page)
                {
                    sb.Append(",target:").Append(JSON.Serialize(this.Attribute.Target.ToString().ToLowerInvariant()));
                }

                if (this.Attribute.Target == MaskTarget.CustomTarget && this.Attribute.CustomTarget.IsNotEmpty())
                {
                    ResourceManager sm = null;

                    if (HttpContext.Current != null)
                    {
                        sm = ResourceManager.GetInstance(HttpContext.Current);
                    }

                    string script = TokenUtils.ReplaceRawToken((sm != null) ? TokenUtils.ParseTokens(this.Attribute.CustomTarget, sm) : TokenUtils.ParseAndNormalize(this.Attribute.CustomTarget));

                    sb.Append(",customTarget:").Append(script);
                }

                sb.Append("}");
                needComma = true;
            }

            if (this.Attribute.Type == DirectEventType.Load)
            {
                sb.Append(needComma ? "," : "");
                sb.Append("type:\"load\"");
                needComma = true;
            }

            if (this.Attribute.ViewStateMode != ViewStateMode.Inherit)
            {
                sb.Append(needComma ? "," : "");
                sb.AppendFormat("viewStateMode:\"{0}\"", this.Attribute.ViewStateMode.ToString().ToLowerInvariant());
                needComma = true;
            }

            if (this.Attribute.RethrowException)
            {
                sb.Append(needComma ? "," : "");
                sb.AppendFormat("rethrowException:{0}", this.Attribute.RethrowException.ToString().ToLowerInvariant());
                needComma = true;
            }


            if (this.Attribute.Timeout != 30000)
            {
                sb.Append(needComma ? "," : "");
                sb.AppendFormat("timeout:{0}", this.Attribute.Timeout);
                needComma = true;
            }

            if (!this.Attribute.DisableCaching)
            {
                sb.Append(needComma ? "," : "");
                sb.AppendFormat("disableCaching:{0}", this.Attribute.DisableCaching.ToString().ToLowerInvariant());
                needComma = true;
            }
			
			if (!this.Attribute.Async)
            {
                sb.Append(needComma ? "," : "");
                sb.Append("async:false");
                needComma = true;
            }

            if (this.Attribute.DisableCachingParam != "_dc")
            {
                sb.Append(needComma ? "," : "");
                sb.AppendFormat("disableCachingParam:{0}", this.Attribute.DisableCachingParam);
                needComma = true;
            }

            if (this.Attribute.SuccessFn.IsNotEmpty())
            {
                sb.Append(needComma ? "," : "");
                sb.AppendFormat("success:{0}", this.Attribute.SuccessFn);
                needComma = true;
            }

            if (this.Attribute.CompleteFn.IsNotEmpty())
            {
                sb.Append(needComma ? "," : "");
                sb.AppendFormat("complete:{0}", this.Attribute.CompleteFn);
                needComma = true;
            }

            if (this.Attribute.FormID.IsNotEmpty())
            {
                sb.Append(needComma ? "," : "");
                sb.AppendFormat("formId:{0}", this.Attribute.FormID);
                needComma = true;
            }

            if (this.Attribute.FailureFn.IsNotEmpty())
            {
                sb.Append(needComma ? "," : "");
                sb.AppendFormat("failure:{0}", this.Attribute.FailureFn);
            }

            this.AppendParams(sb, needComma);
            
            sb.Append("}));}");
        }

        protected virtual void AppendParams(StringBuilder sb, bool needComma)
        {            
        }

        protected virtual ParameterInfo[] PrepareParams(ParameterInfo[] parameters)
        {
            return parameters;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    [Description("")]
    public partial class DirectMethodAttribute : Attribute
    {
        private string failureFn;
        private HttpMethod method = HttpMethod.POST;
        private ClientProxy proxyCreation;
        private string successFn;
        private string completeFn;
        private DirectEventType type = DirectEventType.Submit;
        private string msg;
        private string msgCls;
        private MaskTarget target = MaskTarget.Page;
        private string customTarget;
        private bool showMask;
        private ViewStateMode viewStateMode = ViewStateMode.Inherit;
        private string directMethodNamespace;
        private int timeout = 30000;
        private bool rethrowException = false;
        private string alias;
        private string idAlias;
        private bool disableCaching = true;
		private bool async = true;
        private string disableCachingParam = "_dc";
        private DirectMethodProxyIDMode idMode = DirectMethodProxyIDMode.Default;
        private string formId;

        /// <summary>
        /// 
        /// </summary>
        public virtual DirectMethodProxyIDMode IDMode
        {
            get
            {
                return this.idMode;
            }
            set
            {
                this.idMode = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual string IDAlias
        {
            get { return this.idAlias; }
            set 
            { 
                this.idAlias = value;
                if (value.IsNotEmpty() && this.IDMode == DirectMethodProxyIDMode.Default)
                {
                    this.IDMode = DirectMethodProxyIDMode.Alias;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual string Alias
        {
            get { return this.alias; }
            set { this.alias = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual string FailureFn
        {
            get { return this.failureFn; }
            set { this.failureFn = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual HttpMethod Method
        {
            get { return this.method; }
            set { this.method = value; }
        }

        /// <summary>
        /// Rethrow an exception (exception will be unhandled)
        /// </summary>
        public virtual bool RethrowException
        {
            get
            {
                return this.rethrowException;
            }
            set
            {
                this.rethrowException = value;
            }
        }

        /// <summary>
        /// The timeout in milliseconds to be used for requests. (defaults to 30000)
        /// </summary>
        public virtual int Timeout
        {
            get
            {
                return this.timeout;
            }
            set
            {
                this.timeout = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual ClientProxy ClientProxy
        {
            get
            {
                if (this.proxyCreation == ClientProxy.Default)
                {
                    if (HttpContext.Current != null)
                    {
                        ResourceManager sm = ResourceManager.GetInstance(HttpContext.Current);
                        return sm != null ? sm.DirectMethodProxy : ClientProxy.Default;
                    }
                    return ClientProxy.Default;
                }

                return this.proxyCreation;
            }
            set { this.proxyCreation = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string SuccessFn
        {
            get { return this.successFn; }
            set { this.successFn = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string CompleteFn
        {
            get { return this.completeFn; }
            set { this.completeFn = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual DirectEventType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
		
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual bool Async
        {
            get
            {
                return this.async;
            }
            set
            {
                this.async = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual bool ShowMask
        {
            get
            {
                return this.showMask;
            }
            set
            {
                this.showMask = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Localizable(true)]
        [Description("")]
        public virtual string Msg
        {
            get
            {
                return this.msg;
            }
            set
            {
                this.msg = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string MsgCls
        {
            get
            {
                return this.msgCls;
            }
            set
            {
                this.msgCls = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual string FormID
        {
            get
            {
                return this.formId;
            }
            set
            {
                this.formId = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual MaskTarget Target
        {
            get
            {
                return this.target;
            }
            set
            {
                this.target = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string CustomTarget
        {
            get
            {
                return this.customTarget;
            }
            set
            {
                this.customTarget = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ViewStateMode ViewStateMode
        {
            get
            {
                if (this.viewStateMode == ViewStateMode.Inherit)
                {
                    if (HttpContext.Current != null)
                    {
                        ResourceManager sm = ResourceManager.GetInstance(HttpContext.Current);

                        if (sm == null)
                        {
                            return ViewStateMode.Inherit;
                        }
                        return sm.AjaxViewStateMode;
                    }
                    return ViewStateMode.Inherit;
                }
                else
                {
                    return this.viewStateMode;    
                }
            }
            set
            {
                this.viewStateMode = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string Namespace
        {
            get
            {
                string ns = this.directMethodNamespace;               

                if (ns.IsEmpty())
                {
                    string defaultDirectMethodNamespace = ResourceManager.GlobalNormalizedDirectMethodNamespace;

                    if (HttpContext.Current != null)
                    {
                        ResourceManager sm = ResourceManager.GetInstance(HttpContext.Current);
                        
                        if (sm == null)
                        {
                            return defaultDirectMethodNamespace;
                        }

                        string smValue = sm.NormalizedDirectMethodNamespace;

                        return smValue.IsEmpty() ? defaultDirectMethodNamespace : smValue;
                    }
                    return defaultDirectMethodNamespace;
                }

                if (ns.StartsWith("."))
                {
                    string globalNs = ResourceManager.GlobalNormalizedNamespace;
                    if (HttpContext.Current != null)
                    {
                        ResourceManager sm = ResourceManager.GetInstance(HttpContext.Current);

                        if (sm == null)
                        {
                            return globalNs + ns;
                        }

                        // sm.DirectMethodNamespace == ".direct" - means that there is no explicit value for DirectMethodNamespace
                        // TODO: need to refactor it (find new approach that developer doesn't define direct namespace in resource manager or web.config)
                        return (sm.DirectMethodNamespace == ".direct" ? sm.NormalizedNamespace : sm.NormalizedDirectMethodNamespace) + ns;
                    }                    
                    else
                    {
                        return globalNs + ns;
                    }
                }

                return ns;                
            }
            set
            {
                this.directMethodNamespace = value;
            }
        }

        /// <summary>
        /// True to add a unique cache-buster param to GET requests.
        /// </summary>
        [Description("True to add a unique cache-buster param to GET requests.")]
        public bool DisableCaching
        {
            get
            {
                return this.disableCaching;
            }
            set
            {
                this.disableCaching = value;
            }
        }

        /// <summary>
        /// Change the parameter which is sent went disabling caching through a cache buster. Defaults to '_dc'
        /// </summary>
        [Description("Change the parameter which is sent went disabling caching through a cache buster. Defaults to '_dc'")]
        public string DisableCachingParam
        {
            get
            {
                return this.disableCachingParam;
            }
            set
            {
                this.disableCachingParam = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public enum ClientProxy
    {
        /// <summary>
        /// 
        /// </summary>
        Default,

        /// <summary>
        /// 
        /// </summary>
        Ignore,

        /// <summary>
        /// 
        /// </summary>
        Include
    }
}