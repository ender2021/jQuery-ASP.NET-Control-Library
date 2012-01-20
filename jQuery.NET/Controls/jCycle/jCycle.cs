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
using Extensions;

namespace jQuery.NET.Controls
{
    [ToolboxData("<{0}:jCycle runat=\"server\" ></{0}:jCycle>")]
    [ToolboxBitmap(typeof(ResourceFinder), "jQuery.NET.img.jCycle.bmp")]
    public class jCycle : Base.jGenericControl
    {
        #region Properties

        #region Plug-In

        private Effects _transitionEffect = Effects.none;
        private bool _autostop = false;
        private int _autostopCount = 0;
        private bool _playBackwards = false;
        private bool _fitToSlides = true;
        private bool _continuousPlay = false;
        private int _startDelay = 0;
        private bool _fitToContainer = false;
        private bool _manualTrump = true;
        private bool _pauseOnHover = false;
        private bool _randomize = false;
        private bool _reverseAnimation = false;
        private int _transitionSpeed = 1000;
        private int _startingSlide = 0;
        private bool _synchronizeTransitions = false;
        private int _transitionInterval = 4000;

        #endregion

        #region Control

        #endregion

        #endregion

        #region Accessors / Mutators

        #region Plug-In

        /// <summary>
        /// Get or set the set of transition effects to be used for this jCycle.
        /// </summary>
        public Effects TransitionEffect
        {
            get { return _transitionEffect; }
            set
            {
                Helper.SetFlag(PropertyFlags.TransitionEffect);
                _transitionEffect = value;
            }
        }

        /// <summary>
        /// Set to true to make the jCycle stop rotation after a certain number of transitions.  False by default.
        /// </summary>
        public bool Autostop
        {
            get { return _autostop; }
            set
            {
                Helper.SetFlag(PropertyFlags.Autostop);
                _autostop = value;
            }
        }

        /// <summary>
        /// Used in conjunction with Autostop, determines the number of transitions after which the jCycle will stop rotation.
        /// </summary>
        public int AutostopCount
        {
            get { return _autostopCount; }
            set
            {
                Helper.SetFlag(PropertyFlags.AutostopCount);
                _autostopCount = value;
            }
        }

        /// <summary>
        /// Set to true to reverse the slide order.  False by default.
        /// </summary>
        public bool PlayBackwards
        {
            get { return _playBackwards; }
            set
            {
                Helper.SetFlag(PropertyFlags.PlayBackwards);
                _playBackwards = value;
            }
        }

        /// <summary>
        /// Set to false to allow the container to retain its native height.  Oversize slides will be cropped.  True by default.
        /// </summary>
        public bool FitToSlides
        {
            get { return _fitToSlides; }
            set
            {
                Helper.SetFlag(PropertyFlags.FitToSlides);
                _fitToSlides = value;
            }
        }

        /// <summary>
        /// Set to true to disable delays between slide transitions.  False by default.
        /// </summary>
        public bool ContinuousPlay
        {
            get { return _continuousPlay; }
            set
            {
                Helper.SetFlag(PropertyFlags.ContinuousPlay);
                _continuousPlay = value;
            }
        }

        /// <summary>
        /// The delay (in milliseconds) before the cycling should begin when the page loads.
        /// </summary>
        public int StartDelay
        {
            get { return _startDelay; }
            set
            {
                Helper.SetFlag(PropertyFlags.StartDelay);
                _startDelay = value;
            }
        }

        /// <summary>
        /// Set to true to force slides to fit the container.  False by default.
        /// </summary>
        public bool FitToContainer
        {
            get { return _fitToContainer; }
            set
            {
                Helper.SetFlag(PropertyFlags.FitToContainer);
                _fitToContainer = value;
            }
        }

        /// <summary>
        /// Set to false to prevent manually triggered transitions (such as via click, pager, or next/prev) from overriding autotransitions.  True by default.
        /// </summary>
        public bool ManualTrump
        {
            get { return _manualTrump; }
            set
            {
                Helper.SetFlag(PropertyFlags.ManualTrump);
                _manualTrump = value;
            }
        }

        /// <summary>
        /// Set to true to cause the cycle to pause when the user hovers over it.  False by default.
        /// </summary>
        public bool PauseOnHover
        {
            get { return _pauseOnHover; }
            set
            {
                Helper.SetFlag(PropertyFlags.PauseOnHover);
                _pauseOnHover = value;
            }
        }

        /// <summary>
        /// Set to true to randomize the slide sequence.  False by default.
        /// </summary>
        public bool Randomize
        {
            get { return _randomize; }
            set
            {
                Helper.SetFlag(PropertyFlags.Randomize);
                _randomize = value;
            }
        }

