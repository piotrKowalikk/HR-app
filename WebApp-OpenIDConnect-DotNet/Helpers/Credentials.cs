using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_OpenIDConnect_DotNet.Helpers
{
    public class Credentials
    {
        public AzureAdB2COptions AzureAdB2COptions { get; set; }

        public Credentials(IOptions<AzureAdB2COptions> b2cOptions)
        {
            AzureAdB2COptions = b2cOptions.Value;
        }

    }
}
