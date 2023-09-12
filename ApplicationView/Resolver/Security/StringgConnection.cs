using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.Resolver.Security
{
    public static class StringgConnection
    {
        public static  String GetString()
        {
            var builder = new ConfigurationBuilder()
                 .AddJsonFile("appsetting.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            var logFile = configuration["ConnectionStrings:DefaultConnection"];
            return logFile;
        }

        public static String GetPrint()
        {
            var builder = new ConfigurationBuilder()
                 .AddJsonFile("appsetting.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            var logFile = configuration["print:name"];
            return logFile;
        }
    }
}
