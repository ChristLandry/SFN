using SFN_FRONT.Core.BLL;
using SFN_FRONT.Core.Service;

namespace SFN_FRONT.Core.DI
{
    public static class InjectDepend_Front
    {
        public static void InjectionDependency(this IServiceCollection services)
        {
            services.AddTransient<IFrontService, FrontService>();

            services.AddTransient<IAPILinkBll, APILinkBll>();
            services.AddTransient<ICompteBll, CompteBll>();
            services.AddTransient<IAuditBll, AuditBll>();
        }
    }
}
