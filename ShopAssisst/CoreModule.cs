using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Web.Http;
using Autofac;
using ShopAssist2.Business.Services;
using ShopAssist2.Common.Persistence;
using Module = Autofac.Module;
using ShopAssist2.Business.Interfaces;

namespace ShopAssist2 {
    public class DataModule :Module {


        public DataModule() {

        }

        protected override void Load( ContainerBuilder builder )
        {

            builder.RegisterType<ShopAssist2Context>().InstancePerRequest();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
            //builder.Register( c => new UserService() ).As<IUserService>().InstancePerRequest();

            builder.RegisterInstance(AutoMapperConfig.GetMapper());

            base.Load( builder );
        }
    }
}