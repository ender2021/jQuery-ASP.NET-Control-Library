using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jQuery.NET.Utility;
using Newtonsoft.Json;

namespace jQuery.NET.Controls
{
    [ToolboxData("<{0}:jPhotoGallery runat=\"server\" Height=\"500\" Width=\"500\"></{0}:jPhotoGallery>")]
    [ToolboxBitmap(typeof(ResourceFinder), "jQuery.NET.img.jPhotoGallery.bmp")]
    //[DesignerAttribute(typeof(jPhotoGalleryControlDesigner))]
    public class jPhotoGallery : Base.jGenericControl
    {
        #region Properties

        #region Plug-In
        int _autoplay = 0;
        bool _carousel = true;
        bool _carouselFollow = true;
        int _carouselSpeed = 200;
        int _carouselSteps = 0;
        bool _clickNext = false;
        EasingList _easing = EasingList.galleria;
        ImageCropList _imageCrop = ImageCropList.No;
        int _imageMargin = 0;
        bool _imagePan = false;
        int _imagePanSmoothness = 12;
        string _imagePosition = "center";
        int _lightboxFadeSpeed = 200;
        int _lightboxTransitionSpeed = 300;
        int _maxScaleRatio = 0;
        int _minScaleRatio = 0;
        string _overlayBackground = "#0b0b0b";
        int _overlayOpacity = 85;
        bool _pauseOnInteraction = true;
        bool _queue = true;
        int _show = 0;
        bool _showInfo = true;
        bool _showCounter = true;
        bool _showImageNav = true;
        ThumbnailsList _thumbnails = ThumbnailsList.Yes;
        TransitionList _transition = TransitionList.fade;
        TransitionList _transitionInitial = 0;
        int _transitionSpeed = 400;

        #endregion

        #region Configuration
        IEnumerable _dataSource = null;
        string _folderPath = String.Empty;
        string _folderFilter = ".jpg,.jpeg,.gif,.png,.bmp";
        bool _recursiveSearch = true;
        string _dataImageField = "Image";
        string _dataDescriptionField = String.Empty;
        string _dataTitleField = String.Empty;
        string _dataSourceLinkField = String.Empty;
        GalleryTheme _theme = GalleryTheme.Classic;
        string _themeUrl = "";
        string _themeCss = "";
        #endregion

        #endregion

        #region Accessors / Mutators

        #region Plug-In
        /// <summary>
        /// If true (greater than zero), the slideshow will automatically
        /// begin playing with that interval (in milliseconds). Zero by default (no autoplay).
        /// </summary>
        /// <value>The interval (in milliseconds) between slide transitions.</value>
        public int Autoplay
        {
            get { return _autoplay; }
            set
            {
                Helper.SetFlag(PropertyFlags.autoplay);
                _autoplay = value;
            }
        }

        /// <summary>
        /// If true, the gallery will include a thumbnail image carousel. 
        /// If false, the carousel is not included. True by default.
        /// </summary>
        public bool Carousel
        {
            get { return _carousel; }
            set
            {
                Helper.SetFlag(PropertyFlags.carousel);
                _carousel = value;
            }
        }

        /// <summary>
        /// This option defines whether the carousel should follow the active image.
        /// Note: animating heavy thumbnails can affect main image animation, so if 
        /// you are seeing big lags in the main animation try setting this option to false.
        /// True by default.
        /// </summary>
        public bool CarouselFollow
        {
            get { return _carouselFollow; }
            set
            {
                Helper.SetFlag(PropertyFlags.carouselFollow);
                _carouselFollow = value;
            }
        }

        /// <summary>
        /// Controls the slide speed of the carousel in milliseconds.
        /// Globally affects the carousel animation, both when following and sliding.
        /// </summary>
        /// <value>The slide speed of the carousel in milliseconds.</value>
        public int CarouselSpeed
        {
            get { return _carouselSpeed; }
            set
            {
                Helper.SetFlag(PropertyFlags.carouselSpeed);
                _carouselSpeed = value;
            }
        }

