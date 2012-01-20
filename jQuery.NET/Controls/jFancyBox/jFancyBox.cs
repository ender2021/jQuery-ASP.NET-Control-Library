using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jQuery.NET.Interfaces;
using jQuery.NET.Utility;
using Newtonsoft.Json;
using Extensions;

namespace jQuery.NET.Controls
{
    [ToolboxData("<{0}:jFancyBox runat=\"server\" ></{0}:jFancyBox>")]
    [ToolboxBitmap(typeof(ResourceFinder), "jQuery.NET.img.jFancyBox.bmp")]
    [PersistChildren(true), ParseChildren(false)]
    public sealed class jFancyBox : Base.jGenericControl
    {

        #region Properties

        #region Plug-In

        private int _padding = 10;
        private int _margin = 20;
        private bool _cyclical = false;
        private ScrollOptions _allowScrollBars = ScrollOptions.Auto;
        private bool _autoScale = true;
        private bool _autoDimensions = true;
        private bool _centerOnScroll = false;
        private bool _showOverlay = true;
        private int _overlayOpacity = 30;
        private string _overlayColor = "#666";
        private bool _showTitle = true;
        private TPositions _titlePosition = TPositions.Outside;
        private TransitionTypes _transitionIn = TransitionTypes.Fade;
        private TransitionTypes _transitionOut = TransitionTypes.Fade;
        private int _speedIn = 300;
        private int _speedOut = 300;
        private int _changeSpeed = 300;
        private int _changeFade = 200;
        private BoxControls _interactionControls = BoxControls.Default;

        #endregion

        #endregion

        #region Accessors / Mutators

        #region Plug-In

        public int Padding
        {
            get { return _padding; }
            set
            {
                Helper.SetFlag(PropertyFlags.Padding);
                _padding = value;
            }
        }

        public int Margin
        {
            get { return _margin; }
            set
            {
                Helper.SetFlag(PropertyFlags.Margin);
                _margin = value;
            }
        }

        public bool Cyclical
        {
            get { return _cyclical; }
            set
            {
                Helper.SetFlag(PropertyFlags.Cyclical);
                _cyclical = value;
            }
        }

        public ScrollOptions AllowScrollBars
        {
            get { return _allowScrollBars; }
            set
            {
                Helper.SetFlag(PropertyFlags.AllowScrollBars);
                _allowScrollBars = value;
            }
        }

        public bool AutoScale
        {
            get { return _autoScale; }
            set
            {
                Helper.SetFlag(PropertyFlags.AutoScale);
                _autoScale = value;
            }
        }

        public bool AutoDimensions
        {
            get { return _autoDimensions; }
            set
            {
                Helper.SetFlag(PropertyFlags.AutoDimensions);
                _autoDimensions = value;
            }
        }

        public bool CenterOnScroll
        {
            get { return _centerOnScroll; }
            set
            {
                Helper.SetFlag(PropertyFlags.CenterOnScroll);
                _centerOnScroll = value;
            }
        }

        public bool ShowOverlay
        {
            get { return _showOverlay; }
            set
            {
                Helper.SetFlag(PropertyFlags.ShowOverlay);
                _showOverlay = value;
            }
        }

        public int OverlayOpacity
        {
            get { return _overlayOpacity; }
            set
            {
                Helper.SetFlag(PropertyFlags.OverlayOpacity);
                _overlayOpacity = value;
            }
        }

        public string OverlayColor
        {
            get { return _overlayColor; }
            set
            {
                Helper.SetFlag(PropertyFlags.OverlayColor);
                _overlayColor = value;
            }
        }

        public bool ShowTitle
        {
            get { return _showTitle; }
            set
            {
                Helper.SetFlag(PropertyFlags.ShowTitle);
                _showTitle = value;
            }
        }

        public TPositions TitlePosition
        {
            get { return _titlePosition; }
            set
            {
                Helper.SetFlag(PropertyFlags.TitlePosition);
                _titlePosition = value;
            }
        }

