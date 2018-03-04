﻿using Android.Views;
using Cinary.Flexible;
using Cinary.Flexible.Droid;
using Cinary.Flexible.Extension;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FlexiPage), typeof(FlexiPageRenderer))]
namespace Cinary.Flexible.Droid
{
    public class FlexiPageRenderer : ViewRenderer<FlexiPage, global::Android.Views.View>
    {
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
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            if ((changed || _contentNeedsLayout) && this.Control != null)
            {
                if (_currentPage != null)
                {
                    _currentPage.Layout(new Rectangle(0, 0, Element.Width, Element.Height));
                }
                var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
                var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);
                this.Control.Measure(msw, msh);
                this.Control.Layout(0, 0, r, b);
                _contentNeedsLayout = false;
            }
        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            return dp;
        }


        void ChangePage(Page page)
        {

            //TODO handle current page
            if (page != null)
            {
                var parentPage = Element.GetParentPage();
                page.Parent = parentPage;

                var existingRenderer = page.GetRenderer();
                if (existingRenderer == null)
                {
                    var renderer = Platform.CreateRenderer(page);
                    page.SetRenderer(renderer);
                    existingRenderer = page.GetRenderer();
                }
                _contentNeedsLayout = true;
                SetNativeControl(existingRenderer.View);
                Invalidate();
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
                var view = new global::Android.Views.View(this.Context);
                view.SetBackgroundColor(Element.BackgroundColor.ToAndroid());
                SetNativeControl(view);
            }
        }

    }
}