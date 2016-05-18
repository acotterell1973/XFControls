using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFControls.iOS.Renderers;
using XFControls.Renderers;

[assembly: ExportRenderer(typeof(WrappedTruncatedLabel), typeof(WrappedTruncatedLabelRenderer))]
namespace XFControls.iOS.Renderers
{
    public class WrappedTruncatedLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (Control == null) return;
            Control.LineBreakMode = UILineBreakMode.TailTruncation;
            Control.Lines = 0;
        }
    }
}