        public TransitionTypes TransitionIn
        {
            get { return _transitionIn; }
            set
            {
                Helper.SetFlag(PropertyFlags.TransitionIn);
                _transitionIn = value;
            }
        }

        public TransitionTypes TransitionOut
        {
            get { return _transitionOut; }
            set
            {
                Helper.SetFlag(PropertyFlags.TransitionOut);
                _transitionOut = value;
            }
        }

        public int SpeedIn
        {
            get { return _speedIn; }
            set
            {
                Helper.SetFlag(PropertyFlags.SpeedIn);
                _speedIn = value;
            }
        }

        public int SpeedOut
        {
            get { return _speedOut; }
            set
            {
                Helper.SetFlag(PropertyFlags.SpeedOut);
                _speedOut = value;
            }
        }

        public int ChangeSpeed
        {
            get { return _changeSpeed; }
            set
            {
                Helper.SetFlag(PropertyFlags.ChangeSpeed);
                _changeSpeed = value;
            }
        }

        public int ChangeFade
        {
            get { return _changeFade; }
            set
            {
                Helper.SetFlag(PropertyFlags.ChangeFade);
                _changeFade = value;
            }
        }

        public BoxControls InteractionControls
        {
            get { return _interactionControls; }
            set
            {
                Helper.SetFlag(PropertyFlags.InteractionControls);
                _interactionControls = value;
            }
        }

        #endregion

        #region Control

        public ContentType BoxType { get; set; }

        public string FancyBoxContentID { get; set; }

        public string ContentUrl { get; set; }

        public string GroupName { get; set; }

        public string Caption { get; set; }

        public bool EnableMousewheel { get; set; }

        #endregion

        #endregion

        #region Enums

        public enum PropertyFlags
        {
            Padding,
            Margin,
            Cyclical,
            AllowScrollBars,
            AutoScale,
            AutoDimensions,
            CenterOnScroll,
            ShowOverlay,
            OverlayOpacity,
            OverlayColor,
            ShowTitle,
            TitlePosition,
            TransitionIn,
            TransitionOut,
            SpeedIn,
            SpeedOut,
            ChangeSpeed,
            ChangeFade,
            InteractionControls
        }

        public enum ContentType
        {
            Image,
            Content,
            Iframe,
            AjaxContent,
            YouTube,
            Flash
        }

        public enum ScrollOptions
        {
            Yes,
            No,
            Auto
        }

        public enum TPositions
        {
            Outside,
            Inside,
            Over
        }

        public enum TransitionTypes
        {
            None,
            Fade,
            Elastic
        }

        [Flags]
        public enum BoxControls
        {
            None = 0,
            CloseButton = 1,
            NavArrows = 2,
            EscapeKey = 4,
            CloseOnOverlayClick = 8,
            Default = 15, //CloseButton, NavArrows, EscapeKey, CloseOnOverlayClick
            CloseOnContentClick = 16
        }

        #endregion

        #region Constructors

        public jFancyBox() : base()
        {
            BoxType = ContentType.Image;
            this.Width = new Unit("560px");
            this.Height = new Unit("340px");
            this.GroupName = string.Empty;
            this.Caption = string.Empty;
            this.EnableMousewheel = true;
        }

        #endregion

        #region Lifecycle

        protected override void OnPreRender(EventArgs e)
        {
            //register jquery
            Helper.RegisterJquery();

            //register fancybox
            var fancybox = new jWebResource("fancybox-library", new jWebResourceName("fancybox_1_3_4_min.js"));
            fancybox.Register(Page);

            //register fancybox styles
            var fancyStyles = new jWebResource("fancybox-styles", new jWebResourceName("fancybox_1_3_4_min.css"));
            fancyStyles.Register(Page);

            //enable mousewheel, if desired
            if (EnableMousewheel)
            {
                var mousewheel = new jWebResource("mousewheel-library", new jWebResourceName("mousewheel_3_0_4_min.js"));
                mousewheel.Register(Page);
            }

            //build and register invoker
            BuildInvoker().Register(Page);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            WriteLinkStart(writer);
            base.RenderContents(writer);
            writer.Write("</a>");
        }

