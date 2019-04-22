using ApiLTMTest.Application.Service;
using ApiLTMTest.Application.Service.Interfaces;
using ApiLTMTest.Domain.Context;
using ApiLTMTest.Domain.Entities;
using ApiLTMTest.Domain.Repositories;
using ApiLTMTest.Domain.Repositories.Interfaces;
using SimpleInjector;

namespace ApiLTMTest.Services.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            #region "Context"

            container.Register<ApiLTMTestContext>(Lifestyle.Scoped);

            #endregion

            #region Inject Services

            container.Register<IUserService, UserService>(Lifestyle.Scoped);
            container.Register<IFileService, FileService>(Lifestyle.Scoped);
            #endregion

            #region Inject Repositories

            container.Register<IRepository<User>, Repository<User>>(Lifestyle.Scoped);
            container.Register<IRepository<FileUpload>, Repository<FileUpload>>(Lifestyle.Scoped);

            #endregion

        }
    }
}
