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
        private readonly HashSet<string> filterList;
        List<string> bookmarkLinks = new List<string>();
        public MainWindow()
        {
            Init();
            string easyList = File.ReadAllText("easylist.txt");
            filterList = new HashSet<string>(easyList.Split('\n'), StringComparer.OrdinalIgnoreCase);
        }
        public void Init()
        {
            var settings = new CefSettings();
            Cef.Initialize(settings);
            Console.WriteLine("Deeznutsickles");
           // BookMarkControl.MouseLeftButtonUp += null;
            
        }

        void GenerateNewBookmark(string name)
        {
            Button button = new Button();

            button.Height = 80;

            button.Width = 150;

            button.Content = "Click ME";
        }


        private void BookMarkControl_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Added Bookmark");
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Browser.Load(SearchBox.Text);
            try
            {
                Browser.Load($"https://www.google.com/search?q={SearchBox.Text}");
            }
            catch
            {

            }
            //Browser.Find(SearchBox.Text, true, false, false);
            //OnBeforeResourceLoad(Browser.RequestHandler, Browser.cal);
        }

        private void AddBookmarkButton_Click(object sender, RoutedEventArgs e)
        {
            bookmarkLinks.Add(Browser.Address);
            GenerateNewBookmark(Browser.Address);

        }
    }
}
