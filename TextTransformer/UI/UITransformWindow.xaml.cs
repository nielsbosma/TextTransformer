using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TextTransformer.ViewModels;

namespace TextTransformer.UI
{
    public partial class UITransformWindow : Window
    {

        public TransformViewModel ViewModel { get; set; }

        public UITransformWindow(TransformViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = ViewModel = viewModel;
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);

            var copyToClipboardCommand = new RoutedCommand();
            copyToClipboardCommand.InputGestures.Add( new KeyGesture( Key.C , ModifierKeys.Control ));
            this.CommandBindings.Add(new CommandBinding(copyToClipboardCommand, (o, e) => _CopyToClipboard()));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
         
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }

        private void BtnCopyToClipboard_Click(object sender, RoutedEventArgs e)
        {
            _CopyToClipboard();
        }

        private void BtnPaste_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CopyToClipboard.Execute(null);
            this.DialogResult = true;
            this.Close();
        }

        private void _CopyToClipboard()
        {
            ViewModel.CopyToClipboard.Execute(null);
            this.DialogResult = false;
            this.Close();
        }

 
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CboTransformers.Focus();
        }


    }
}