        /// <summary>
        /// Adds a click event over the stage that navigates to the next image in the gallery.
        /// Useful for mobile browsers and other simpler applications. Note that setting this to
        /// true will disable any other links that might exist in the data object.
        /// False by default.
        /// </summary>
        public bool ClickNext
        {
            get { return _clickNext; }
            set
            {
                Helper.SetFlag(PropertyFlags.clickNext);
                _clickNext = value;
            }
        }

        /// <summary>
        /// Sets the animation easing on a global level in Galleria. Value is "galleria" by default.
        /// </summary>
        public EasingList Easing
        {
            get { return _easing; }
            set
            {
                Helper.SetFlag(PropertyFlags.easing);
                _easing = value;
            }
        }

        /// <summary>
        /// Defines how the main image will be cropped inside the container.
        /// </summary>
        public ImageCropList ImageCrop
        {
            get { return _imageCrop; }
            set
            {
                Helper.SetFlag(PropertyFlags.imageCrop);
                _imageCrop = value;
            }
        }

        /// <summary>
        /// Apply a margin between the image and stage border. The margin is set in pixels.
        /// Default value is zero.
        /// </summary>
        public int ImageMargin
        {
            get { return _imageMargin; }
            set
            {
                Helper.SetFlag(PropertyFlags.imageMargin);
                _imageMargin = value;
            }
        }

        /// <summary>
        /// Apply a mouse-controlled movement of the image to reveal the cropped parts.
        /// If the panning becomes slow, control the smoothness (and performance) using the
        /// ImagePanSmoothness option. Default value is false.
        /// </summary>
        public bool ImagePan
        {
            get { return _imagePan; }
            set
            {
                Helper.SetFlag(PropertyFlags.imagePan);
                _imagePan = value;
            }
        }

        /// <summary>
        /// Sets the smoothness of the image pan movement. The higher value,
        /// the smoother effect but the higher the perfmance effects.
        /// Default value is 12.
        /// </summary>
        public int ImagePanSmoothness
        {
            get { return _imagePanSmoothness; }
            set
            {
                Helper.SetFlag(PropertyFlags.imagePanSmoothness);
                _imagePanSmoothness = value;
            }
        }

        /// <summary>
        /// Positions the main image inside the stage container. Works like the CSS
        /// background-position property, i.e. ‘top right’ or ‘20% 100%’. Accepts keywords,
        /// percents or pixels. The first value is the horizontal position and the second
        /// is the vertical. Default value is 'center'.
        /// </summary>
        public string ImagePosition
        {
            get { return _imagePosition; }
            set
            {
                Helper.SetFlag(PropertyFlags.imagePosition);
                _imagePosition = value;
            }
        }

        /// <summary>
        /// Controls the fade-in speed of images in a lightbox (via .showLightbox()).
        /// Value is in milliseconds.  Default value is 200.
        /// </summary>
        public int LightboxFadeSpeed
        {
            get { return _lightboxFadeSpeed; }
            set
            {
                Helper.SetFlag(PropertyFlags.lightboxFadeSpeed);
                _lightboxFadeSpeed = value;
            }
        }

        /// <summary>
        /// When calling .showLightbox() the lightbox will animate the white square before
        /// displaying the image. This value controls how fast it should animate in milliseconds.
        /// Default value is 300.
        /// </summary>
        public int LightboxTransitionSpeed
        {
            get { return _lightboxTransitionSpeed; }
            set
            {
                Helper.SetFlag(PropertyFlags.lightboxTransitionSpeed);
                _lightboxTransitionSpeed = value;
            }
        }

        /// <summary>
        /// Sets the maximum scale ratio for images. i.e., if you don't want to upscale
        /// any images, set this to 1. Zero will allow any scaling of the images.
        /// Default value is zero.
        /// </summary>
        public int MaxScaleRatio
        {
            get { return _maxScaleRatio; }
            set
            {
                Helper.SetFlag(PropertyFlags.maxScaleRatio);
                _maxScaleRatio = value;
            }
        }

