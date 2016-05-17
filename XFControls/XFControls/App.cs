using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFControls.Renderers;

namespace XFControls
{
    public class App : Application
    {
        public App()
        {
            var indeterminate = new Button { Text = "Indeterminate" };
            var activityAction = new ActivityActionIndicator {IsRunning = false, Icon = "spinner1.png"};
            indeterminate.Clicked += (sender, args) => activityAction.IsRunning = !activityAction.IsRunning;
            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                  
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new ImageEntry {
                         Text  = "From Binding",
                         Icon = "person.png"
                        }, activityAction,indeterminate
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
