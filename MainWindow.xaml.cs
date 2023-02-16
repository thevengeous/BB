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
            
        }

        //this shit is not functional
        public bool OnBeforeResourceLoad(IRequest request, IRequestCallback callback)
        {
            // Check if the request URL matches any of the filter rules
            if (filterList.Any(filter => request.Url.Contains(filter)))
            {
                // Cancel the request
                callback.Dispose();
                Console.WriteLine("Supposed adblocking");
                return true;
            }
            return false;
        }

        void CheckForAd()
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Browser.Load(SearchBox.Text);
            //OnBeforeResourceLoad(Browser.RequestHandler, Browser.cal);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
