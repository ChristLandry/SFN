using Microsoft.Extensions.Configuration;
using SFN_BLL.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFN_BLL.BLL
{
    public class FichierJsonBll: IFichierJsonBll
    {
        public IConfigurationRoot configuration;
        public FichierJsonBll()
        {
            var builder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "FichierJson.json");
            builder.AddJsonFile(path, optional: false);
            configuration = builder.Build();
        }
    }
}