        /// <summary>
        /// Sets the minimum scale ratio for images. i.e., if you don't want to downscale
        /// any images, set this to 1. Zero will allow any scaling of the images.
        /// Default value is zero. 
        /// </summary>
        public int MinScaleRatio
        {
            get { return _minScaleRatio; }
            set
            {
                Helper.SetFlag(PropertyFlags.minScaleRatio);
                _minScaleRatio = value;
            }
        }

        /// <summary>
        /// Defines the overlay background color when displaying a lightbox.
        /// Default value is #0b0b0b.
        /// </summary>
        public string OverlayBackground
        {
            get { return _overlayBackground; }
            set
            {
                Helper.SetFlag(PropertyFlags.overlayBackground);
                _overlayBackground = value;
            }
        }

        /// <summary>
        /// Sets the opacity of the overlay when displaying the lightbox.
        /// Value is a percentage.  Default value is 85.
        /// </summary>
        public int OverlayOpacity
        {
            get { return _overlayOpacity; }
            set
            {
                Helper.SetFlag(PropertyFlags.overlayOpacity);
                _overlayOpacity = value;
            }
        }

        /// <summary>
        /// Defines whether user interactions should halt autoplay.  Default value is true.
        /// </summary>
        public bool PauseOnInteraction
        {
            get { return _pauseOnInteraction; }
            set
            {
                Helper.SetFlag(PropertyFlags.pauseOnInteraction);
                _pauseOnInteraction = value;
            }
        }

        /// <summary>
        /// Control queueing of commands. Set to false to force the gallery to complete
        /// animations before accepting new commands.  Default value is true.
        /// </summary>
        /// <value></value>
        public bool Queue
        {
            get { return _queue; }
            set
            {
                Helper.SetFlag(PropertyFlags.queue);
                _queue = value;
            }
        }

        /// <summary>
        /// Set the initial index of the gallery. Default value is 0.
        /// </summary>
        public int Show
        {
            get { return _show; }
            set
            {
                Helper.SetFlag(PropertyFlags.show);
                _show = value;
            }
        }

        /// <summary>
        /// Toggle display of captions.  Default value is true.
        /// </summary>
        public bool ShowInfo
        {
            get { return _showInfo; }
            set
            {
                Helper.SetFlag(PropertyFlags.showInfo);
                _showInfo = value;
            }
        }

        /// <summary>
        /// Toggle display of the image counter. Default value is true.
        /// </summary>
        public bool ShowCounter
        {
            get { return _showCounter; }
            set
            {
                Helper.SetFlag(PropertyFlags.showCounter);
                _showCounter = value;
            }
        }

        /// <summary>
        /// Toggle display of the next/prev image overlays. Default value is true.
        /// </summary>
        public bool ShowImageNav
        {
            get { return _showImageNav; }
            set
            {
                Helper.SetFlag(PropertyFlags.showImageNav);
                _showImageNav = value;
            }
        }

        /// <summary>
        /// Controls the creation of thumbnails. Default value is ThumbnailsList.Yes.
        /// </summary>
        public ThumbnailsList Thumbnails
        {
            get { return _thumbnails; }
            set
            {
                Helper.SetFlag(PropertyFlags.thumbnails);
                _thumbnails = value;
            }
        }

        /// <summary>
        /// The transition to use when displaying the images. Default value is TransitionsList.fade.
        /// </summary>
        public TransitionList Transition
        {
            get { return _transition; }
            set
            {
                Helper.SetFlag(PropertyFlags.transition);
                _transition = value;
            }
        }

        /// <summary>
        /// Set this property to use a different transition for the first image transition.
        /// Default value is none.
        /// </summary>
        public TransitionList TransitionInitial
        {
            get { return _transitionInitial; }
            set
            {
                Helper.SetFlag(PropertyFlags.transitionInitial);
                _transitionInitial = value;
            }
        }

