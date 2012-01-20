using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace jQuery.NET.Interfaces
{
    public interface IjControl
    {
        bool IncludeJquery { get; set; }
        bool IncludeJqueryUI { get; set; }
        string JqueryVersion { get; set; }
        Page Page { get; set; }
    }
}
