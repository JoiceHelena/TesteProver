using Ninject;
using TesteProverRepositorio;
using TesteProverRepositorio.Repositorio;
using TesteProverService.Interface;

namespace TesteProverService
{
    public static class IocConfig
    {
        public static void ConfigureDependencies(IKernel kernel)
        {
            kernel.Bind<IContatoRepository>().To<ContatoRepository>();
            kernel.Bind<IUnitofWork>().To<UnitofWork>();
            kernel.Bind<ILoginRepository>().To<LoginRepository>();
            kernel.Bind<ICargoRepository>().To<CargoRepository>();
        }
    }
}
