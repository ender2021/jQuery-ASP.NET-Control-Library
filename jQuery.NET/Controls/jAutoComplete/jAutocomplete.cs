using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using jQuery.NET.Utility;
using Newtonsoft.Json;

namespace jQuery.NET.Controls
{
    [ToolboxData("<{0}:jAutocomplete runat=\"server\" ></{0}:jAutocomplete>")]
    [ToolboxBitmap(typeof(ResourceFinder), "jQuery.NET.img.jAutocomplete.bmp")]
    public class jAutocomplete : Base.jTextBoxControl
    {
        #region Properties


        #endregion

        #region Accessors / Mutators

        #region Control

        /// <summary>
        /// Select the jQuery UI theme to use. Select None if you are providing your own theme.  Default is UiLightness.
        /// </summary>
        public UIThemes UITheme { get; set; }

        /// <summary>
        /// The data to bind to this control.  If you use this option and the data objects are not strings,
        /// be sure to set DataFieldName. Default is null.
        /// </summary>
        public IEnumerable DataSource { get; set; }

        /// <summary>
        /// The field name of the DataSource objects which contains the autocomplete data. Default is string.Empty.
        /// </summary>
        public string DataFieldName { get; set; }

        /// <summary>
        /// The URL that will provide the data to this control.  Used for providing data via Ajax.
        /// The query string parameter "term={SEARCH_TERM}" will be appended to the URL.
        /// </summary>
        public string DataSourceUrl { get; set; }

        /// <summary>
        /// Sets the maximum height of the suggestion list - a scroll bar will be added if items overflow this height.
        /// </summary>
        public Unit MaxHeight { get; set; }

        #endregion

        #endregion

        #region Constructors

        public jAutocomplete() : base()
        {
            this.IncludeJqueryUI = true;
            this.UITheme = UIThemes.UiLightness;
            this.DataSource = null;
            this.DataSourceUrl = string.Empty;
            this.DataFieldName = string.Empty;
            this.MaxHeight = 0;
        }

        #endregion

        #region Lifecycle

        protected override void OnPreRender(EventArgs e)
        {
            //register jquery
            Helper.RegisterJquery();

            //register jqueryUI and theme
            Helper.RegisterJqueryUI();
            Helper.RegisterUITheme(this.UITheme);

            //some style adjustments
            var adjustStr = ".ui-widget-content a{display:block;}";
            if (this.MaxHeight != 0)
            {
                adjustStr += '#' + this.ClientID + "-option-holder .ui-autocomplete{";
                adjustStr += "max-height:" + this.MaxHeight + ";overflow-y:auto;";
                adjustStr += "overflow-x:hidden;padding-right:20px;}";
            }
            var adjust = new jWebResource("autocomplete-css-adjust", adjustStr, jWebResourceType.Css);
            adjust.Register(Page);

            //this format string will build a onDomReady jquery handler to initialize galleria
            var initFormat = new StringBuilder("jQuery(function(){{");
            initFormat.Append("jQuery('#{0}').autocomplete({1});");
            initFormat.Append("jQuery('{0}-option-holder').css('width',jQuery('#{0}').width());");
            initFormat.Append("jQuery('{0}-option-holder').css('width',jQuery('#{0}').width());");
            initFormat.Append("}});");

            //build out the options string
            var optionStr = JsonConvert.SerializeObject(BuildOptions());

            //compose the init body
            var initBody = string.Format(initFormat.ToString(), this.ClientID, optionStr);

            //build the init control
            var initControl = new jWebResource("autocomplete-init-" + this.ClientID, initBody, jWebResourceType.Javascript);

            //register the control
            initControl.Register(Page);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            writer.WriteLine(string.Format("<div id=\"{0}-option-holder\" style=\"position:absolute;\"></div>",
                                           this.ClientID));
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private Dictionary<string,object> BuildOptions()
        {
            var toReturn = new Dictionary<string, object>();

            //parse data
            var data = ParseData();
            //decide how to render it
            if (data.Count() == 1)
            {
                toReturn.Add("source", data[0]);
            }
            else
            {
                toReturn.Add("source", data);
            }

            toReturn.Add("appendTo", '#' + this.ClientID + "-option-holder");

            return toReturn;
        }

        private string[] ParseData()
        {
            var toReturn = new List<string>();
            if (this.DataSource != null)
            {
                var type = this.DataSource.GetType().GetGenericArguments()[0];
                if (type == typeof(string) || type == typeof(String))
                {
                    toReturn.AddRange((IEnumerable<string>)this.DataSource);
                } else
                {
                    var strField = this.DataFieldName;
                    if (strField == string.Empty)
                    {
                        strField = "ToString";
                    }
                    foreach (var ds in this.DataSource)
                    {
                        toReturn.Add(
                            (string)ds.GetType().GetProperty(strField).GetValue(ds, null));
                    }
                }
            }
            else if (this.DataSourceUrl != "")
            {
                toReturn.Add(jControlHelper.ParseVirtualUrl(this.DataSourceUrl));
            }
            return toReturn.ToArray();
        }

        #endregion
    }
}
