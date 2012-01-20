using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using jQuery.NET.Utility;

namespace jQuery.NET.Controls
{
    class jPhotoGalleryActionList : BaseActionList
    {

        #region Properties

        private bool _isDDS = true;
        private jPhotoGallery _gallery;

        #endregion

        #region Accessors / Mutators

        public string DataImageField
        {
            get { return _gallery.DataImageField; }
            set
            {
                GetPropertyByName("DataImageField").SetValue(_gallery, value);
                this.DesignerActionUISvc.Refresh(this.Component);
            }
        }

        public string DataDescriptionField
        {
            get { return _gallery.DataDescriptionField; }
            set
            {
                GetPropertyByName("DataDescriptionField").SetValue(_gallery, value);
                this.DesignerActionUISvc.Refresh(this.Component);
            }
        }

        public string DataTitleField
        {
            get { return _gallery.DataTitleField; }
            set
            {
                GetPropertyByName("DataTitleField").SetValue(_gallery, value);
                this.DesignerActionUISvc.Refresh(this.Component);
            }
        }

        public string DataSourceLinkField
        {
            get { return _gallery.DataSourceLinkField; }
            set
            {
                GetPropertyByName("DataSourceLinkField").SetValue(_gallery, value);
                this.DesignerActionUISvc.Refresh(this.Component);
            }
        }

        public bool IncludeJQuery
        {
            get { return _gallery.IncludeJquery; }
            set
            {
                GetPropertyByName("IncludeJquery").SetValue(_gallery, value);
                this.DesignerActionUISvc.Refresh(this.Component);
            }
        }

        public Unit Height
        {
            get { return _gallery.Height; }
            set
            {
                GetPropertyByName("Height").SetValue(_gallery, value);
                this.DesignerActionUISvc.Refresh(this.Component);
            }
        }

        public Unit Width
        {
            get { return _gallery.Width; }
            set
            {
                GetPropertyByName("Width").SetValue(_gallery, value);
                this.DesignerActionUISvc.Refresh(this.Component);
            }
        }

        public bool IsDDS
        {
            get { return _isDDS; }
            set
            {
                _isDDS = value;
                this.DesignerActionUISvc.Refresh(this.Component);
            }
        }

        public string FolderPath
        {
            get { return _gallery.FolderPath; }
            set
            {
                GetPropertyByName("FolderPath").SetValue(_gallery, value);
                this.DesignerActionUISvc.Refresh(this.Component);
            }
        }

        public string FolderFilter
        {
            get { return _gallery.FolderFilter; }
            set
            {
                GetPropertyByName("FolderFilter").SetValue(_gallery, value);
                this.DesignerActionUISvc.Refresh(this.Component);
            }
        }

        public bool RecursiveSearch
        {
            get { return _gallery.RecursiveSearch; }
            set
            {
                GetPropertyByName("RecursiveSearch").SetValue(_gallery, value);
                this.DesignerActionUISvc.Refresh(this.Component);
            }
        }


        #endregion

        #region Constructors

        public jPhotoGalleryActionList(IComponent component): base(component)
        {
            _gallery = (jPhotoGallery)InstanceComponent;
        }

        #endregion

        #region Public Methods

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Configuration"));
            items.Add(new DesignerActionHeaderItem("Appearance"));
            items.Add(new DesignerActionHeaderItem("Data Source"));

            //configuration section
            items.Add(new DesignerActionPropertyItem("IncludeJQuery", "Include jQuery", "Configuration",
                                                     "Includes the jQuery library."));

            //appearance section
            items.Add(new DesignerActionPropertyItem("Height", "Height", "Appearance", "The height of the gallery."));
            items.Add(new DesignerActionPropertyItem("Width", "Width", "Appearance", "The width of the gallery."));

            items.Add(new DesignerActionPropertyItem("IsDDS", "Use Directory Data Source", "Data Source",
                                                     "The width of the gallery."));

            if ((IsDDS))
            {
                //data source section
                items.Add(new DesignerActionTextItem("Directory Data Source", "Data Source"));

                items.Add(new DesignerActionPropertyItem("FolderPath", "Directory Path", "Data Source",
                                                         "Specifies the virtual directory path to use as the gallery data source."));

                items.Add(new DesignerActionPropertyItem("FolderFilter", "File Extension Filter", "Data Source",
                                                         "A comma seperated list of image file extensions to search for."));

                items.Add(new DesignerActionPropertyItem("RecursiveSearch", "Include Images Recursively", "Data Source",
                                                         "Check to include images from other directories within the source directory."));
            }
            else
            {
                //data source section
                items.Add(new DesignerActionTextItem("IEnumerable Data Source", "Data Source"));

                items.Add(new DesignerActionPropertyItem("DataImageField", "Image Path Field Name", "Data Source",
                                                         "The name of the object property that will contain the image path."));

                items.Add(new DesignerActionPropertyItem("DataTitleField", "Image Title Field Name", "Data Source",
                                                         "Specifies the object property name that will contain the image title."));

                items.Add(new DesignerActionPropertyItem("DataDescriptionField", "Image Description Field Name",
                                                         "Data Source",
                                                         "Specifies the object property name that will contain the image description."));

                items.Add(new DesignerActionPropertyItem("DataSourceLinkField", "Image Source Link Field Name",
                                                         "Data Source",
                                                         "Specifies the object property name that will contain the image source link."));
            }

            return items;
        }

        #endregion

    }
}
