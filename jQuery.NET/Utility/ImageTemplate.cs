using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jQuery.NET.Utility
{
    internal class ImageTemplate : ITemplate
    {
        public void InstantiateIn(Control container)
        {
            if (((RepeaterItem)container).DataItem != null)
            {
                var img = new Image();
                img.ID = container.ID + "_img";
                img.ImageUrl = ((ImageTemplateItem)((RepeaterItem)container).DataItem).ImagePath;
                img.AlternateText = ((ImageTemplateItem)((RepeaterItem)container).DataItem).ImageAlt;
                container.Controls.Add(img);
            }
        }
    }

    internal class ImageTemplateItem
    {
        public string ImagePath { get; set; }
        public string ImageAlt { get; set; }

        public ImageTemplateItem(string path, string alt)
        {
            ImageAlt = alt;
            ImagePath = path;
        }
    }
}
