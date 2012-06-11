/********
 * @version   : 2.0.0.beta3 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class BarSeries
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : CartesianSeries.Builder<BarSeries, BarSeries.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new BarSeries()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(BarSeries component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(BarSeries.Config config) : base(new BarSeries(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(BarSeries component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Whether to set the visualization as column chart or horizontal bar chart.
			/// </summary>
            public virtual BarSeries.Builder Column(bool column)
            {
                this.ToComponent().Column = column;
                return this as BarSeries.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual BarSeries.Builder Stacked(bool stacked)
            {
                this.ToComponent().Stacked = stacked;
                return this as BarSeries.Builder;
            }
             
 			/// <summary>
			/// The gutter space between groups of bars, as a percentage of the bar width. Defaults to: 38.2
			/// </summary>
            public virtual BarSeries.Builder GroupGutter(double groupGutter)
            {
                this.ToComponent().GroupGutter = groupGutter;
                return this as BarSeries.Builder;
            }
             
 			/// <summary>
			/// The gutter space between single bars, as a percentage of the bar width. Defaults to: 38.2
			/// </summary>
            public virtual BarSeries.Builder Gutter(double gutter)
            {
                this.ToComponent().Gutter = gutter;
                return this as BarSeries.Builder;
            }
             
 			/// <summary>
			/// Padding between the left/right axes and the bars. Defaults to: 0
			/// </summary>
            public virtual BarSeries.Builder XPadding(int xPadding)
            {
                this.ToComponent().XPadding = xPadding;
                return this as BarSeries.Builder;
            }
             
 			/// <summary>
			/// Padding between the top/bottom axes and the bars. Defaults to: 10
			/// </summary>
            public virtual BarSeries.Builder YPadding(int yPadding)
            {
                this.ToComponent().YPadding = yPadding;
                return this as BarSeries.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual BarSeries.Builder Style(SpriteAttributes style)
            {
                this.ToComponent().Style = style;
                return this as BarSeries.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public BarSeries.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.BarSeries(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public BarSeries.Builder BarSeries()
        {
            return this.BarSeries(new BarSeries());
        }

        /// <summary>
        /// 
        /// </summary>
        public BarSeries.Builder BarSeries(BarSeries component)
        {
            return new BarSeries.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public BarSeries.Builder BarSeries(BarSeries.Config config)
        {
            return new BarSeries.Builder(new BarSeries(config));
        }
    }
}