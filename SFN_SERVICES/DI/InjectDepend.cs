using Microsoft.Extensions.DependencyInjection;
using SFN_BLL.BLL;
using SFN_BLL.IBLL;
using SFN_DATA.DATA;
using SFN_DATA.IDATA;
using SFN_SERVICES.SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFN_SERVICES.DI
{
    public static class InjectDepend
    {
        public static void InjectionDependency(this IServiceCollection services)
        {

            //DI Services
            services.AddTransient<IService, Service>();

            //DI BLL
            services.AddTransient<IAuditBll, AuditBll>();
            services.AddTransient<ICompteBll, CompteBll>();
            services.AddTransient<ILogicielBll, LogicielBll>();
            services.AddTransient<ITokenBll, TokenBll>();
            services.AddTransient<IDecrypte, Decrypte>();
            services.AddTransient<IFichierJsonBll, FichierJsonBll>();

            //DATA
            services.AddTransient<IConnectionDB, ConnectionDB>();
            services.AddTransient<IAuditData, AuditData>();
            services.AddTransient<ICompteData, CompteData>();
            services.AddTransient<ILogicielData, LogicielData>();

        }
    }
}
