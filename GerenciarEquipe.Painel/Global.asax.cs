using GerenciarEquipe.Application;
using GerenciarEquipe.Application.Interfaces;
using GerenciarEquipe.Domain.Interfaces.Repositories;
using GerenciarEquipe.Domain.Interfaces.Services;
using GerenciarEquipe.Domain.Services;
using GerenciarEquipe.Infra.Data.Repositories;
using GerenciarEquipe.Painel.AutoMapper;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GerenciarEquipe.Painel
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            container.Register(typeof(IAppServiceBase<>), typeof(AppServiceBase<>), Lifestyle.Scoped);
            container.Register<IAdminAppService, AdminAppService>(Lifestyle.Scoped);
            container.Register<IAmbitoAppService, AmbitoAppService>(Lifestyle.Scoped);
            container.Register<ICargoAppService, CargoAppService>(Lifestyle.Scoped);
            container.Register<IFuncionarioAppService, FuncionarioAppService>(Lifestyle.Scoped);
            container.Register<IIndicadorAppService, IndicadorAppService>(Lifestyle.Scoped);
            container.Register<IInquiridoAppService, InquiridoAppService>(Lifestyle.Scoped);
            container.Register<ILojaAppService, LojaAppService>(Lifestyle.Scoped);
            container.Register<IMetaAppService, MetaAppService>(Lifestyle.Scoped);
            container.Register<IRankAppService, RankAppService>(Lifestyle.Scoped);
            container.Register<IRespostaAppService, RespostaAppService>(Lifestyle.Scoped);
            container.Register<IUsuarioAppService, UsuarioAppService>(Lifestyle.Scoped);
            
            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>), Lifestyle.Scoped);
            container.Register<IAdminService, AdminService>(Lifestyle.Scoped);
            container.Register<IAmbitoService, AmbitoService>(Lifestyle.Scoped);
            container.Register<ICargoService, CargoService>(Lifestyle.Scoped);
            container.Register<IFuncionarioService, FuncionarioService>(Lifestyle.Scoped);
            container.Register<IIndicadorService, IndicadorService>(Lifestyle.Scoped);
            container.Register<IInquiridoService, InquidoService>(Lifestyle.Scoped);
            container.Register<ILojaService, LojaService>(Lifestyle.Scoped);
            container.Register<IMetaService, MetaService>(Lifestyle.Scoped);
            container.Register<IRankService, RankService>(Lifestyle.Scoped);
            container.Register<IRespostaService, RespostaService>(Lifestyle.Scoped);
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);

            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>), Lifestyle.Scoped);
            container.Register<IAdminRepository, AdminRepository>(Lifestyle.Scoped);
            container.Register<IAmbitoRepository, AmbitoRepository>(Lifestyle.Scoped);
            container.Register<ICargoRepository, CargoRepository>(Lifestyle.Scoped);
            container.Register<IFuncionarioRepository, FuncionarioRepository>(Lifestyle.Scoped);
            container.Register<IIndicadorRepository, IndicadorRepository>(Lifestyle.Scoped);
            container.Register<IInquiridoRepository, InquiridoRepository>(Lifestyle.Scoped);
            container.Register<ILojaRepository, LojaRepository>(Lifestyle.Scoped);
            container.Register<IMetaRepository, MetaRepository>(Lifestyle.Scoped);
            container.Register<IRankRepository, RankRepository>(Lifestyle.Scoped);
            container.Register<IRespostaRepository, RespostaRepository>(Lifestyle.Scoped);
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();

            DependencyResolver.SetResolver(
            new SimpleInjectorDependencyResolver(container));

            // Here your usual Web API configuration stuff.
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMapping();
        }
    }
}
