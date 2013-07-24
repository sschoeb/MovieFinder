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
            var textViewTitle = new UITextField(new RectangleF(10, 100, 300, 30));
            Add(textViewTitle);

            var textViewTitleValue = new UITextView(new RectangleF(40, 100, 300, 30));
            Add(textViewTitleValue);

            var textViewYear = new UITextField(new RectangleF(70, 100, 300, 30));
            Add(textViewYear);

            var textViewYearValue = new UITextView(new RectangleF(100, 100, 300, 30));
            Add(textViewYearValue);

            var textViewSynopsis = new UITextField(new RectangleF(130, 100, 300, 30));
            Add(textViewSynopsis);

            var textViewSynopsisValue = new UITextView(new RectangleF(160, 100, 300, 30));
            Add(textViewSynopsisValue);


            var bindingSet = this.CreateBindingSet<DetailView, DetailViewModel>();
            bindingSet.Bind(textViewTitleValue).To(vm => vm.Movie.title);
            bindingSet.Bind(textViewYearValue).To(vm => vm.Movie.year);
            bindingSet.Bind(textViewSynopsisValue).To(vm => vm.Movie.synopsis);
            bindingSet.Apply();
        }
    }
}
