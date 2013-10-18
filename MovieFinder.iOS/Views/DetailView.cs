using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.UIKit;
using MovieFinder.Core.ViewModels;

namespace MovieFinder.iOS.Views
{
    public class DetailView : MvxViewController
    {
        public override void ViewDidLoad()
        {
			View = new UIView {BackgroundColor = UIColor.White};

            base.ViewDidLoad ();

			var textViewTitle = new UILabel(new RectangleF(10, 10, 300, 30));
			textViewTitle.Text = "Title";
            Add(textViewTitle);

			var textViewTitleValue = new UILabel(new RectangleF(10, 32, 300, 30));
            Add(textViewTitleValue);

			var textViewYear = new UILabel(new RectangleF(10, 80,300, 30));
			textViewYear.Text = "Year";
            Add(textViewYear);

			var textViewYearValue = new UILabel(new RectangleF(10, 112, 300, 30));
            Add(textViewYearValue);

            var textViewSynopsis = new UILabel(new RectangleF(10, 160, 300, 30));
			textViewSynopsis.Text = "Synopsis:";
            Add(textViewSynopsis);

			var textViewSynopsisValue = new UILabel(new RectangleF(10, 192, 300, 30));
            Add(textViewSynopsisValue);


            var bindingSet = this.CreateBindingSet<DetailView, DetailViewModel>();
            bindingSet.Bind(textViewTitleValue).To(vm => vm.Movie.title);
            bindingSet.Bind(textViewYearValue).To(vm => vm.Movie.year);
            bindingSet.Bind(textViewSynopsisValue).To(vm => vm.Movie.synopsis);
            bindingSet.Apply();
        }
    }
}
