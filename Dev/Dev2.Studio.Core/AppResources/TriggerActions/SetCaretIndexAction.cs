#pragma warning disable
/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;


namespace Dev2.Studio.Core.AppResources.TriggerActions
{
    [ExcludeFromCodeCoverage]
    public class SetCaretIndexAction : TriggerAction<TextBox>
    {
        public int IndexPosition
        {
            get { return (int)GetValue(IndexPositionProperty); }
            set { SetValue(IndexPositionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IndexPosition.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IndexPositionProperty =
            DependencyProperty.Register("IndexPosition", typeof(int), typeof(SetCaretIndexAction), new PropertyMetadata(0));

        protected override void Invoke(object parameter)
        {
            AssociatedObject.CaretIndex = IndexPosition;
            AssociatedObject.Focus();
        }
    }
}
