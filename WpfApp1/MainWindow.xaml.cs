using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HttpClient _httpClient = new HttpClient();
            SyncButton.Click += (o, e) =>
                {
                    // This line will yield control to the UI as the request
                    // from the web service is happening.
                    //
                    // The UI thread is now free to perform other work.
                    //Task.Run(() => {
                        var stringData = _httpClient.GetStringAsync(new Uri("https://dotnettutorials.net"));
                        Textblck1.Text = "Sync-" + stringData.Result.Substring(0, 10);
                    //});
                    
                };

            EmploeeVM vm = new EmploeeVM();
            this.DataContext = vm;
        }

        private async void AsyncButton_Click(object sender, RoutedEventArgs e)
        {
            HttpClient _httpClient = new HttpClient();
            var stringData = await _httpClient.GetStringAsync(new Uri("https://dotnettutorials.net"));
            Textblck1.Text = "Async-"+stringData.Substring(0, 10);
        }
    }
}
