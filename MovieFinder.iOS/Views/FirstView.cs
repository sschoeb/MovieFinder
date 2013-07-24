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
    public class FirstView : MvxCollectionViewController
    {
        protected FirstView() : base("FirstView", null)
        {
        }

        public override void ViewDidLoad()
        {
            var tableView = new UITableView(new RectangleF(60, 10, 300, 400));
            Add(tableView);

            var editView = new UITextView(new RectangleF(10, 10, 200, 30));
            Add(editView);

            var searchButton = new UIButton(new RectangleF(220, 10, 80, 30));
            searchButton.SetTitle("Search", UIControlState.Normal);
            Add(searchButton);

            var source = new MvxStandardTableViewSource(tableView, "TitleText title;");

            var bindingSet = this.CreateBindingSet<FirstView, FirstViewModel>();
            bindingSet.Bind(tableView).To(viewModel => viewModel.Movies);
            bindingSet.Bind(editView).To(viewModel => viewModel.Keyword);
            bindingSet.Bind(searchButton).To(viewModel => viewModel.SearchCommand);
            bindingSet.Bind(source).For(x => x.SelectionChangedCommand).To(viewModel => viewModel.ShowDetailCommand);
            bindingSet.Apply();

            tableView.Source = source;
            tableView.ReloadData();
        }
    }
}