        #endregion

        #region Private Methods

        private Dictionary<string,object> BuildOptions()
        {
            var toReturn = new Dictionary<string, object>();

            if (Helper.GetFlag(PropertyFlags.AllowScrollBars))
            {
                toReturn.Add("scrolling", AllowScrollBars.ToString().ToLower());
            }

            if (Helper.GetFlag(PropertyFlags.AutoDimensions))
            {
                toReturn.Add("autoDimensions", AutoDimensions);
            }

            if (Helper.GetFlag(PropertyFlags.AutoScale))
            {
                toReturn.Add("autoScale", AutoScale);
            }

            if (Helper.GetFlag(PropertyFlags.CenterOnScroll))
            {
                toReturn.Add("centerOnScroll", CenterOnScroll);
            }

            if (Helper.GetFlag(PropertyFlags.ChangeFade))
            {
                toReturn.Add("changeFade", ChangeFade);
            }

            if (Helper.GetFlag(PropertyFlags.ChangeSpeed))
            {
                toReturn.Add("changeSpeed", ChangeSpeed);
            }

            if (Helper.GetFlag(PropertyFlags.Cyclical))
            {
                toReturn.Add("cyclic", Cyclical);
            }

            if (Helper.GetFlag(PropertyFlags.InteractionControls))
            {
                if (this.InteractionControls != BoxControls.Default)
                {
                    toReturn.Add("showCloseButton", this.InteractionControls.Has(BoxControls.CloseButton));
                    toReturn.Add("hideOnContentClick", this.InteractionControls.Has(BoxControls.CloseOnContentClick));
                    toReturn.Add("hideOnOverlayClick", this.InteractionControls.Has(BoxControls.CloseOnOverlayClick));
                    toReturn.Add("enableEscapeButton", this.InteractionControls.Has(BoxControls.EscapeKey));
                    toReturn.Add("showNavArrows", this.InteractionControls.Has(BoxControls.NavArrows));
                }
            }

            if (Helper.GetFlag(PropertyFlags.Margin))
            {
                toReturn.Add("margin", Margin);
            }

            if (Helper.GetFlag(PropertyFlags.OverlayColor))
            {
                toReturn.Add("overlayColor", OverlayColor);
            }

            if (Helper.GetFlag(PropertyFlags.OverlayOpacity))
            {
                toReturn.Add("overlayOpacity", OverlayOpacity);
            }

            if (Helper.GetFlag(PropertyFlags.Padding))
            {
                toReturn.Add("padding", Padding);
            }

            if (Helper.GetFlag(PropertyFlags.ShowOverlay))
            {
                toReturn.Add("overlayShow", ShowOverlay);
            }

            if (Helper.GetFlag(PropertyFlags.ShowTitle))
            {
                toReturn.Add("titleShow", ShowTitle);
            }

            if (Helper.GetFlag(PropertyFlags.SpeedIn))
            {
                toReturn.Add("speedIn", SpeedIn);
            }

            if (Helper.GetFlag(PropertyFlags.SpeedOut))
            {
                toReturn.Add("speedOut", SpeedOut);
            }

            if (Helper.GetFlag(PropertyFlags.TitlePosition))
            {
                toReturn.Add("titlePosition", TitlePosition);
            }

            if (Helper.GetFlag(PropertyFlags.TransitionIn))
            {
                toReturn.Add("transitionIn", TransitionIn);
            }

            if (Helper.GetFlag(PropertyFlags.TransitionOut))
            {
                toReturn.Add("transitionOut", TransitionOut);
            }

            if (this.BoxType == ContentType.YouTube || this.BoxType == ContentType.Flash)
            {
                toReturn.Add("type", "swf");                
            }

            if (this.BoxType == ContentType.YouTube)
            {
                toReturn.Add("swf", new { wmode = "transparent", allowfullscreen = "true"});
                toReturn.Add("href", ContentUrl.Replace("watch?v=", "v/"));
                toReturn.Add("width", 680);
                toReturn.Add("height", 495);
            }
            
            return toReturn;
        }

