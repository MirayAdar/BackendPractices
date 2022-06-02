using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise.Core.Utilities.IoC
{
    // startuptaki service.providera erişmeye çalışıyoruz
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider {get; set;}

        public static IServiceCollection Create(IServiceCollection service)
        {
            ServiceProvider = service.BuildServiceProvider();
        }
    }
}
