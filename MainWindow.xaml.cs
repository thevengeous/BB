using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CefSharp;
using CefSharp.Wpf;
using System.IO;

namespace BB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Init();
            //AddBrowserTab();
        }
        public void Init()
        {
            var settings = new CefSettings();
            Cef.Initialize(settings);
            Console.WriteLine("Deeznutsickles");
            
        }


        private void BookMarkControl_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Added Bookmark");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Browser.Load($"https://www.google.com/search?q={SearchBox.Text}");
                MainAppWindow.Title = SearchBox.Text;
            }
            catch
            {

            }
            //Browser.Find(SearchBox.Text, true, false, false);
            //OnBeforeResourceLoad(Browser.RequestHandler, Browser.cal);
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FindBox.Text.Length <= 0)
            {
                //this will clear all search result
                Browser.StopFinding(true);
            }
            else
            {
                Browser.Find(FindBox.Text, true, false, false);
            }
        }

        private void BrowserTabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //AddBrowserTab();
        }

        void AddBrowserTab()
        {
            TabItem newTab = new TabItem
            {
                Header = $"Tab",
                Name = $"Tab"
            };
            //newTab.Content = BrowserTabs.;
            BrowserTabs.Items.Add(newTab);
            newTab.Content = new ChromiumWebBrowser();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddBrowserTab();
        }
    }
}
