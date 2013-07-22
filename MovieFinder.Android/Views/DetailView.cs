using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace MovieFinder.Android.Views
{
    [Activity(Label = "DetailView")]
    public class DetailView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.DetailView);
        }
    }
}