using Autofac;
using LIBs.Repository;
using LIBs.Repository.IRepositoy;
using LIBs.Service;
using LIBs.Service.IService;

namespace LIBs.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Repositorys

            builder.RegisterType<RepositoryVenda>().As<IRepositoryVenda>();
            builder.RegisterType<RepositoryVendedor>().As<IRepositoryVendedor>();

            #endregion

            #region Services

            builder.RegisterType<ServiceVenda>().As<IServiceVenda>();
            builder.RegisterType<ServiceVendedor>().As<IServiceVendedor>();

            #endregion

        }
    }
}
