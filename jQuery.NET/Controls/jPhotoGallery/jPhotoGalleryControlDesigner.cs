using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Web.UI.Design;

namespace jQuery.NET.Controls
{
    class jPhotoGalleryControlDesigner : ControlDesigner
    {
        private DesignerActionListCollection lists;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (lists == null)
                {
                    lists = new DesignerActionListCollection();
                    lists.Add(new jPhotoGalleryActionList(this.Component));
                }
                return lists;
            }
        }
    }
}
