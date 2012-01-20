using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace jQuery.NET.Utility
{
    public enum jWebResourceType
    {
        Javascript,
        Css
    }

    struct jWebResourceName
    {
        private readonly string _name;
        public const string EmptyName = "jQuery.NET.";

        public jWebResourceName(string name)
        {
            if (name.EndsWith(".js"))
            {
                _name = "js." + name;
            } else if (name.EndsWith(".css"))
            {
                _name = "css." + name;
            }
            else
            {
                _name = "img." + name;
            }
        }

        public new string ToString()
        {
            return EmptyName + _name;
        }

        public static implicit operator string(jWebResourceName n)
        {
            return n.ToString();
        }
    }

    class jWebResource
    {
        #region Properties

        private const string ID_PREFIX = "jq-net-";
        public string Id { get; set; }
        public jWebResourceName ResourceName { get; set; }
        public Uri ResourceUri { get; set; }
        public string ResourceContent { get; set; }
        public jWebResourceType ResourceType { get; set; }
        private static readonly Page _dummyPage = new Page();
        
        #endregion

        #region Constructors

        public jWebResource(string id, jWebResourceName resourceName)
        {
            this.Id = ID_PREFIX + id;
            this.ResourceName = resourceName;
            if (ResourceName.ToString().EndsWith(".js"))
            {
                ResourceType = jWebResourceType.Javascript;
            }
            else if (ResourceName.ToString().EndsWith(".css"))
            {
                ResourceType = jWebResourceType.Css;
            }
        }

        public jWebResource(string id, string resourceContent, jWebResourceType rtype)
        {
            this.Id = ID_PREFIX + id;
            this.ResourceContent = resourceContent;
            this.ResourceType = rtype;
        }

        public jWebResource(string id, Uri resourceUri, jWebResourceType rtype)
        {
            this.Id = ID_PREFIX + id;
            this.ResourceUri = resourceUri;
            this.ResourceType = rtype;
        }

        #endregion

        #region Public Methods
        public bool Register(Page ctrlPage)
        {
            var controlCheck =
                    from Control c in ctrlPage.Header.Controls
                    where c.ID == this.Id
                    select c;
            if (controlCheck.SingleOrDefault() == null)
            {
                ctrlPage.Header.Controls.Add(BuildControl(ctrlPage));
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetResourceUri(jWebResourceName name)
        {
            return _dummyPage.ClientScript.GetWebResourceUrl(typeof(jControlHelper), name);
        }
        #endregion

        #region Private Methods
            private HtmlControl BuildControl(Page ctrlPage)
            {
                var ctrlType = "";
                var srcAttr = "";
                HtmlControl jwrControl = null;
                switch (this.ResourceType)
                {
                    case jWebResourceType.Javascript:
                        ctrlType = "text/javascript";
                        srcAttr = "src";
                        jwrControl = new HtmlGenericControl("script");
                        ((HtmlGenericControl)jwrControl).InnerHtml = ResourceContent;
                        break;
                    case jWebResourceType.Css:
                        jwrControl = new HtmlLink();
                        jwrControl.Attributes.Add("rel", "stylesheet");
                        ctrlType = "text/css";
                        srcAttr = "href";
                        break;
                    default:
                        jwrControl = new HtmlGenericControl("unknown");
                        break;
                }
                jwrControl.ID = this.Id;
                jwrControl.Attributes.Add("type", ctrlType);
                if (this.ResourceUri != null)
                {
                    jwrControl.Attributes.Add(srcAttr, this.ResourceUri.ToString());
                } else if (this.ResourceName != jWebResourceName.EmptyName)
                {
                    jwrControl.Attributes.Add(srcAttr, ctrlPage.ClientScript.GetWebResourceUrl(typeof(jControlHelper), ResourceName));                    
                } else if (ResourceType == jWebResourceType.Css)
                {
                    jwrControl = new HtmlGenericControl("style");
                    jwrControl.Attributes.Add("type", "text/css");
                    ((HtmlGenericControl)jwrControl).InnerHtml = ResourceContent;
                }
                return jwrControl;
            }
        #endregion
    }
}