        /// <summary>
        /// Defines the length of the transition animation, in milliseconds.  Default value is 400.
        /// </summary>
        public int TransitionSpeed
        {
            get { return _transitionSpeed; }
            set
            {
                Helper.SetFlag(PropertyFlags.transitionSpeed);
                _transitionSpeed = value;
            }
        }

        #endregion

        #region Configuration


        /// <summary>
        /// Use an IEnumberable list of objects to populate the gallery.
        /// </summary>
        public IEnumerable DataSource
        {
            get { return _dataSource; }
            set { _dataSource = value; }
        }

        /// <summary>
        /// Set the virtual folder path of the directory source for the gallery.
        /// </summary>
        public string FolderPath
        {
            get { return _folderPath; }
            set { _folderPath = value; }
        }

        /// <summary>
        /// Set the extension filter list used to select images from the source directory.
        /// Default value is ".jpg,.jpeg,.gif,.png,.bmp"
        /// </summary>
        public string FolderFilter
        {
            get { return _folderFilter; }
            set { _folderFilter = value; }
        }

        /// <summary>
        /// Indicate whether or not to search the source directory recursively.
        /// Default value is true.
        /// </summary>
        public bool RecursiveSearch
        {
            get { return _recursiveSearch; }
            set { _recursiveSearch = value; }
        }

        /// <summary>
        /// The data object field name which will contain the path to the image. This is REQUIRED if you are using an object data source.  Default value is "Image".
        /// </summary>
        public string DataImageField
        {
            get { return _dataImageField; }
            set { _dataImageField = value; }
        }

        /// <summary>
        /// The data object field name which will contain the path to the image description. Set this value to enable captions. Default value is null.
        /// </summary>
        public string DataDescriptionField
        {
            get { return _dataDescriptionField; }
            set { _dataDescriptionField = value; }
        }

        /// <summary>
        /// The data object field name which will contain the path to the image title. Set this value to enable titles. Default value is null.
        /// </summary>
        public string DataTitleField
        {
            get { return _dataTitleField; }
            set { _dataTitleField = value; }
        }

        /// <summary>
        /// The data object field name which will contain the path to the image source/credit link. Set this value to enable source links. Default value is null.
        /// </summary>
        public string DataSourceLinkField
        {
            get { return _dataSourceLinkField; }
            set { _dataSourceLinkField = value; }
        }

        /// <summary>
        /// Choose a standard theme, or select Custom and provide ThemeUrl and ThemeCss to set a custom theme.
        /// Default value is the Classic theme.
        /// </summary>
        public GalleryTheme Theme
        {
            get { return _theme; }
            set
            {
                Helper.SetFlag(PropertyFlags.theme);
                _theme = value;
            }
        }

        /// <summary>
        /// Allows specification of an alternate Galleria theme file.
        /// </summary>
        public string ThemeUrl
        {
            get { return _themeUrl; }
            set
            {
                Helper.SetFlag(PropertyFlags.themeUrl);
                _themeUrl = value;
            }
        }

        /// <summary>
        /// Allows specification of an alternate Galleria css file.
        /// </summary>
        public string ThemeCss
        {
            get { return _themeCss; }
            set
            {
                Helper.SetFlag(PropertyFlags.themeCss);
                _themeCss = value;
            }
        }

        #endregion

        #endregion

