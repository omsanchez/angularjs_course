using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using System.Reflection;

namespace ImproveIT.Data.Hibernate
{
    public class XmlSessionFactory
    {

        private Configuration configuration;

        public ISession GetSession()
        {
            return this.CreateSesionFactory().OpenSession();
        }

        internal ISessionFactory CreateSesionFactory()
        {
            configuration = new Configuration();
            configuration.Configure()
            .AddAssembly(Assembly.GetCallingAssembly());
            return configuration.BuildSessionFactory();
        }
    }
}
