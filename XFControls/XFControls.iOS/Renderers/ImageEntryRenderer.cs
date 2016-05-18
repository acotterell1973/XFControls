using System;
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
        private UIView _bottomBorder;
        private UIImageView _iconView;
        private UIStackView _stackLayout;
        private UITextField _inputView;
        private UIStackView _borderLayout;

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
            if (e.OldElement != null || Element == null)
                return;

            if (Control == null)
            {
                //control layout
                _stackLayout = new UIStackView
                {
                    Spacing = 5,
                    Axis = UILayoutConstraintAxis.Horizontal,
                    TranslatesAutoresizingMaskIntoConstraints = false
                };

                _borderLayout = new UIStackView
                {
                    Spacing = 5,
                    Axis = UILayoutConstraintAxis.Vertical,
                    TranslatesAutoresizingMaskIntoConstraints = false
                };


                //icon to display
                _iconView = new UIImageView(UIImage.FromBundle(Element.Icon)) { ContentMode = UIViewContentMode.ScaleAspectFit };
                //TODO: configurable to position left or right of the textbox
                _stackLayout.AddArrangedSubview(_iconView);

                //user input text
                _inputView = new UITextField
                {
                    Text = Element.Text,
                    Placeholder = Element.Placeholder,
                    AutoresizingMask = UIViewAutoresizing.FlexibleRightMargin | UIViewAutoresizing.FlexibleBottomMargin,
                    TextColor = UIColor.DarkGray,
 
                };

                //Add input box width
                AddConstraint(NSLayoutConstraint.Create(_inputView, NSLayoutAttribute.Width, NSLayoutRelation.Equal, null, NSLayoutAttribute.Width, 1, 250.0f));
                _inputView.VerticalAlignment = UIControlContentVerticalAlignment.Bottom;
                _stackLayout.AddArrangedSubview(_inputView);

                _borderLayout.AddArrangedSubview(_stackLayout);

               
                var layoutWidth = (float) ((float) (_iconView.Frame.Width + 250.0f) + Frame.Width);
                _layoutPanel =
                    new UIView(new RectangleF(0, 0, layoutWidth,
                        (float)_iconView.Frame.Height + 5.0f))
                    {
                        AutoresizingMask = UIViewAutoresizing.All,
                        ContentMode = UIViewContentMode.ScaleToFill
                    };
                
                CALayer border = new CALayer();
                nfloat thickness = 1.0f;
                border.BackgroundColor = UIColor.Black.CGColor;
                border.Frame = new CGRect(0.0f, _layoutPanel.Frame.Height - thickness, layoutWidth, thickness);
                _layoutPanel.Layer.MasksToBounds = true;
                _layoutPanel.AddSubview(_stackLayout);
                _layoutPanel.Layer.AddSublayer(border);

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

        /// <summary>
        /// Resizes the height.
        /// </summary>
        //private void ResizeHeight()
        //{
        //    if (Element.HeightRequest >= 0) return;

        //    var height = Math.Max(Bounds.Height,
        //        new UITextField { Font = Control.Font }.IntrinsicContentSize.Height);

        //    Control.Frame = new CGRect(0.0f, 0.0f, (nfloat)Element.Width, (nfloat)height);

        //    Element.HeightRequest = height;
        //}
    }
}