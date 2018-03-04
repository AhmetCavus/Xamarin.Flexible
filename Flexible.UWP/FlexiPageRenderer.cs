using Cinary.Flexible;
using Cinary.Flexible.UWP;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(FlexiPage), typeof(FlexiPageRenderer))]
namespace Cinary.Flexible.UWP
{
    public class FlexiPageRenderer : ViewRenderer<FlexiPage, Windows.UI.Xaml.FrameworkElement>
    {
        public FlexiPageRenderer()
        {
        }

        Page _currentPage;

        protected override void OnElementChanged(ElementChangedEventArgs<FlexiPage> e)
        {
            base.OnElementChanged(e);
            var pageViewContainer = e.NewElement as FlexiPage;
            if (e.NewElement != null)
            {
                ChangePage(e.NewElement.Content);
            }
            else
            {
                ChangePage(null);
            }

        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Content")
            {
                ChangePage(Element.Content);
            }
        }

        bool _contentNeedsLayout;

        protected override Windows.Foundation.Size ArrangeOverride(Windows.Foundation.Size finalSize)
        {
            var res = base.ArrangeOverride(finalSize);
            if (finalSize.Height > 0 && finalSize.Width > 0 && _contentNeedsLayout && this.Control != null)
            {
                if (_currentPage != null)
                {
                    _currentPage.Layout(new Rectangle(0, 0, Element.Width, Element.Height));
                }
                this.Control.Measure(finalSize);
                //this.Control.UpdateLayout();
                //this.Control.Measure(msw, msh);
                //this.Control.Layout(0, 0, r, b);
                _contentNeedsLayout = false;
            }
            return res;
        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            //var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            //return dp;
            return 0;
        }

        void ChangePage(Page page)
        {

            //TODO handle current page
            if (page != null)
            {
                var parentPage = Element.Parent;
                page.Parent = parentPage;

                var existingRenderer = page.GetRenderer();
                if (existingRenderer == null)
                {
                    var renderer = Platform.CreateRenderer(page);
                    page.SetRenderer(renderer);
                    existingRenderer = page.GetRenderer();
                }
                _contentNeedsLayout = true;
                SetNativeControl(existingRenderer.ContainerElement);

                //UpdateLayout();
                //this.Control.UpdateLayout();

                //TODO update the page
                _currentPage = page;
            }
            else
            {
                //TODO - update the page
                _currentPage = null;
            }

            if (_currentPage == null)
            {
                //have to set somethign for android not to get pissy
                var view = new Windows.UI.Xaml.Controls.ContentControl();
                SetNativeControl(view);
            }
        }

    }
}
