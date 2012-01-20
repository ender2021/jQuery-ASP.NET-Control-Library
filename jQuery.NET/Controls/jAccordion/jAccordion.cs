using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using jQuery.NET.Utility;
using Newtonsoft.Json;
using jQuery.NET.Utility.jQueryUI;

namespace jQuery.NET.Controls
{
    [ToolboxData("<{0}:jAccordion runat=\"server\" ></{0}:jAccordion>")]
    [ToolboxBitmap(typeof(ResourceFinder), "jQuery.NET.img.jAccordion.bmp")]
    [ParseChildren(ChildrenAsProperties = true)]
    public class jAccordion : Base.jGenericControl
    {

        #region Properties

        private bool _autoHeight = true;
        private bool _collapsible = false;
        private bool _navigationEnabled = false;
        private int _startIndex = 0;
        private bool _startCollapsed = false;
        private Icons _openIcon = Icons.Triangle1S;
        private Icons _closedIcon = Icons.Triangle1E;

        #endregion

        #region Accessors / Mutators

        #region Plug-In

        /// <summary>
        /// Set to true to disable icons in the accordion panel headers.  Default is false.
        /// </summary>
        public bool DisableIcons { get; set; }

        /// <summary>
        /// Set to false to allow panels to maintain their native height. Default is true.
        /// </summary>
        public bool AutoHeight
        {
            get { return _autoHeight; }
            set
            {
                Helper.SetFlag(PropertyFlags.AutoHeight);
                _autoHeight = value;
            }
        }

        /// <summary>
        /// Set to true to allow all panels to be collapsed.  Default is false.
        /// Note: If StartCollapsed is set to true, Collapsible will be automatically set to true, and cannot be overridden.
        /// </summary>
        public bool Collapsible
        {
            get { return _collapsible; }
            set
            {
                Helper.SetFlag(PropertyFlags.Collapsible);
                _collapsible = value;
            }
        }

        /// <summary>
        /// Set to true to allow direct navigation to individual panels. Default is false.
        /// Example: Navigating to http://myurl.com/#panel1 would cause any accordion panel with ID "panel1" to start as open.
        /// </summary>
        public bool NavigationEnabled
        {
            get { return _navigationEnabled; }
            set
            {
                Helper.SetFlag(PropertyFlags.NavigationEnabled);
                _navigationEnabled = value;
            }
        }

        /// <summary>
        /// The index of the panel to open on page load. Default is 0.
        /// </summary>
        public int StartIndex
        {
            get { return _startIndex; }
            set
            {
                Helper.SetFlag(PropertyFlags.StartIndex);
                _startIndex = value;
            }
        }

        /// <summary>
        /// Set to true to load the page with all panels closed.  Default is false.
        /// Note: If this is set to true, Collapsible will be automatically set to true, and cannot be overridden.
        /// </summary>
        public bool StartCollapsed
        {
            get { return _startCollapsed; }
            set
            {
                Helper.SetFlag(PropertyFlags.StartCollapsed);
                _startCollapsed = value;
            }
        }

        /// <summary>
        /// Specify the jQuery UI Icon to use for open panels. Default is Icons.Triangle1S.
        /// </summary>
        public Icons OpenIcon
        {
            get { return _openIcon; }
            set
            {
                Helper.SetFlag(PropertyFlags.OpenIcon);
                _openIcon = value;
            }
        }

        /// <summary>
        /// Specify the jQuery UI Icon to use for closed panels. Default is Icons.Triangle1E.
        /// </summary>
        public Icons ClosedIcon
        {
            get { return _closedIcon; }
            set
            {
                Helper.SetFlag(PropertyFlags.ClosedIcon);
                _closedIcon = value;
            }
        }

        #endregion

        #region Control

        /// <summary>
        /// Specifies the list of jAccordionPanels to use for this jAccordion. Cannot be used in combination with TemplatePanel/DataSource.
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<jAccordionPanel> Panels { get; set; }

        /// <summary>
        /// The template to use for each panel in the construction of this jAccordion.  This template will be applied to each object in DataSource.
        /// </summary>
        [TemplateContainer(typeof(RepeaterItem))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Browsable(false)]
        public ITemplate TemplatePanel
        {
            get
            {
                return InnerRepeater.ItemTemplate;
            }
            set
            {
                InnerRepeater.ItemTemplate = value;
            }
        }

