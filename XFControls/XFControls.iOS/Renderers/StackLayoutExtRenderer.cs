using System;
using System.ComponentModel;
using CoreAnimation;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFControls.iOS.Renderers;
using XFControls.Renderers;

[assembly: ExportRenderer(typeof(StackLayoutExt), typeof(StackLayoutExtRenderer))]

namespace XFControls.iOS.Renderers
{
    public class StackLayoutExtRenderer : ViewRenderer<StackLayoutExt, UIView>
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e != null || Element == null)
                return;

            this.SetNeedsDisplay(); // Force a call to Draw
        }

        public override void Draw(CGRect rect)
        {
            using (var context = UIGraphics.GetCurrentContext())
            {

             



               // var path = CGPath.EllipseFromRect(rect);
               // context.AddPath(path);
               //// context.SetFillColor(this.Element.Color.ToCGColor());
               // context.DrawPath(CGPathDrawingMode.Fill);
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<StackLayoutExt> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null)
                return;
            
            if (NativeView != null)
            {
                var shadowLayer = NativeView.Layer;
                shadowLayer.ShadowOffset = new CGSize(1, 1);
                shadowLayer.ShadowColor = UIColor.Cyan.CGColor;
                shadowLayer.ShadowRadius = 4.0f;
                shadowLayer.ShadowOpacity = 0.8f;
            //    shadowLayer.ShadowPath = Control.Layer.ShadowPath


            }

        }
    }
}