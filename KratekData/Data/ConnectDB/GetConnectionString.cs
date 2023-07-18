using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KratekData.Data.ConnectDB
{
    internal class GetConnectionString
    {
        public string GetConnectionStrings(string connectionStringName)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json",
                                             optional: false,
                                             reloadOnChange: true);

            var configurationRoot = builder.Build();

            var connectionString = configurationRoot.GetConnectionString(connectionStringName);
            return connectionString;
        }
    }
}
