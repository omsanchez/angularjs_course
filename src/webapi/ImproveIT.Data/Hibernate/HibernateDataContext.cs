using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace ImproveIT.Data.Hibernate
{

    /// <summary>
    /// Datacontext implemented with NHibernate
    /// </summary>
    public class HibernateDataContext : IDataContext
    {

        internal ISessionFactory SessionFactory { get; set; }

        internal ISession Session 
        {
            get { return SessionFactory.GetCurrentSession(); }
        }

        internal ITransaction _transaccion;

        public bool IsInTransaction
        {
            get
            {
                if (this.Session.Transaction == null) return false;
                return this.Session.Transaction.IsActive;
            }
        }

        public void BeginTransaction()
        {
            if (this.IsInTransaction)
            {
                StringBuilder mensajeError = new StringBuilder();
                mensajeError.Append("Se ha generado un error al iniciar la transacción. Existe una transacción activa actualmente");
                throw new System.InvalidOperationException(mensajeError.ToString());
            }
            try
            {
                this._transaccion = this.Session.BeginTransaction();
            }
            catch (Exception ex)
            {
                StringBuilder mensajeError = new StringBuilder();
                mensajeError.Append("Se ha generado un error al iniciar la transacción.");
                mensajeError.Append("\nError Interno: " + ex.Message);
                throw new TransactionException(mensajeError.ToString());
            }
        }

        public void Commit()
        {
            if (!this.IsInTransaction)
            {
                StringBuilder mensajeError = new StringBuilder();
                mensajeError.Append("Se ha generado un error al cometer una transacción. No hay transacción activa");
                throw new System.InvalidOperationException(mensajeError.ToString());
            }
            try
            {
                this._transaccion.Commit();
                this._transaccion.Dispose();
            }
            catch (Exception ex)
            {
                StringBuilder mensajeError = new StringBuilder();
                mensajeError.Append("Se ha generado un error al cometer una transacción.");
                mensajeError.Append("\nError interno: " + ex.Message);
                throw new TransactionException(mensajeError.ToString());
            }
        }

        public void RollBack()
        {
            if (!this.IsInTransaction)
            {
                StringBuilder mensajeError = new StringBuilder();
                mensajeError.Append("Se ha generado un error al deshacer una transacción. No hay transacción activa");
                throw new System.InvalidOperationException(mensajeError.ToString());
            }
            try
            {
                this._transaccion.Rollback();
                this._transaccion.Dispose();
                this.Session.Close();
            }
            catch (Exception)
            {
                StringBuilder mensajeError = new StringBuilder();
                mensajeError.Append("Se ha generado un error al deshacer una transacción. No hay transacción activa");
                throw new TransactionException(mensajeError.ToString());
            }
        }

        public IList<T> GetAll<T>() where T : class, new()
        {
            ICriteria criteria = Session.CreateCriteria(typeof(T));
            return criteria.List<T>();
        }

        public IList<T> GetByCriteria<T>(Query query) where T : class, new()
        {
            ICriteria criteria = this.Session.CreateCriteria(typeof(T));
            QueryTranslator traslator = new QueryTranslator(criteria, query);
            traslator.Execute();
            return criteria.List<T>();
        }

        public T GetById<T>(object id) where T : class, new()
        {
            return this.Session.Get<T>(id);
        }

        public int GetCount<T>()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetCount<T>(Query query)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Add(object item)
        {
            this.Session.Save(item);
            if (!this.IsInTransaction)
                this.Session.Flush();
        }

        public void Add<T>(T item)
        {
            this.Session.Save(item);
            if (!this.IsInTransaction)
                this.Session.Flush();
        }

        public void Delete(object item)
        {
            this.Session.Delete(item);
            if (!this.IsInTransaction)
                this.Session.Flush();
        }

        public void Delete<T>(T item)
        {
            this.Session.Delete(item);
            if (!this.IsInTransaction)
                this.Session.Flush();
        }

        public void Save(object item)
        {
            this.Session.Update(item);
            if (!this.IsInTransaction)
            {
                this.Session.Flush();
                this.Session.Evict(item);
            }
        }

        public void Save<T>(T item)
        {
            this.Session.Update(item);
            if (!this.IsInTransaction)
            {
                this.Session.Flush();
                this.Session.Evict(item);
            }
        }

        public void Dispose()
        {
            try
            {
                this.Session.Dispose();
            }
            finally
            {
            }
        }

        public IList<T> GetByObject<T>(Query query) where T : class, new()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public HibernateDataContext()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="session"></param>
        public HibernateDataContext(ISessionFactory sessionFactory)
        {
            this.SessionFactory = sessionFactory;
        }
    }
}
