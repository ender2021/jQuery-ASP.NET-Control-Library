using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace jQuery.NET.Controls
{
    [ToolboxData("<{0}:jFancyBoxContent runat=\"server\" ></{0}:jFancyBoxContent>")]
    [ToolboxBitmap(typeof(ResourceFinder), "jQuery.NET.img.jFancyBoxContent.bmp")]
    [PersistChildren(true), ParseChildren(false)]
    public class jFancyBoxContent : Base.jGenericControl
    {
        #region Properties

        #region Plug-In

        #endregion

        #endregion

        #region Accessors / Mutators

        #region Plug-In

        #endregion

        #region Control


        #endregion

        #endregion

        #region Enums


        #endregion

        #region Constructors

        public jFancyBoxContent() : base()
        {
        }

        #endregion

        #region Lifecycle

        protected override void OnPreRender(EventArgs e)
        {
            
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<div style=\"display:none;\">");
            writer.Write("<div id=\"" + this.ClientID + "\">");
            base.RenderContents(writer);
            writer.Write("</div></div>");
        }

        //protected override void RenderContents(HtmlTextWriter writer)
        //{

        //}


        #endregion

        #region Private Methods



        #endregion
    }
}
