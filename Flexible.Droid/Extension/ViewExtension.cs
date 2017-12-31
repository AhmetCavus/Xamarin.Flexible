using System;
using Xamarin.Forms;
using System.Reflection;
using Xamarin.Forms.Platform.Android;
using Android.Content;

namespace Xamarin.Flexible.Extension
{
    public static class ViewExtensions
    {
        private static readonly Type _platformType = Type.GetType("Xamarin.Forms.Platform.Android.Platform, Xamarin.Forms.Platform.Android", true);
        private static BindableProperty _rendererProperty;

        public static BindableProperty RendererProperty
        {
            get
            {
                _rendererProperty = (BindableProperty)_platformType.GetField("RendererProperty", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                    .GetValue(null);

                return _rendererProperty;
            }
        }

        //public static IVisualElementRenderer GetRenderer(this VisualElement element, Context context)
        //{
        //    //var value = bindableObject.GetValue(RendererProperty);
        //    return Platform.CreateRenderer(element);
        //}

        //public static IVisualElementRenderer GetRenderer(this VisualElement element)
        //{
        //    //var value = bindableObject.GetValue(RendererProperty);
        //    return Platform.CreateRenderer(element);
        //}

        public static global::Android.Views.View GetNativeView(this VisualElement element)
        {
            var renderer = element.GetRenderer();
            var viewGroup = renderer.View;
            return viewGroup;
        }

        public static void SetRenderer(this BindableObject bindableObject, IVisualElementRenderer renderer)
        {
            //			var value = bindableObject.GetValue (RendererProperty);
            bindableObject.SetValue(RendererProperty, renderer);
        }

        public static Point GetNativeScreenPosition(this VisualElement element)
        {
            var view = element.GetNativeView();
            var point = Point.Zero;
            if (view != null)
            {
                int[] location = new int[2];
                view.GetLocationOnScreen(location);
                point = new Xamarin.Forms.Point(location[0], location[1]);
            }
            return point;
        }

        /// <summary>
        /// Gets the or create renderer.
        /// </summary>
        /// <returns>The or create renderer.</returns>
        /// <param name="source">Source.</param>
        public static IVisualElementRenderer GetOrCreateRenderer(this VisualElement source, Context context)
        {
            return GetOrCreateRenderer(source);
        }

        /// <summary>
        /// Gets the or create renderer.
        /// </summary>
        /// <returns>The or create renderer.</returns>
        /// <param name="source">Source.</param>
        public static IVisualElementRenderer GetOrCreateRenderer(this VisualElement source)
        {
            var renderer = source.GetRenderer();
            if (renderer == null)
            {
                renderer = Platform.CreateRenderer(source);
                source.SetRenderer(renderer);
                renderer = source.GetRenderer();
            }
            return renderer;
        }
    }
}