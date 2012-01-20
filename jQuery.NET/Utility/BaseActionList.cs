using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
//using Microsoft.Web.Design;
//using Microsoft.Web.Design.Interop;

namespace jQuery.NET.Utility
{
    internal abstract class BaseActionList : DesignerActionList
    {

        #region Properties

        //these values store instance objects for the derived classes
        private IComponent _instanceComponent;
        private DesignerActionUIService _designerActionUISvc;

        #endregion

        #region Accessors / Mutators

        //these properties will be used in derived classes, to access the instance objects of the parent class
        protected IComponent InstanceComponent
        {
            get { return _instanceComponent; }
        }

        protected DesignerActionUIService DesignerActionUISvc
        {
            get { return _designerActionUISvc; }
        }

        #endregion

        #region Constructors

        protected BaseActionList(IComponent component) : base(component)
        {
            //store the component for this instance
            _instanceComponent = component;
            //store a designer service for this instance
            _designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
            //attach the UI refresh handler
            //this.DesignerActionUISvc.DesignerActionUIStateChange += new DesignerActionUIStateChangeEventHandler(OnDesignerActionUIStateChange);
        }

        #endregion

        #region Private Methods

        //private void OnDesignerActionUIStateChange(object sender, DesignerActionUIStateChangeEventArgs e)
        //{
        //    if (e.ChangeType == DesignerActionUIStateChangeType.Refresh)
        //    {
        //        var ed = (IWebElementDesigner)ElementDesigner.GetElementDesigner((Control)this.Component);
        //        if (ed != null)
        //        {
        //            ed.UpdateView();
        //        }
        //    }
        //}

        #endregion

        #region Protected Methods

        protected PropertyDescriptor GetPropertyByName(string propName)
        {
            var prop = TypeDescriptor.GetProperties(_instanceComponent)[propName];
            if (prop == null)
            {
                throw new ArgumentException("Invalid property name.", propName);
            }
            return prop;
        }

        #endregion
    }
}
