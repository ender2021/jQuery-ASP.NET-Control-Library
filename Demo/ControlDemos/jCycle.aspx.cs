using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demos_Cycle : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var images = new List<object>();
            images.Add(new { src = "../Images/Hula Power/130.jpg", alt="hula1"});
            images.Add(new { src = "../Images/Hula Power/131.jpg", alt="hula2"});
            images.Add(new { src = "../Images/Hula Power/132.jpg", alt="hula3"});
            images.Add(new { src = "../Images/Hula Power/133.jpg", alt="hula4"});
            images.Add(new { src = "../Images/Hula Power/134.jpg", alt="hula5"});
            JCycle1.DataSource = images;
            JCycle1.DataImageField = "src";
            JCycle1.DataAltField = "alt";
            JCycle1.DataBind();

            var textItems = new List<string>();
            textItems.Add("You can cycle through anything!");
            textItems.Add("Just make sure you use a container item");
            textItems.Add("Like a &lt;div&gt; or &lt;p&gt;");
            textItems.Add("Think of the containing item as a slide in a slideshow");
            JCycle2.DataSource = textItems;
            JCycle2.DataBind();
        }
    }
}
