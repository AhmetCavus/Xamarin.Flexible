using Xamarin.Forms;

namespace Xamarin.Flexible
{
    public class FlexiPage : View
    {
        public FlexiPage()
        {
        }

        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(ContentProperty), typeof(Page), typeof(FlexiPage));

        public Page Content
        {
            get { return (Page)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
    }
}