        private jWebResource BuildInvoker()
        {
            //figure out if we're building for an individual or a group
            var selectStr = "";
            var initID = "";
            if (this.GroupName == string.Empty)
            {
                selectStr = '#' + this.ClientID;
                initID = "fancybox-single-init-" + this.ClientID;
            }
            else
            {
                selectStr = "a[rel=\"" + GroupRel() + "\"]";
                initID = "fancybox-group-init-" + this.GroupName;
            }

            var initFormat = "jQuery(function(){{jQuery('{0}').fancybox({1})}});";
            //build out the options string
            var optionStr = JsonConvert.SerializeObject(BuildOptions());

            //compose the init body
            var initBody = string.Format(initFormat, selectStr, optionStr);

            //build the init control
            return new jWebResource(initID, initBody, jWebResourceType.Javascript);
        }

        private void WriteLinkStart(HtmlTextWriter writer)
        {
            var href = "";
            var css = "fancybox-link ";
            switch (BoxType)
            {
                case ContentType.AjaxContent:
                case ContentType.Iframe:
                case ContentType.Image:
                case ContentType.YouTube:
                    if (ContentUrl.StartsWith("~"))
                    {
                        if (ContentUrl.Contains("?"))
                        {
                            var temp = ContentUrl.Split('?');
                            ContentUrl = VirtualPathUtility.ToAbsolute(temp[0]) + '?' + temp[1];
                        }
                        else
                        {
                            ContentUrl = VirtualPathUtility.ToAbsolute(ContentUrl);
                        }
                    }
                    href = ContentUrl;
                    if (BoxType == ContentType.Iframe)
                    {
                        css = "iframe ";
                    }
                    break;
                case ContentType.Content:
                    var ctrl = FindControlRecursive(Page,this.FancyBoxContentID);
                    if (ctrl != null)
                    {
                        href = '#' + ctrl.ClientID;
                    }
                    else
                    {
                        throw new InvalidOperationException(
                            string.Format("Could not find jFancyBoxContent Control \"{0}\" associated with jFancyBox \"{1}\"",
                                          this.FancyBoxContentID, this.ID));
                    }
                    break;
                default:
                    //what is this...i don't even...
                    break;
            }
            var format = new StringBuilder("<a id=\"{0}\" href=\"{1}\" class=\"{2}\" ");
            var formatParams = new List<string>();
            formatParams.Add(this.ClientID);
            formatParams.Add(href);
            formatParams.Add(css + this.CssClass);
            if (this.Caption != string.Empty)
            {
                format.Append("title=\"{" + formatParams.Count + "}\" ");
                formatParams.Add(HttpUtility.HtmlEncode(this.Caption));
            }
            if (this.GroupName != string.Empty)
            {
                format.Append("rel=\"{" + formatParams.Count + "}\" ");
                formatParams.Add(GroupRel());
            }
            format.Append("/>");
            writer.Write(string.Format(format.ToString(), formatParams.ToArray()));
        }

        private string GroupRel()
        {
            return "fancybox-group-" + this.GroupName.Replace(" ", "-");
        }

        private Control FindControlRecursive(Control root, string id)
        {
            if (root.ID == id)
            {
                return root;
            }

            foreach (Control c in root.Controls)
            {
                Control t = FindControlRecursive(c, id);
                if (t != null)
                {
                    return t;
                }
            }

            return null;
        }

        #endregion

    }
}
