using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CautaRetete.Components
{
    public sealed partial class NavigationBar : UserControl
    {
        public NavigationBar(int activeButton)
        {
            this.InitializeComponent();
            ActiveID = activeButton;
        }


        private void ClearVisibility()
        {
            home.Visibility = Visibility.Collapsed;
            search.Visibility = Visibility.Collapsed;
            settings.Visibility = Visibility.Collapsed;
        }

        public int ActiveID
        {
            get { return (int)GetValue(ActiveIDProperty); }
            set { SetValue(ActiveIDProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ActiveID.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActiveIDProperty =
            DependencyProperty.Register("ActiveID", typeof(int), typeof(int), new PropertyMetadata(0));

    }
}