        /// <summary>
        /// For supported animations, set to true to reverse the direction of the animation.  False by default.
        /// </summary>
        public bool ReverseAnimation
        {
            get { return _reverseAnimation; }
            set
            {
                Helper.SetFlag(PropertyFlags.ReverseAnimation);
                _reverseAnimation = value;
            }
        }

        /// <summary>
        /// Get/set the speed of slide transitions, in milliseconds.  Default is 1000.
        /// </summary>
        public int TransitionSpeed
        {
            get { return _transitionSpeed; }
            set
            {
                Helper.SetFlag(PropertyFlags.TransitionSpeed);
                _transitionSpeed = value;
            }
        }

        /// <summary>
        /// Set the slide index that the cycle should begin at.  Default is 0.
        /// </summary>
        public int StartingSlide
        {
            get { return _startingSlide; }
            set
            {
                Helper.SetFlag(PropertyFlags.StartingSlide);
                _startingSlide = value;
            }
        }

        /// <summary>
        /// Set to false to cause in/out portions of transitions to occur in serial, rather than synchronously.  True by default.
        /// </summary>
        public bool SynchronousTransitions
        {
            get { return _synchronizeTransitions; }
            set
            {
                Helper.SetFlag(PropertyFlags.SynchronizeTransitions);
                _synchronizeTransitions = value;
            }
        }

        /// <summary>
        /// Get/set the number of milliseconds between each transition.  Default is 4000.
        /// </summary>
        public int TransitionInterval
        {
            get { return _transitionInterval; }
            set
            {
                Helper.SetFlag(PropertyFlags.TransitionInterval);
                _transitionInterval = value;
            }
        }

        #endregion

        #region Control

        [TemplateContainer(typeof(RepeaterItem))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Browsable(false)]
        public ITemplate ItemTemplate
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

        [DefaultValue(null), Bindable(true)]
        public object DataSource
        {
            get
            {
                return InnerRepeater.DataSource;
            }
            set
            {
                InnerRepeater.DataSource = value;
            }
        }

        private Repeater InnerRepeater { get; set; }

        public bool ClickToAdvance { get; set; }

        public CycleControls DisplayControls { get; set; }

        public Positions PagerPosition { get; set; }

        public Positions PrevNextPosition { get; set; }

        public string NextText { get; set; }

        public string PrevText { get; set; }

        public bool DisableControlStyles { get; set; }

        /// <summary>
        /// Set the virtual folder path of the directory source for the gallery.
        /// </summary>
        public string FolderPath { get; set; }

        /// <summary>
        /// Set the extension filter list used to select images from the source directory.
        /// Default value is ".jpg,.jpeg,.gif,.png,.bmp"
        /// </summary>
        public string FolderFilter { get; set; }

        /// <summary>
        /// Indicate whether or not to search the source directory recursively.
        /// Default value is true.
        /// </summary>
        public bool RecursiveSearch { get; set; }

        /// <summary>
        /// The data object field name which will contain the path to the image. This is REQUIRED if you are using an object data source.  Default value is "Image".
        /// </summary>
        public string DataImageField { get; set; }

        /// <summary>
        /// The data object field name which will contain the alt tag of the image.
        /// </summary>
        public string DataAltField { get; set; }

        #endregion

        #endregion

        #region Enums

        private enum PropertyFlags
        {
            TransitionEffect,
            Autostop,
            AutostopCount,
            PlayBackwards,
            FitToSlides,
            ContinuousPlay,
            StartDelay,
            FitToContainer,
            ManualTrump,
            PauseOnHover,
            Randomize,
            ReverseAnimation,
            TransitionSpeed,
            StartingSlide,
            SynchronizeTransitions,
            TransitionInterval
        }

        public enum Positions
        {
            Top,
            Bottom
        }

        [Flags]
        public enum CycleControls
        {
            None = 0,
            Pager = 1,
            PrevNext = 2,
            All = 3
        }

        //each effect is a power of two - this is important for using them as bit flags
        [Flags]
        public enum Effects
        {
            blindX = 1,
            blindY = 2,
            blindZ = 4,
            cover = 8,
            curtainX = 16,
            curtainY = 32,
            fade = 64,
            fadeZoom = 128,
            growX = 256,
            growY = 512,
            scrollUp = 1024,
            scrollDown = 2048,
            scrollLeft = 4096,
            scrollRight = 8192,
            scrollHorz = 16384,
            scrollVert = 32768,
            shuffle = 65536,
            slideX = 131072,
            slideY = 262144,
            toss = 524288,
            turnUp = 1048576,
            turnDown = 2097152,
            turnLeft = 4194304,
            turnRight = 8388608,
            uncover = 16777216,
            wipe = 33554432,
            zoom = 67108864,
            none = 134217728
        }

        #endregion

        #region Constructors

