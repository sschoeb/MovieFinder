using System;
using System.Collections.Generic;
using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MovieFinder.Core.ViewModels;

namespace MovieFinder.iOS.Views
{


    [Register("FirstView")]
    public class FirstView : MvxViewController
    {
        
        public override void ViewDidLoad()
        {
			View = new UIView ();
			View.BackgroundColor = UIColor.White;
			NavigationItem.Title = "Search Movies";

			base.ViewDidLoad ();

			var editView = new UITextField();
			editView.Frame = new RectangleF (10, 10, 200, 30);
			editView.BorderStyle = UITextBorderStyle.RoundedRect;
			Add(editView);

            var searchButton = new UIButton(UIButtonType.RoundedRect);
			searchButton.Frame = new RectangleF (220, 10, 80, 30);
			searchButton.SetTitle("Search", UIControlState.Normal);
            Add(searchButton);



			var tableView = new UITableView(new RectangleF(10, 50, 300, 400));
			Add(tableView);

            var source = new MvxStandardTableViewSource(tableView, "TitleText title;");

            var bindingSet = this.CreateBindingSet<FirstView, FirstViewModel>();
            bindingSet.Bind(source).To(viewModel => viewModel.Movies);
            bindingSet.Bind(editView).To(viewModel => viewModel.Keyword);
            bindingSet.Bind(searchButton).To(viewModel => viewModel.SearchCommand);
            bindingSet.Bind(source).For(x => x.SelectionChangedCommand).To(viewModel => viewModel.ShowDetailCommand);
            bindingSet.Apply();

            tableView.Source = source;
            tableView.ReloadData();

			var responder = new UITapGestureRecognizer (() => {
				editView.ResignFirstResponder ();
			});
			responder.CancelsTouchesInView = false;
			View.AddGestureRecognizer(responder);
        }
    }
}