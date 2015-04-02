﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using TextTransformer.MVVM;
using TextTransformer.Transformers;

namespace TextTransformer.ViewModels
{
    public class TransformViewModel : ViewModelBase
    {

        public TransformViewModel(TransformerCollection transformers) : base()
        {
            this.Transformers = transformers;
        }

        public TransformViewModel()
        {
    
        }

        public void Transform()
        {
            try
            {
                ITransformer transformer = Transformers[SelectedTransformer];
                Output = transformer.Transform(Input);
            }
            catch (Exception ex)
            {
                Output = ex.Message;
            }
        }

        private void _CopyToClipboard(object _)
        {
            try
            {
                Clipboard.SetText(this.Output);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to copy to clipboard.");
            }
        }

        ////////////////////////////////////////////////////

        public ICommand CopyToClipboard {
            get
            {
                return new DelegateCommand(_CopyToClipboard);
            }
        }

        public TransformerCollection Transformers { get; set; }

        public int SelectedTransformer
        {
            get { return _selectedTransformer; }
            set
            {
                if (_selectedTransformer != value)
                {
                    _selectedTransformer = value;
                    RaisePropertyChanged("SelectedTransformer");
                    Transform();
                }
            }
        }

        public string Input
        {
            get { return _input; }
            set
            {
                if (_input != value)
                {
                    _input = value;
                    RaisePropertyChanged("Input");
                    Transform();
                }
            }
        }

        public string Output
        {
            get { return _output; }
            set
            {
                if (_output != value)
                {
                    _output = value;
                    RaisePropertyChanged("Output");
                }
            }
        }

        private string _input;
        private string _output;
        private int _selectedTransformer;
        private Visibility _visibility = Visibility.Hidden;
    }
}
