using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System.Configuration;

namespace ImproveIT.AngularJSCourse.Data
{
    /// <summary>
    /// Creates NHibernate objects
    /// </summary>
    public class DataContextBuilder
    {

        /// <summary>
        /// Create the NHibernate Session Factory
        /// </summary>
        /// <returns></returns>
        public static ISessionFactory BuildNHibernateSessionFactory(string currentSessionContext)
        {
            var cnn = ConfigurationManager.ConnectionStrings["taskdb"];
            if (cnn == null)
                throw new Exception("No se encontró los datos de conexión a la base de datos de Imbera Sip en el archivo de configuración de la app. Verifique que existe en el archivo app.config o web.config, o el archivo que esté usando para configurar la aplicación");
            var cnnString = cnn.ConnectionString;
            ISessionFactory factory = Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012
                        .ConnectionString(cnnString)
                )
                .Mappings(m =>
                {
                    //m.FluentMappings.AddFromAssemblyOf<CompanyMapper>();
                })
                .ExposeConfiguration(
                    x => x.SetProperty("current_session_context_class", currentSessionContext)
                )
                .BuildSessionFactory();
            return factory;
        }
    }
}

