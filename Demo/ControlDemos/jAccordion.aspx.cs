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
using System.Collections.Generic;

public partial class ControlDemos_jAccordion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var panels = new List<AccordionData>();
            for (var i = 0; i < 10; i++)
            {
                panels.Add(new AccordionData("Panel " + i, "blah blah blah, this is the body of panel " + i));
            }
            JAccordion1.DataSource = panels;
            JAccordion1.DataBind();
        }
    }

    protected class AccordionData
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public AccordionData(string title, string body)
        {
            Title = title;
            Body = body;
        }
    }
}