        /// <summary>
        /// The list of objects to use as the DataSource for this jAccordion.  The template specified with TemplatePanel will be applied to each object.
        /// </summary>
        [Bindable(true)]
        public IEnumerable DataSource
        {
            get
            {
                return (IEnumerable)InnerRepeater.DataSource;
            }
            set
            {
                InnerRepeater.DataSource = value;
            }
        }

        private Repeater InnerRepeater { get; set; }

        /// <summary>
        /// Select the jQuery UI theme to use. Select None if you are providing your own theme.  Default is UiLightness.
        /// </summary>
        public UIThemes UITheme { get; set; }

        #endregion

        #endregion

        #region Enums
        
        private enum PropertyFlags
        {
            AutoHeight,
            Collapsible,
            NavigationEnabled,
            StartIndex,
            StartCollapsed,
            OpenIcon,
            ClosedIcon
        }

        #endregion

        #region Constructors

        public jAccordion() : base()
        {
            this.IncludeJqueryUI = true;
            InnerRepeater = new Repeater();
            TemplatePanel = null;
            DataSource = null;
            Panels = null;
            UITheme = UIThemes.UiLightness;
            DisableIcons = false;
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

            //this format string will build a onDomReady jquery handler to initialize the accordion
            var initFormat = new StringBuilder("jQuery(function(){{");
            initFormat.Append("jQuery('#{0}').accordion({1});");
            initFormat.Append("}});");

            //build out the options string
            var optionStr = JsonConvert.SerializeObject(BuildOptions());

            //compose the init body
            var initBody = string.Format(initFormat.ToString(), this.ClientID, optionStr);

            //build the init control
            var initControl = new jWebResource("accordion-init-" + this.ClientID, initBody, jWebResourceType.Javascript);

            //register the control
            initControl.Register(Page);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            
            writer.WriteLine(BuildContainerString());
            if (TemplatePanel != null && DataSource != null)
            {
                InnerRepeater.RenderControl(writer);
            }
            else
            {
                this.RenderContents(writer);
            }
            writer.WriteLine("</div>");
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (this.Panels != null)
            {
                foreach (var panel in Panels)
                {
                    panel.RenderControl(writer);
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// If you are providing data to this jAccordion via DataSource, you must call DataBind() after setting the source.
        /// </summary>
        public new void DataBind()
        {
            InnerRepeater.DataBind();
        }

        #endregion

        #region Private Methods

        private Dictionary<string,object> BuildOptions()
        {
            var toReturn = new Dictionary<string, object>();

            if (Helper.GetFlag(PropertyFlags.AutoHeight))
            {
                toReturn.Add("autoHeight", this.AutoHeight);
            }

            if (Helper.GetFlag(PropertyFlags.NavigationEnabled))
            {
                toReturn.Add("navigation", this.NavigationEnabled);
            }

            if (Helper.GetFlag(PropertyFlags.StartIndex) || StartCollapsed)
            {
                object start = null;
                if (StartCollapsed)
                {
                    start = false;
                    Collapsible = true;
                }
                else 
                {
                    start = StartIndex;
                }
                toReturn.Add("active", start);
            }

            if (Helper.GetFlag(PropertyFlags.Collapsible))
            {
                toReturn.Add("collapsible", this.Collapsible);
            }

            if (!DisableIcons && (Helper.GetFlag(PropertyFlags.OpenIcon) || Helper.GetFlag(PropertyFlags.ClosedIcon)))
            {
                toReturn.Add("icons", new { header = Helper.ParseUIIcon(this.ClosedIcon), headerSelected = Helper.ParseUIIcon(this.OpenIcon)});
            } else if (DisableIcons)
            {
                toReturn.Add("icons", false);
            }

            return toReturn;
        }

        private string BuildContainerString()
        {
            var formatString = new StringBuilder("<div id=\"{0}\" style=\"");
            var args = new List<string>();
            args.Add(this.ClientID);
            if (this.Height.ToString() != string.Empty)
            {
                formatString.Append("height:{" + args.Count + "};");
                args.Add(this.Height.ToString());
            }
            if (this.Width.ToString() != string.Empty)
            {
                formatString.Append("width:{" + args.Count + "};");
                args.Add(this.Width.ToString());
            }
            formatString.Append("\"");
            if (this.CssClass != string.Empty)
            {
                formatString.Append(" class=\"{" + args.Count + "}\"");
                args.Add(this.CssClass);
            }
            formatString.Append(" />");
            return string.Format(formatString.ToString(), args.ToArray());
        }

        #endregion
    }
}
