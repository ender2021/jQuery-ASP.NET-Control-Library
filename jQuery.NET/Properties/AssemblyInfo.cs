using System.Reflection;
using System.Security;
using System.Web.UI;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("jQuery.NET")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("U.C. Santa Barbara")]
[assembly: AssemblyProduct("jQuery.NET")]
[assembly: AssemblyCopyright("Copyright © U.C. Santa Barbara 2011")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("e487e095-e8fe-48db-af85-5c545068da9e")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: AllowPartiallyTrustedCallers]

//scripts
[assembly: WebResource("jQuery.NET.js.galleria_1_2_2_min.js", "text/javascript")]
[assembly: WebResource("jQuery.NET.js.galleria_classic_min.js", "text/javascript")]
[assembly: WebResource("jQuery.NET.js.dualListBox_2_0_min.js", "text/javascript")]
[assembly: WebResource("jQuery.NET.js.cycle_all_min.js", "text/javascript")]
[assembly: WebResource("jQuery.NET.js.fancybox_1_3_4_min.js", "text/javascript")]
[assembly: WebResource("jQuery.NET.js.mousewheel_3_0_4_min.js", "text/javascript")]

//images
[assembly: WebResource("jQuery.NET.img.classic_loader.gif", "image/gif")]
[assembly: WebResource("jQuery.NET.img.classic_map.png", "image/png")]
[assembly: WebResource("jQuery.NET.img.dlb_button_map.png", "image/png")]
[assembly: WebResource("jQuery.NET.img.dlb_button_bg.png", "image/png")] 
//fancybox...see below

//styles
[assembly: WebResource("jQuery.NET.css.galleria_classic_min.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("jQuery.NET.css.dualListBox_min.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("jQuery.NET.css.cycle_min.css", "text/css")]
[assembly: WebResource("jQuery.NET.css.fancybox_1_3_4_min.css", "text/css", PerformSubstitution = true)]

//toolbox icons
[assembly: WebResource("jQuery.NET.img.jPhotoGallery.bmp", "image/x-ms-bmp")]
[assembly: WebResource("jQuery.NET.img.jDualListBox.bmp", "image/x-ms-bmp")]
[assembly: WebResource("jQuery.NET.img.jCycle.bmp", "image/x-ms-bmp")]
[assembly: WebResource("jQuery.NET.img.jFancyBox.bmp", "image/x-ms-bmp")]
[assembly: WebResource("jQuery.NET.img.jFancyBoxContent.bmp", "image/x-ms-bmp")]
[assembly: WebResource("jQuery.NET.img.jAutocomplete.bmp", "image/x-ms-bmp")]
[assembly: WebResource("jQuery.NET.img.jAccordion.bmp", "image/x-ms-bmp")]
[assembly: WebResource("jQuery.NET.img.jAccordionPanel.bmp", "image/x-ms-bmp")]



//freakin fancybox's billions of images...
[assembly: WebResource("jQuery.NET.img.fancybox.fancy_close.png", "image/png")]
[assembly: WebResource("jQuery.NET.img.fancybox.fancy_loading.png", "image/png")]
[assembly: WebResource("jQuery.NET.img.fancybox.fancy_nav_left.png", "image/png")]
[assembly: WebResource("jQuery.NET.img.fancybox.fancy_nav_right.png", "image/png")]
[assembly: WebResource("jQuery.NET.img.fancybox.fancy_shadow_e.png", "image/png")]
[assembly: WebResource("jQuery.NET.img.fancybox.fancy_shadow_n.png", "image/png")]
[assembly: WebResource("jQuery.NET.img.fancybox.fancy_shadow_ne.png", "image/png")]
[assembly: WebResource("jQuery.NET.img.fancybox.fancy_shadow_nw.png", "image/png")]
[assembly: WebResource("jQuery.NET.img.fancybox.fancy_shadow_s.png", "image/png")]
[assembly: WebResource("jQuery.NET.img.fancybox.fancy_shadow_se.png", "image/png")]
[assembly: WebResource("jQuery.NET.img.fancybox.fancy_shadow_sw.png", "image/png")]
[assembly: WebResource("jQuery.NET.img.fancybox.fancy_shadow_w.png", "image/png")]
[assembly: WebResource("jQuery.NET.img.fancybox.fancy_title_left.png", "image/png")]
[assembly: WebResource("jQuery.NET.img.fancybox.fancy_title_main.png", "image/png")]
[assembly: WebResource("jQuery.NET.img.fancybox.fancy_title_over.png", "image/png")]
[assembly: WebResource("jQuery.NET.img.fancybox.fancy_title_right.png", "image/png")]
[assembly: WebResource("jQuery.NET.img.fancybox.fancybox.png", "image/png")]
[assembly: WebResource("jQuery.NET.img.fancybox.fancybox_x.png", "image/png")]
[assembly: WebResource("jQuery.NET.img.fancybox.fancybox_y.png", "image/png")]
[assembly: WebResource("jQuery.NET.img.fancybox.blank.gif", "image/gif")]