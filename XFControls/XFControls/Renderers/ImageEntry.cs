using Xamarin.Forms;

namespace XFControls.Renderers
{
    public class ImageEntry : View
    {
        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(
            propertyName: "Icon",
            returnType: typeof(string),
            declaringType: typeof(ImageEntry));

        public string Icon { get; set; }


        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: "Text",
            returnType: typeof(string),
            declaringType: typeof(ImageEntry));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        //public static readonly BindableProperty BottomBorderColorProperty = BindableProperty.Create("BottomBorderColor", typeof(Color), typeof(ImageEntry), Color.Black);



        //public Color BottomBorderColor
        //{
        //    get
        //    {
        //        return (Color)GetValue(BottomBorderColorProperty);
        //    }
        //    set
        //    {
        //        SetValue(BottomBorderColorProperty, value);
        //    }
        //}

        //public string Text
        //{
        //    get { return (string)GetValue(Entry.TextProperty); }
        //    set { SetValue(Entry.TextProperty, value); }
        //}

        //public string Placeholder
        //{
        //    get { return (string)GetValue(Entry.PlaceholderProperty); }
        //    set { SetValue(Entry.PlaceholderProperty, value); }
        //}


        //public ImageEntry()
        //{
        //    var entryExtension = new Entry {Text = "Test"};
        //    var entryImage = new Image
        //    {
        //        HeightRequest = 31,
        //        WidthRequest = 28.5
        //    };
        //    var entryLine = new StackLayout
        //    {
        //        HeightRequest = 1,
        //        HorizontalOptions = LayoutOptions.FillAndExpand,
        //        VerticalOptions = LayoutOptions.EndAndExpand
        //    };

        //    var entryLayout = new StackLayout
        //    {
        //        Padding = new Thickness(28, 0, 35, 15),
        //        Children =
        //        {
        //            new StackLayout()
        //            {
        //                Padding = new Thickness(0,0,0,12),
        //                Orientation = StackOrientation.Horizontal,
        //                Children =
        //                {
        //                    new StackLayout {
        //                        Padding = new Thickness(17,0,0,0),
        //                        Children = {
        //                            entryImage
        //                        }
        //                    },
        //                    entryExtension
        //                }
        //            },
        //            entryLine
        //        }
        //    };
        //}
    }
}