        public jCycle() : base()
        {
            InnerRepeater = new Repeater();
            InnerRepeater.DataSource = null;
            ItemTemplate = null;
            NextText = "Next";
            PrevText = "Prev";
            DisplayControls = CycleControls.None;
            PrevNextPosition = Positions.Bottom;
            PagerPosition = Positions.Bottom;
            FolderPath = string.Empty;
            FolderFilter = ".jpg,.jpeg,.gif,.png,.bmp";
            RecursiveSearch = true;
            DataImageField = "Image";
            DataAltField = string.Empty;
        }

        #endregion

        #region Lifecycle

        protected override void OnPreRender(EventArgs e)
        {
            //register jquery
            Helper.RegisterJquery();

            //register cycle library
            var cycle = new jWebResource("cycle-library", new jWebResourceName("cycle_all_min.js"));
            cycle.Register(Page);

            //do some stuff for cycle controls
            var controlAdjust = "";
            if (!DisableControlStyles && DisplayControls != CycleControls.None)
            {
                //register default styles
                var cycleStyles = new jWebResource("cycle-styles", new jWebResourceName("cycle_min.css"));
                cycleStyles.Register(Page);

                //some script to set the cycle controls width
                var adjustTemplate = new StringBuilder("var w=jQuery('#{0}').outerWidth();");
                var templateArgs = new List<string>();
                templateArgs.Add(this.ClientID);
                if (DisplayControls.Has(CycleControls.All) && PagerPosition == PrevNextPosition)
                {
                    adjustTemplate.Append("var nav=jQuery('#{1}'),ctrlW=w;nav.width(w);");
                    templateArgs.Add(NavControlsID());
                    adjustTemplate.Append("ctrlW-=nav.find('.prev-control').outerWidth();");
                    adjustTemplate.Append("ctrlW-=nav.find('.next-control').css('float', 'left').outerWidth();");
                    adjustTemplate.Append("jQuery('#{2}').width(ctrlW).css({{'display':'inline-block','float':'left'}});");
                    templateArgs.Add(PagerID());
                }
                else
                {
                    adjustTemplate.Append("jQuery('#{1},#{2}').width(w);");
                    templateArgs.Add(NavControlsID());
                    templateArgs.Add(PagerID());
                }
                controlAdjust = string.Format(adjustTemplate.ToString(), templateArgs.ToArray());
            }

            //this format string will build a onDomReady jquery handler to initialize galleria
            var initFormat = "jQuery(function(){{jQuery('#{0}').cycle({1});{2}}});";

            //build out the options string
            var optionStr = JsonConvert.SerializeObject(BuildOptions());

            //compose the init body
            var initBody = string.Format(initFormat, this.ClientID, optionStr, controlAdjust);

            //build the init control
            var initControl = new jWebResource("cycle-init-" + this.ClientID, initBody, jWebResourceType.Javascript);

            //register the control
            initControl.Register(Page);

            //transfer rendering responsibility to the repeater
            InnerRepeater.ID = this.ID;

            if (DataSource == null)
            {
                DataSource =
                    (from string fPath in Helper.BuildFileList(FolderPath, FolderFilter, RecursiveSearch)
                     select fPath).ToList();
                DataBind();
            }

            if (ItemTemplate == null)
            {
                InnerRepeater.ItemCreated += new RepeaterItemEventHandler(InnerRepeater_ItemCreated);
                InnerRepeater.DataBind();
            }

            
        }

        void InnerRepeater_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            var img = new System.Web.UI.WebControls.Image();
            img.ID =  "cycle-img";
            var di = e.Item.DataItem;
            if (di.GetType() == typeof(string))
            {
                img.ImageUrl = (string) di;
            }
            else
            {
                var imgProp = di.GetType().GetProperty(this.DataImageField);
                var altProp = di.GetType().GetProperty(this.DataAltField);
                if (imgProp != null)
                {
                    img.ImageUrl = (string)imgProp.GetValue(di, null);
                }
                if (imgProp != null)
                {
                    img.AlternateText = (string)altProp.GetValue(di, null);
                }
            }
            e.Item.Controls.Add(img);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            WriteControlsInPosition(writer, Positions.Top);
            writer.WriteLine(string.Format("<div id=\"{0}\" style=\"height:{1};width:{2};\">",
                              this.ClientID, this.Height.ToString(), this.Width.ToString()));
            this.RenderContents(writer);
            writer.WriteLine("</div>");
            WriteControlsInPosition(writer, Positions.Bottom);
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            InnerRepeater.RenderControl(writer);
        }

        #endregion

        #region Public Methods

        public new void DataBind()
        {
            InnerRepeater.DataBind();
        }

        #endregion

        #region Private Methods

