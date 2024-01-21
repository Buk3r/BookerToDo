using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Views;
using Xamarin.Forms;
using BookerToDo.Views;
using Android.Widget;

namespace BookerToDo.Droid
{
    [Activity(Label = "BookerToDo", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            var toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            bool result;

            if (item.ItemId == Android.Resource.Id.Home)
            {
                if (App.Current.MainPage is NavigationPage navPage
                    && navPage.CurrentPage is AddEditTaskPage page
                    && page.NavBarBackButtonPressedAction != null)
                {
                    page.NavBarBackButtonPressedAction.Invoke();
                    result = false;
                }
                else
                {
                    result = base.OnOptionsItemSelected(item);
                }

            }
            else
            {
                result = base.OnOptionsItemSelected(item);
            }

            return result;
        }

        
    }
}