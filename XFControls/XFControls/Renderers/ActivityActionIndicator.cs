using Xamarin.Forms;

namespace XFControls.Renderers
{
    public class ActivityActionIndicator : View
    {
        public static readonly BindableProperty IconProperty = BindableProperty.Create(
    propertyName: "Icon",
    returnType: typeof(string),
    declaringType: typeof(ActivityActionIndicator));

        public string Icon {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly BindableProperty IsRunningProperty = BindableProperty.Create(
    propertyName: "IsRunning",
    returnType: typeof(bool),
    declaringType: typeof(ActivityActionIndicator), defaultValue: false);

        public bool IsRunning {
            get { return (bool)GetValue(IsRunningProperty); }
            set { SetValue(IsRunningProperty, value); }
        }


    }
}
