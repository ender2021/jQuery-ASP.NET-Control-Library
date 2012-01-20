using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace jQuery.NET.Controls
{
    [ToolboxData("<{0}:jAccordionPanel runat=\"server\" ></{0}:jAccordionPanel>")]
    [ToolboxBitmap(typeof(ResourceFinder), "jQuery.NET.img.jAccordionPanel.bmp")]
    [PersistChildren(true), ParseChildren(false)]
    public class jAccordionPanel : Base.jGenericControl
    {
        #region Properties

        

        #endregion

        #region Accessors / Mutators

        /// <summary>
        /// The title of this panel.
        /// </summary>
        public string Title { get; set; }

        #region Control


        #endregion

        #endregion

        #region Enums


        #endregion

        #region Constructors

        public jAccordionPanel() : base()
        {
        }

        #endregion

        #region Lifecycle

        protected override void OnPreRender(EventArgs e)
        {
            
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write(string.Format("<h3><a href=\"#{0}\">{1}</a></h3>", this.ClientID, this.Title));
            writer.Write(string.Format("<div id=\"{0}\">", this.ClientID));
            base.RenderContents(writer);
            writer.Write("</div>");
        }


        #endregion

        #region Private Methods



        #endregion
    }
}
