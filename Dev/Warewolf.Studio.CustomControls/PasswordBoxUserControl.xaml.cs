﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Warewolf.Studio.CustomControls
{
    public partial class PasswordBoxUserControl : UserControl
    {
        public PasswordBoxUserControl()
        {
            InitializeComponent();
            imgShowHide.Source = new BitmapImage(new Uri("Images/Show.jpg", UriKind.Relative));
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(PasswordBoxUserControl),
                new PropertyMetadata(string.Empty, OnTextPropertyChanged));

        static void OnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var source = d as PasswordBoxUserControl;
            source.Text = (string) e.NewValue;
        }

        public string Text
        {
            get => GetValue(TextProperty) as string;
            set => SetValue(TextProperty, value);
        }

        public void SetText(string value = null)
        {
            if(txtVisiblePassword.Visibility == Visibility.Hidden)
            {
                txtVisiblePassword.Text = value ?? txtPassword.Password;
            }
            else
            {
                txtPassword.Password = value ?? txtVisiblePassword.Text;
            }
        }

        private void ShowPassword()
        {
            imgShowHide.Source = new BitmapImage(new Uri("Images/Hide.jpg", UriKind.Relative));
            txtVisiblePassword.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Hidden;
            txtVisiblePassword.Text = txtPassword.Password;
        }

        private void HidePassword()
        {
            imgShowHide.Source = new BitmapImage(new Uri("Images/Show.jpg", UriKind.Relative));
            txtVisiblePassword.Visibility = Visibility.Hidden;
            txtPassword.Visibility = Visibility.Visible;
            txtPassword.Password = txtVisiblePassword.Text;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if(txtVisiblePassword.Visibility == Visibility.Hidden)
                ShowPassword();
            else
                HidePassword();
        }

        private void TxtPassword_OnLostFocus(object sender, RoutedEventArgs e)
        {
            var value = "";
            if (sender.GetType() == typeof(PasswordBox))
            {
                value = ((PasswordBox) sender).Password;
            }
            else
            {
                value = ((AutoCompleteBox) sender).Text;
            }

            SetValue(TextProperty, value);
        }
    }
}