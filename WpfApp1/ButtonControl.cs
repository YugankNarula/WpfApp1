using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class ButtonControl : Button
    {
        public static readonly DependencyProperty SetTextProperty =
         DependencyProperty.Register("SetText", typeof(string), typeof(ButtonControl), new
            PropertyMetadata("", new PropertyChangedCallback(OnSetTextChanged)));


        public string SetText
        {
            get { return (string)GetValue(SetTextProperty); }
            set { SetValue(SetTextProperty, value); }
        }

        private static void OnSetTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ButtonControl UserControl1Control = d as ButtonControl;
            UserControl1Control.OnSetTextChanged(e);
        }

        private void OnSetTextChanged(DependencyPropertyChangedEventArgs e)
        {
            this.ToolTip = e.NewValue.ToString();
        }
    }
}