        #region Enums
        /// <summary>
        /// A list of available animation easing settings for the jPhotoGallery.
        /// </summary>
        public enum EasingList
        {
            linear = 1,
            swing = 2,
            galleria = 3,
            galleriaIn = 4,
            galleriaOut = 5
        }
        /// <summary>
        /// A list of cropping options for the main image stage in the jPhotoGallery.
        /// </summary>
        public enum ImageCropList
        {
            /// <summary>
            /// All images will be scaled to fill the stage, centered and cropped.
            /// </summary>
            Yes = 1,
            /// <summary>
            /// Scale down so the entire image fits.
            /// </summary>
            No = 2,
            /// <summary>
            /// Scale the image to fill the height of the stage.
            /// </summary>
            Height = 3,
            /// <summary>
            /// Scale the image to fill the width of the stage.
            /// </summary>
            Width = 4
        }
        /// <summary>
        /// A list of display options for thumbnails in the jPhotoGallery.
        /// </summary>
        public enum ThumbnailsList
        {
            /// <summary>
            /// Create thumbnails for the carousel.
            /// </summary>
            Yes = 1,
            /// <summary>
            /// Do not create thumbnails or show the carousel.
            /// </summary>
            No = 2,
            /// <summary>
            /// Create empty spans with the className img instead of thumbnails.
            /// </summary>
            Empty = 3,
            /// <summary>
            /// Create empty spans with numbers instead of thumbnails.
            /// </summary>
            Numbers = 4
        }
        /// <summary>
        /// Defines available slide transitions
        /// </summary>
        public enum TransitionList
        {
            /// <summary>
            /// Crossfade between images.
            /// </summary>
            fade = 1,
            /// <summary>
            /// Fades into background color between images.
            /// </summary>
            flash = 2,
            /// <summary>
            /// Quickly removes the image into background color, then fades in next image.
            /// </summary>
            pulse = 3,
            /// <summary>
            /// Slides the images depending on image position.
            /// </summary>
            slide = 4,
            /// <summary>
            /// Fade between images and slide slightly at the same time.
            /// </summary>
            fadeslide = 5
        }
        /// <summary>
        /// Defines available slide transitions
        /// </summary>
        public enum GalleryTheme
        {
            /// <summary>
            /// Loads the "Classic" galleria theme.
            /// </summary>
            Classic = 1,
            /// <summary>
            /// Causes the control to look for custom theme info.
            /// </summary>
            Custom = 2
        }
        /// <summary>
        /// A list of Galleria properties. Used internally to track which properties have been set by the user.
        /// </summary>
        private enum PropertyFlags
        {
            autoplay = 0,
            carousel = 1,
            carouselFollow = 2,
            carouselSpeed = 3,
            carouselSteps = 4,
            clickNext = 5,
            easing = 6,
            imageCrop = 7,
            imageMargin = 8,
            imagePan = 9,
            imagePanSmoothness = 10,
            imagePosition = 11,
            lightboxFadeSpeed = 12,
            lightboxTransitionSpeed = 13,
            maxScaleRatio = 14,
            minScaleRatio = 15,
            overlayBackground = 16,
            overlayOpacity = 17,
            pauseOnInteraction = 18,
            queue = 19,
            show = 20,
            showInfo = 21,
            showCounter = 22,
            showImageNav = 23,
            theme = 24,
            thumbnails = 25,
            transition = 26,
            transitionInitial = 27,
            transitionSpeed = 28,
            themeCss = 29,
            themeUrl = 30
        }
        #endregion

