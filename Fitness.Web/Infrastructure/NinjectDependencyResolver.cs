using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fitness.AdoNet.Repositories;
using Fitness.Business.Services;
using Ninject;
using Ninject.Web.Common;

namespace Fitness.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IAbonementIncomeService>().To<AbonementIncomeService>();
            kernel.Bind<IChargeService>().To<ChargeService>();
            kernel.Bind<IAbonementIncomeRepository>().To<AbonementIncomeRepository>();
            kernel.Bind<IChargeRepository>().To<ChargeRepository>();
            kernel.Bind<IConnectionRepository>().To<ConnectionRepository>();
        }
    }
}