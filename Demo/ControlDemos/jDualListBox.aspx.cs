using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class ControlDemos_jDualListBox : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            var selected =
                (from ListItem item in JDualListBox1.Items
                 where item.Selected
                 select item).ToList();
            rptrYouPicked.Visible = true;
            rptrYouPicked.DataSource = selected;
            rptrYouPicked.DataBind();
        }
    }

    protected string PrintItem(object item)
    {
        ListItem x = (ListItem) item;
        return x.Text;
    }
}
