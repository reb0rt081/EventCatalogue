using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web;

namespace EventCatalogue.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApiApplication webApi = new WebApiApplication();
            webApi.Start();
        }
    }
}
