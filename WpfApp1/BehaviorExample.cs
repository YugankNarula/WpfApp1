﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace WpfApp1
{
    public static class DigitsOnlyBehavior

    {
        public static bool GetIsDigitOnly(DependencyObject obj)

        {

            return (bool)obj.GetValue(IsDigitOnlyProperty);
        }



        public static void SetIsDigitOnly(DependencyObject obj, bool value)

        {

            obj.SetValue(IsDigitOnlyProperty, value);
             
        }



        public static readonly DependencyProperty IsDigitOnlyProperty =

          DependencyProperty.RegisterAttached("IsDigitOnly",

          typeof(bool), typeof(DigitsOnlyBehavior),

          new PropertyMetadata(false, OnIsDigitOnlyChanged));



        private static void OnIsDigitOnlyChanged(object sender, DependencyPropertyChangedEventArgs e)

        {

            // ignoring error checking

            var textBox = (TextBox)sender;

            var isDigitOnly = (bool)(e.NewValue);



            if (isDigitOnly)

                textBox.PreviewTextInput += BlockNonDigitCharacters;

            else

                textBox.PreviewTextInput -= BlockNonDigitCharacters;

        }



        private static void BlockNonDigitCharacters(object sender, TextCompositionEventArgs e)

        {

            e.Handled = e.Text.Any(ch => !Char.IsDigit(ch));

        }

    }

}
