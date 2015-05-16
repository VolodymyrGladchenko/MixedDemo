using Ninject.Extensions.Conventions;
using Ninject.Modules;
using RedisRepository.RedisApi;

namespace RedisRepository
{
    internal class RedisRepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x => x.FromThisAssembly().SelectAllClasses().BindSingleInterface());
            Kernel.Rebind<IRedisClientFactory>().To<RedisClientFactory>().InSingletonScope();
        }
    }
}