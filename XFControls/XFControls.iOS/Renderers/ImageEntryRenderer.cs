using System.ComponentModel;
using System.Drawing;
using CoreAnimation;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFControls.iOS.Renderers;
using XFControls.Renderers;

[assembly: ExportRenderer(typeof(ImageEntry), typeof(ImageEntryRenderer))]
namespace XFControls.iOS.Renderers
{
    public class ImageEntryRenderer : ViewRenderer<ImageEntry, UIView>
    {
        private UIView _layoutPanel;
        private UIImageView _iconView;
        private UIStackView _stackLayout;
        private UITextField _inputView;
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            //if (e.PropertyName == ImageEntry.TextEntryProperty.PropertyName)
            //{
            //    var _stackLayout = Control as UIStackView;
            //    if (_stackLayout != null)
            //    {
            //        var textEntryView = (UITextField)_stackLayout.ArrangedSubviews[0];
            //        textEntryView.Text = "this.Element.Text";
            //    }
            //}
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ImageEntry> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                
                RectangleF initialViewFrame = new RectangleF(0, 0, 0, 0);
                _layoutPanel = new UIView(initialViewFrame)
                {
                    AutoresizingMask = UIViewAutoresizing.All,
                    //    ContentMode = UIViewContentMode.ScaleToFill,
                    BackgroundColor = UIColor.Cyan
       
                };
              //  _layoutPanel.Layer.BorderColor = UIColor.FromRGB(224, 224, 224).CGColor;
              //  _layoutPanel.Layer.BorderWidth = 2.0f;
             
                _layoutPanel.Layer.MasksToBounds = true;
               
                var imageEntry = e.NewElement;

                _stackLayout = new UIStackView
                {
                    Spacing = 5,
                    Axis = UILayoutConstraintAxis.Horizontal,
                    TranslatesAutoresizingMaskIntoConstraints = false
                };

                _iconView = new UIImageView(UIImage.FromBundle(imageEntry.Icon)) { ContentMode = UIViewContentMode.ScaleAspectFit };

                _layoutPanel.Frame = new RectangleF((float) _iconView.Frame.X, (float) _iconView.Frame.Y, (float) _iconView.Frame.Width, (float) _iconView.Frame.Height+6.0f); 
               
                _stackLayout.AddArrangedSubview(_iconView);

                _inputView = new UITextField
                {
                    Text = imageEntry.Text,
                    Placeholder = "place holder text",

                    AutoresizingMask = UIViewAutoresizing.FlexibleRightMargin | UIViewAutoresizing.FlexibleBottomMargin,
                    BackgroundColor = UIColor.LightGray

                };
                _stackLayout.AddArrangedSubview(_inputView);

                _stackLayout.LayoutIfNeeded();
             
                UIView bottomBorder = new UIView();
                bottomBorder.Layer.BorderWidth = 1;
                bottomBorder.Layer.BorderColor = UIColor.FromRGB(224, 224, 224).CGColor;
                bottomBorder.Frame = new RectangleF(0, 0, (float)_stackLayout.Frame.Width, 2);

                _layoutPanel.AddSubview(_stackLayout);
                _layoutPanel.AddSubview(bottomBorder);
              
                _layoutPanel.SetNeedsLayout();
                SetNativeControl(_layoutPanel);
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