        #region Lifecycle
        protected override void OnPreRender(EventArgs e)
        {
            //register jQuery
            Helper.RegisterJquery();

            //register galleria
            var galleria = new jWebResource("galleria-library", new jWebResourceName("galleria_1_2_2_min.js"));
            galleria.Register(Page);

            //if we're running a standard theme, register required resources
            if (this.Theme != GalleryTheme.Custom)
            {
                var themeInfo = MapTheme(Theme);
                this._themeUrl = jControlHelper.AppUrl() + jWebResource.GetResourceUri(new jWebResourceName(themeInfo.Key));
                this._themeCss = jControlHelper.AppUrl() + jWebResource.GetResourceUri(new jWebResourceName(themeInfo.Value));
                
            }

            //register the theme css
            var themeStyle = new jWebResource("galleria-theme-" + this.ID, new Uri(this._themeCss), jWebResourceType.Css);
            themeStyle.Register(Page);

            //this format string will build a onDomReady jquery handler to initialize galleria
            var initFormat = "jQuery(function(){{window.jqNET={{galleria:{{themeCss:'{0}'}}}};Galleria.loadTheme('{1}');jQuery('#{2}').galleria({3});}});";
            
            //build out the options string
            var optionStr = JsonConvert.SerializeObject(BuildOptions());

            //compose the init body
            var initBody = string.Format(initFormat, this._themeCss, this._themeUrl, this.ClientID, optionStr);

            //build the init control
            var initControl = new jWebResource("galleria-init-" + this.ClientID, initBody, jWebResourceType.Javascript);

            //register the control
            initControl.Register(Page);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.WriteLine(string.Format("<div id=\"{0}\" style=\"height:{1};width:{2}; background-color: #000;\">",
                              this.ClientID, this.Height.ToString(), this.Width.ToString()));
            this.RenderContents(writer);
            writer.WriteLine("</div>");
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.WriteLine(
                "<p style=\"color: #FFF; text-align: center;\">Please enable JavaScript to view this photo gallery.</p>");
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Maps a GalleryTheme enum to the corresponding script file
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private KeyValuePair<string, string> MapTheme(GalleryTheme t)
        {
            switch (t)
            {
                case GalleryTheme.Custom:
                    return new KeyValuePair<string, string>("","");
                default:
                    return new KeyValuePair<string, string>("galleria_classic_min.js", "galleria_classic_min.css");
            }
        }

        private Dictionary<string, object> BuildOptions()
        {
            //if no datasource was set, build one from a specified file path
            if (DataSource == null & FolderPath != string.Empty)
            {
                DataSource = Helper.BuildFileList(this.FolderPath, this.FolderFilter, this.RecursiveSearch);
            }
            else if (DataSource == null & FolderPath == string.Empty)
            {
                throw new Exception("No data source set for jQuery.NET " + this.ClientID);
            }

            //build the options object
            var options = BuildDataSource();
            if (Helper.GetFlag(PropertyFlags.autoplay))
            {
                options.Add("autoplay", Autoplay);
            }
            if (Helper.GetFlag(PropertyFlags.carousel))
            {
                options.Add("carousel", Carousel);
            }
            if (Helper.GetFlag(PropertyFlags.carouselFollow))
            {
                options.Add("carouselFollow", CarouselFollow);
            }
            if (Helper.GetFlag(PropertyFlags.carouselSpeed))
            {
                options.Add("carouselSpeed", CarouselSpeed);
            }
            if (Helper.GetFlag(PropertyFlags.clickNext))
            {
                options.Add("clicknext", ClickNext);
            }
            if (Helper.GetFlag(PropertyFlags.easing))
            {
                options.Add("easing", Easing.ToString());
            }
            if (Helper.GetFlag(PropertyFlags.imageCrop))
            {
                object tempVal = null;
                if (ImageCrop == ImageCropList.Yes)
                {
                    tempVal = true;
                }
                else if (ImageCrop == ImageCropList.No)
                {
                    tempVal = false;
                }
                else
                {
                    tempVal = ImageCrop.ToString().ToLower();
                }
                options.Add("imageCrop", tempVal);
            }
            if (Helper.GetFlag(PropertyFlags.imageMargin))
            {
                options.Add("imageMargin", ImageMargin);
            }
            if (Helper.GetFlag(PropertyFlags.imagePan))
            {
                options.Add("imagePan", ImagePan);
            }
            if (Helper.GetFlag(PropertyFlags.imagePanSmoothness))
            {
                options.Add("imagePanSmoothness", ImagePanSmoothness);
            }
            if (Helper.GetFlag(PropertyFlags.imagePosition))
            {
                options.Add("imagePosition", ImagePosition);
            }
            if (Helper.GetFlag(PropertyFlags.lightboxFadeSpeed))
            {
                options.Add("lightboxFadeSpeed", LightboxFadeSpeed);
            }
            if (Helper.GetFlag(PropertyFlags.lightboxTransitionSpeed))
            {
                options.Add("lightboxTransitionSpeed", LightboxTransitionSpeed);
            }
            if (Helper.GetFlag(PropertyFlags.maxScaleRatio))
            {
                options.Add("maxScaleRatio", MaxScaleRatio);
            }
            if (Helper.GetFlag(PropertyFlags.minScaleRatio))
            {
                options.Add("minScaleRatio", MinScaleRatio);
            }
            if (Helper.GetFlag(PropertyFlags.overlayBackground))
            {
                options.Add("overlayBackground", OverlayBackground);
            }
            if (Helper.GetFlag(PropertyFlags.overlayOpacity))
            {
                options.Add("overlayOpacity", OverlayOpacity);
            }
            if (Helper.GetFlag(PropertyFlags.pauseOnInteraction))
            {
                options.Add("pauseOnInteraction", PauseOnInteraction);
            }
            if (Helper.GetFlag(PropertyFlags.queue))
            {
                options.Add("queue", Queue);
            }
            if (Helper.GetFlag(PropertyFlags.show))
            {
                options.Add("show", Show);
            }
            if (Helper.GetFlag(PropertyFlags.showCounter))
            {
                options.Add("showCounter", ShowCounter);
            }
            if (Helper.GetFlag(PropertyFlags.showImageNav))
            {
                options.Add("showImageNav", ShowImageNav);
            }
            if (Helper.GetFlag(PropertyFlags.showInfo))
            {
                options.Add("showInfo", ShowInfo);
            }
            if (Helper.GetFlag(PropertyFlags.theme))
            {
                options.Add("theme", Theme);
            }
            if (Helper.GetFlag(PropertyFlags.thumbnails))
            {
                object tempVal = null;
                if (Thumbnails == ThumbnailsList.Yes)
                {
                    tempVal = true;
                }
                else if (Thumbnails == ThumbnailsList.No)
                {
                    tempVal = false;
                }
                else
                {
                    tempVal = ImageCrop.ToString().ToLower();
                }
                options.Add("thumbnails", tempVal);
            }
            if (Helper.GetFlag(PropertyFlags.transition))
            {
                options.Add("transition", Transition.ToString());
            }
            if (Helper.GetFlag(PropertyFlags.transitionInitial))
            {
                options.Add("transitionInitial", TransitionInitial.ToString());
            }
            if (Helper.GetFlag(PropertyFlags.transitionSpeed))
            {
                options.Add("transitionSpeed", TransitionSpeed);
            }
            return options;
        }

        private Dictionary<string, object> BuildDataSource()
        {
            var toReturn = new Dictionary<string, object>();
            var sources = new List<Dictionary<string, object>>();
            if (this.DataSource != null)
            {
                foreach (object ds in DataSource)
                {
                    var tempObj = new Dictionary<string, object>();
                    if (ds.GetType() == typeof(string))
                    {
                        tempObj.Add("image", ds);
                    }
                    else
                    {
                        tempObj.Add("image", ds.GetType().GetProperty(this.DataImageField).GetValue(ds, null));
                        if (DataDescriptionField != string.Empty)
                        {
                            tempObj.Add("description", ds.GetType().GetProperty(this.DataDescriptionField).GetValue(ds, null));
                        }
                        if (DataTitleField != string.Empty)
                        {
                            tempObj.Add("title", ds.GetType().GetProperty(this.DataTitleField).GetValue(ds, null));
                        }
                        if (DataSourceLinkField != string.Empty)
                        {
                            tempObj.Add("link", ds.GetType().GetProperty(this.DataSourceLinkField).GetValue(ds, null));
                        }
                    }
                    sources.Add(tempObj);
                }
            }
            if (!(sources.Count == 0))
            {
                toReturn.Add("dataSource", sources.ToArray());
            }
            return toReturn;
        }

        

        #endregion
    }
}
