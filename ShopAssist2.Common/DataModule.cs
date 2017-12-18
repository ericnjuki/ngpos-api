using System.Runtime.Remoting.Contexts;
using Autofac;
using ShopAssist2.Common.Persistence;

namespace ShopAssist2.Common
{
    public class DataModule : Module
    {
        private string _connStr;

        public DataModule(string connStr)
        {
            _connStr = connStr;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ShopAssist2Context()).As<Context>().InstancePerRequest();

            base.Load(builder);
        }
    }
}