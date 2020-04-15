using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class EmploeeVM
    {
        public string EmpName { get; set; }
        public string EmpDesignation { get; set; }
        public EmploeeVM()
        {
            EmpName = "yug";
            EmpDesignation = "developer";
            Task t =  new Task(MethodOne);
            ChangeProperties();
            t.Start();
        }

        private void ChangeProperties()
        {
            EmpName = "yugank";
            EmpDesignation = "UIdeveloper";
        }

        static async void MethodOne()
        {
            HttpClient _httpClient = new HttpClient();
            var stringData = await _httpClient.GetStringAsync(new Uri("https://www.google.com/"));  // same thread
            File.Create("D:\\abc.txt");
            File.AppendAllText("D:\\abc.txt", stringData);
        }

    }
}
