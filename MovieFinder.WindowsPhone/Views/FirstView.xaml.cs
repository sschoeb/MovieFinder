using System.Windows.Controls;
using System.Windows.Data;
using Cirrious.MvvmCross.WindowsPhone.Views;
using Microsoft.Phone.Controls;
using MovieFinder.Core.ViewModels;

namespace MovieFinder.WindowsPhone.Views
{
    public partial class FirstView : MvxPhonePage
    {
        public FirstView()
        {
            InitializeComponent();
        }

        private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            BindingExpression bindingExpr = textBox.GetBindingExpression(TextBox.TextProperty);
            bindingExpr.UpdateSource();
        }

        private void LongListSelector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && e.AddedItems[0] != null)
            {
                ((FirstViewModel)ViewModel).ShowDetailCommand.Execute(e.AddedItems[0]);
                ((LongListSelector)sender).SelectedItem = null;
            }
        }
    }
}