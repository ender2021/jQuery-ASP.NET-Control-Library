using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using jQuery.NET.Utility;
using Extensions;
using Newtonsoft.Json;

namespace jQuery.NET.Controls
{
    [ToolboxData("<{0}:jDualListBox runat=\"server\" ></{0}:jDualListBox>")]
    [ToolboxBitmap(typeof(ResourceFinder), "jQuery.NET.img.jDualListBox.bmp")]
    public class jDualListBox : Base.jListBoxControl
    {
        #region Properties

        private ButtonFlags _buttons = ButtonFlags.All;
        private bool _filter = true;
        private bool _sort = true;
        private bool _counter = true;

        #endregion

        #region Accessors / Mutators

        public ButtonFlags Buttons
        {
            get { return _buttons; }
            set
            {
                Helper.SetFlag(PropertyFlags.Buttons);
                _buttons = value;
            }
        }

        public bool ShowFilters
        {
            get { return _filter; }
            set
            {
                Helper.SetFlag(PropertyFlags.ShowFilters);
                _filter = value;
            }
        }

        public bool ShowCounters
        {
            get { return _counter; }
            set
            {
                Helper.SetFlag(PropertyFlags.ShowCounters);
                _counter = value;
            }
        }

        public bool MaintainSort
        {
            get { return _sort; }
            set
            {
                Helper.SetFlag(PropertyFlags.MaintainSort);
                _sort = value;
            }
        }

        #endregion

        #region Enums

        [FlagsAttribute]
        public enum ButtonFlags
        {
            None = 0x00,
            Swap = 0x01,
            MoveAll = 0x02,
            MoveSelected = 0x04,
            All = 0x07
        }

        private enum PropertyFlags
        {
            Buttons,
            ShowFilters,
            ShowCounters,
            MaintainSort
        }

        #endregion

        #region Lifecycle

        protected override void OnPreRender(EventArgs e)
        {
            //register jQuery
            Helper.RegisterJquery();

            //register dlb plugin
            var dlb = new jWebResource("dlb-library", new jWebResourceName("dualListBox_2_0_min.js"));
            dlb.Register(Page);

            //register the css
            var styles = new jWebResource("dlb-styles", new jWebResourceName("dualListBox_min.css"));
            styles.Register(Page);

            //this format string will build a onDomReady jquery handler to initialize galleria
            var initFormat = "jQuery(function(){{jQuery('#{0}').dualListBox({1});}});";

            //build out the options string
            var optionStr = JsonConvert.SerializeObject(BuildOptions());

            //compose the init body
            var initBody = string.Format(initFormat, this.ClientID, optionStr);

            //build the init control
            var initControl = new jWebResource("dlb-init-" + this.ClientID, initBody, jWebResourceType.Javascript);

            //register the control
            initControl.Register(Page);

            //finally, set selection mode to multiple
            SelectionMode = ListSelectionMode.Multiple;
        }
        
        #endregion

        #region PrivateMethods
            
        private Dictionary<string,object> BuildOptions()
        {
            var toReturn = new Dictionary<string,object>();
            if (Helper.GetFlag(PropertyFlags.Buttons))
            {
                var buttonOpts = new Dictionary<string, bool>();
                buttonOpts.Add("swap", Buttons.Has(ButtonFlags.Swap));
                buttonOpts.Add("moveAll", Buttons.Has(ButtonFlags.MoveAll));
                buttonOpts.Add("moveSelected", Buttons.Has(ButtonFlags.MoveSelected));
                toReturn.Add("buttons", buttonOpts);
            }
            if (!this.ShowFilters)
            {
                toReturn.Add("filter", false);
            }
            if (!this.ShowCounters)
            {
                toReturn.Add("counter", false);
            }
            if (!this.MaintainSort)
            {
                toReturn.Add("sort", false);
            }
            return toReturn;
        }

        #endregion
    }
}
