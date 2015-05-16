using Ninject.Modules;
using Ninject.Extensions.Conventions;

namespace EntityBackend
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x =>
                x.FromThisAssembly()
                    .SelectAllClasses()
                    .BindAllInterfaces());
        }
    }
}