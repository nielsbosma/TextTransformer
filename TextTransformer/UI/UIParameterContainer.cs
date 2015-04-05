using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TextTransformer.Transformers;

namespace TextTransformer.UI
{
    public class UIParameterContainer : StackPanel
    {

        public static readonly DependencyProperty SelectedTransformerProperty;

        static UIParameterContainer()
        {
            SelectedTransformerProperty = DependencyProperty.Register("SelectedTransformer", typeof(ITransformer),
               typeof(UIParameterContainer), new UIPropertyMetadata(null));

            DefaultStyleKeyProperty.OverrideMetadata(typeof(UIParameterContainer), new FrameworkPropertyMetadata(typeof(UIParameterContainer)));
        }

        public ITransformer SelectedTransformer
        {
            get { return (ITransformer)GetValue(SelectedTransformerProperty); }
            set
            {
                SetValue(SelectedTransformerProperty, value);
                _Update();
            }
        }

        private void _Update()
        {
            this.Children.Clear();
            if (SelectedTransformer == null) return;
            this.Children.Add(new Label() {Content = SelectedTransformer.Name});
        }

    }
}
