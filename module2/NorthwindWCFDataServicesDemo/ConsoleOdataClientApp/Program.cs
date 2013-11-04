using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace ConsoleOdataClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            var result = client.GetAsync("http://localhost.fiddler:28510/NorthwindDataService.svc/Customers");
            
            Console.WriteLine("Press enter to exit.");
            Console.ReadKey();
        }
    }
}