        private Dictionary<string,object> BuildOptions()
        {
            var toReturn = new Dictionary<string, object>();

            if (Helper.GetFlag(PropertyFlags.TransitionEffect))
            {
                var eList = new StringBuilder();
                foreach (Effects e in Enum.GetValues(typeof(Effects)))
                {
                    if (TransitionEffect.Has(e))
                    {
                        eList.Append(e.ToString());
                        eList.Append(",");
                    }
                }
                toReturn.Add("fx", eList.ToString().TrimEnd(','));
            }

            if (Helper.GetFlag(PropertyFlags.Autostop))
            {
                toReturn.Add("autostop", Autostop);
            }

            if (Helper.GetFlag(PropertyFlags.PlayBackwards))
            {
                toReturn.Add("backwards", PlayBackwards);
            }

            if (Helper.GetFlag(PropertyFlags.FitToSlides))
            {
                toReturn.Add("containerResize", FitToSlides);
            }

            if (Helper.GetFlag(PropertyFlags.FitToContainer))
            {
                toReturn.Add("fit", FitToContainer);
            }

            if (Helper.GetFlag(PropertyFlags.ContinuousPlay))
            {
                toReturn.Add("continuous", ContinuousPlay);
            }

            if (Helper.GetFlag(PropertyFlags.ManualTrump))
            {
                toReturn.Add("manualTrump", ManualTrump);
            }

            if (Helper.GetFlag(PropertyFlags.PauseOnHover))
            {
                toReturn.Add("pause", PauseOnHover);
            }

            if (Helper.GetFlag(PropertyFlags.Randomize))
            {
                toReturn.Add("random", Randomize);
            }

            if (Helper.GetFlag(PropertyFlags.ReverseAnimation))
            {
                toReturn.Add("rev", ReverseAnimation);
            }

            if (Helper.GetFlag(PropertyFlags.SynchronizeTransitions))
            {
                toReturn.Add("sync", SynchronizeTransitions);
            }

            if (Helper.GetFlag(PropertyFlags.AutostopCount))
            {
                toReturn.Add("autostopCount", AutostopCount);
            }

            if (Helper.GetFlag(PropertyFlags.StartDelay))
            {
                toReturn.Add("delay", StartDelay);
            }

            if (Helper.GetFlag(PropertyFlags.StartingSlide))
            {
                toReturn.Add("startingSlide", StartingSlide);
            }

            if (Helper.GetFlag(PropertyFlags.TransitionInterval))
            {
                toReturn.Add("timeout", TransitionInterval);
            }

            if (Helper.GetFlag(PropertyFlags.TransitionSpeed))
            {
                toReturn.Add("speed", TransitionSpeed);
            }

            if (ClickToAdvance && DisplayControls.Missing(CycleControls.PrevNext))
            {
                toReturn.Add("next", '#' + this.ClientID);
            }
            else if (ClickToAdvance && DisplayControls.Has(CycleControls.PrevNext))
            {
                toReturn.Add("next", '#' + this.ClientID + ",#" + NavControlsID() + " .next-control");
                toReturn.Add("prev", '#' + NavControlsID() + " .prev-control");
            } else
            {
                toReturn.Add("next", '#' + NavControlsID() + " .next-control");
                toReturn.Add("prev", '#' + NavControlsID() + " .prev-control");
            }

            if (DisplayControls.Has(CycleControls.Pager))
            {
                toReturn.Add("pager", '#' + PagerID());
            }

            return toReturn;
        }

        private void WritePager(HtmlTextWriter writer)
        {
            var pagerFormat = "<div id=\"{0}\" class=\"cycle-pager\"></div>";
            writer.WriteLine(string.Format(pagerFormat, PagerID()));

        }

        private void WritePrevNext(HtmlTextWriter writer, bool includePager)
        {
            var linkFormat = "<a class=\"{0}\" href=\"#\">{1}</a>";
            var navFormat = new StringBuilder();
            navFormat.Append("<div id=\"{0}\" class=\"cycle-nav-controls\">");
            navFormat.Append(string.Format(linkFormat, "prev-control", PrevText));
            writer.WriteLine(string.Format(navFormat.ToString(), NavControlsID()));
            navFormat = new StringBuilder();
            if (includePager)
            {
                WritePager(writer);
            }
            navFormat.Append(string.Format(linkFormat, "next-control", NextText));
            navFormat.Append("</div>");
            writer.WriteLine(navFormat.ToString());
        }

        private void WriteControlsInPosition(HtmlTextWriter writer, Positions p)
        {
            if (DisplayControls.Has(CycleControls.PrevNext) && PrevNextPosition == p)
            {
                var includePager = DisplayControls.Has(CycleControls.Pager) && PagerPosition == p;
                WritePrevNext(writer, includePager);
            }
            else if (DisplayControls.Has(CycleControls.Pager) && PagerPosition == p)
            {
                WritePager(writer);
            }
        }

        private string NavControlsID()
        {
            return this.ClientID + "_navControls";
        }

        private string PagerID()
        {
            return this.ClientID + "_cyclePager";
        }

        #endregion
    }
}
