using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jQuery.NET.Interfaces;
using jQuery.NET.Utility.jQueryUI;

namespace jQuery.NET.Utility
{
    public class jControlHelper
    {

        #region Properties

        private Dictionary<int, bool> _flags = new Dictionary<int, bool>();

        #endregion

        #region Accessors / Mutators

        private IjControl jControl { get; set; }
        
        #endregion

        #region Constructors

        public jControlHelper(IjControl toHelp)
        {
            jControl = toHelp;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Registers a jQuery script tag in the page header, if it is desired and not already on the page
        /// </summary>
        public void RegisterJquery()
        {
            if (jControl.IncludeJquery)
            {
                var jqUri = new Uri(String.Format(
                                        "https://ajax.googleapis.com/ajax/libs/jquery/{0}/jquery.min.js",
                                        jControl.JqueryVersion));
                var jquery = new jWebResource("jquery-library", jqUri, jWebResourceType.Javascript);
                jquery.Register(jControl.Page);
            }
        }

        /// <summary>
        /// Registers a jQueryUI script tag in the page header, if it is desired and not already on the page
        /// </summary>
        public void RegisterJqueryUI()
        {
            if (jControl.IncludeJqueryUI)
            {
                var jquiUri = new Uri("https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.11/jquery-ui.min.js");
                var jqueryUI = new jWebResource("jquery-ui-library", jquiUri, jWebResourceType.Javascript);
                jqueryUI.Register(jControl.Page);
            }
        }

        /// <summary>
        /// Registers a jQueryUI theme, if it is not already on the page
        /// </summary>
        public void RegisterUITheme(UIThemes theme)
        {
            if (theme != UIThemes.None)
            {
                var themeUri = new Uri(String.Format(
                        "http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.0/themes/{0}/jquery-ui.css",
                        TranslateThemeName(theme)));
                var themeElem = new jWebResource("jquery-ui-theme", themeUri, jWebResourceType.Css);
                themeElem.Register(jControl.Page);
            }
        }


        /// <summary>
        /// Used internally to track which properties have been set by the user.
        /// </summary>
        public void SetFlag(object prop, bool valueToSet)
        {
            if (_flags.ContainsKey((int)prop))
            {
                _flags[(int)prop] = valueToSet;
            }
            else
            {
                _flags.Add((int)prop, valueToSet);
            }
        }

        /// <summary>
        /// Used internally to track which properties have been set by the user.
        /// </summary>
        public void SetFlag(object prop)
        {
            SetFlag(prop, true);
        }

        /// <summary>
        /// Used internally to track which properties have been set by the user.
        /// </summary>
        public bool GetFlag(object prop)
        {
            if (_flags.ContainsKey((int)prop))
            {
                return _flags[(int)prop];
            }
            else
            {
                return false;
            }
        }

        public static string AppUrl()
        {
            return HttpContext.Current.Request.Url.Scheme + "://" +
                   HttpContext.Current.Request.Url.Authority.TrimEnd('/');
        }

        public static String ReverseMapPath(String physicalFilePath)
        {
            var appPath = HttpContext.Current.Server.MapPath("~");
            var url = String.Format("{0}{1}", HttpContext.Current.Request.ApplicationPath.TrimEnd('/'), physicalFilePath.Replace(appPath, "").Replace("\\", "/"));
            return url;
        }

        public static string ParseVirtualUrl(string url)
        {
            if (url.StartsWith("~"))
            {
                if (url.Contains("?"))
                {
                    var temp = url.Split('?');
                    url = VirtualPathUtility.ToAbsolute(temp[0]) + '?' + temp[1];
                }
                else
                {
                    url = VirtualPathUtility.ToAbsolute(url);
                }
            }
            return url;
        }

        public List<string> BuildFileList(string path, string filter, bool recursive)
        {
            var toReturn = new List<string>();

            //if we have a folder path, build  a list
            if (path != string.Empty)
            {
                var fileList = new List<FileInfo>();

                //build a list of ALL files in the target directory, recursing as specified
                RecurseFileList(new DirectoryInfo(HttpContext.Current.Server.MapPath(path)), ref fileList, recursive);

                //build a list of file extension filters
                List<string> filterList = filter.Split(',').ToList();

                if (filterList.Count > 1 || (filterList.Count == 1 && filterList[0] != ""))
                {
                    //select from the list of all files, only those files whose extension is in the filter list
                    fileList =
                        (from f in fileList
                         where filterList.Contains(f.Extension)
                         select f).ToList();
                }

                //select the paths of those files into the return list
                toReturn =
                    (from f in fileList
                     select jControlHelper.ReverseMapPath(f.FullName)).ToList();
            }
            return toReturn;
        }

        public string ParseUIIcon(Icons i)
        {
            return "ui-icon-" + HyphenateStringByCapitalsAndInts(i.ToString()).ToLower();
        }

        #endregion

        #region Private Methods

        private string TranslateThemeName(UIThemes theme)
        {
            return HyphenateStringByCapitalsAndInts(theme.ToString()).ToLower();
        }

        private string HyphenateStringByCapitalsAndInts(string source)
        {
            StringBuilder sb = new StringBuilder();

            char last = char.MinValue;
            foreach (char c in source)
            {
                if ((char.IsUpper(c) || char.IsDigit(c)) && last != char.MinValue)
                {
                    sb.Append('-');
                }
                sb.Append(c);
                last = c;
            }
            return sb.ToString();
        }

        private void RecurseFileList(DirectoryInfo dir, ref List<FileInfo> fileList, bool recurse)
        {
            fileList.AddRange(dir.GetFiles());
            if (recurse)
            {
                foreach (DirectoryInfo d in dir.GetDirectories())
                {
                    RecurseFileList(d, ref fileList, true);
                }
            }
        }

        #endregion

    }

    public enum UIThemes
    {
        None,
        Base,
        BlackTie,
        Blitzer,
        Cupertino,
        DotLuv,
        ExciteBike,
        HotSneaks,
        Humanity,
        MintChoc,
        Redmond,
        Smoothness,
        SouthStreet,
        Start,
        SwankyPurse,
        Trontastic,
        UiDarkness,
        UiLightness,
        Vader
    }
}
