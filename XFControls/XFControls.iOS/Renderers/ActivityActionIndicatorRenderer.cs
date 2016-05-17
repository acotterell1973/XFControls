using System;
using System.ComponentModel;
using System.Drawing;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFControls.iOS.Renderers;
using XFControls.Renderers;
//http://www.patridgedev.com/2012/10/05/creating-an-animated-spinner-in-a-monotouch-uiimageview/
//https://blog.xamarin.com/using-custom-controls-in-xamarin-forms-on-android/
[assembly: ExportRenderer(typeof(ActivityActionIndicator), typeof(SpnnerImageViewRenderer))]
namespace XFControls.iOS.Renderers
{
    public class SpnnerImageViewRenderer : ViewRenderer<ActivityActionIndicator, UIView>
    {
        private UIImageView _iconView;
        private UIView _layoutView;
        private readonly CABasicAnimation _rotationAnimation = CABasicAnimation.FromKeyPath("transform.rotation");
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (this.Element == null || this.Control == null)
                return;

            if (e.PropertyName == ActivityActionIndicator.IsRunningProperty.PropertyName)
            {
                if (Element.IsRunning)
                {
                    _iconView.Layer.RemoveAnimation("_rotationAnimation");
                    this.Hidden = true;
                }
                else
                {
                    _iconView.Layer.AddAnimation(_rotationAnimation, "_rotationAnimation");
                    Hidden = false;
                }
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ActivityActionIndicator> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null)
                return;

            if (Control == null)
            {
              
                // Image to be rotated (in this case, found in the project as "/Assets/Images/loading_icon.png").
                _iconView = new UIImageView(UIImage.FromBundle(Element.Icon)) ;
    
                _rotationAnimation.To = NSNumber.FromDouble(Math.PI * 2); // full rotation (in radians)
                _rotationAnimation.RepeatCount = int.MaxValue; // repeat forever
                _rotationAnimation.Duration = 1;

                // Give the added animation a key for referencing it later (to remove, in this case).
                _iconView.Layer.AddAnimation(_rotationAnimation, "_rotationAnimation");
                _layoutView = new UIView(new RectangleF(0, 0, (float) _iconView.Frame.Width, (float) _iconView.Frame.Height));
                _layoutView.AddSubview(_iconView);
                _layoutView.SetNeedsLayout();
                SetNativeControl(_layoutView);
            }

            if (e.OldElement != null)
            {
                // Unsubscribe

            }
            if (e.NewElement != null)
            {
                // Subscribe
                //  _iconView.Image = UIImage.FromFile("person.png");
            }
        }

    }
}