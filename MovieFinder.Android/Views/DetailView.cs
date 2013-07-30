using Android.App;
using Cirrious.MvvmCross.Droid.Views;

namespace MovieFinder.Android.Views
{
    [Activity(Label = "DetailView")]
    public class DetailView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.DetailView);
        }
    }
}