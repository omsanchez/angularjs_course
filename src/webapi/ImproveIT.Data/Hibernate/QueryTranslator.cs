using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace ImproveIT.Data.Hibernate
{
    public class QueryTranslator
    {
        private ICriteria _criteria;
        private Query _query;

        public QueryTranslator(ICriteria criteria, Query query)
        {
            _criteria = criteria;
            _query = query;
        }

        public void Execute()
        {
            Query myQuery = this._query;
            foreach (ImproveIT.Data.Order clause in myQuery.Ordenamientos)
            {
                NHibernate.Criterion.Order ordenamiento = new NHibernate.Criterion.Order(clause.NombrePropiedad, clause.TipoOrdenamiento == OperationOrder.Ascending ? true : false);
                _criteria.AddOrder(ordenamiento);
            }
            Junction disjunction = Restrictions.Disjunction();
            foreach (ImproveIT.Data.Criteria myCriterion in myQuery.Criteria)
            {
                ICriterion criterion = null;
                if (myCriterion.Operador == CriteriaOperator.Equal)
                    criterion = Expression.Eq(myCriterion.NombrePropiedad, myCriterion.Valor);
                else if (myCriterion.Operador == CriteriaOperator.NotEqual)
                    criterion = Expression.Not(Expression.Eq(myCriterion.NombrePropiedad, myCriterion.Valor));
                else if (myCriterion.Operador == CriteriaOperator.GreaterThan)
                    criterion = Expression.Gt(myCriterion.NombrePropiedad, myCriterion.Valor);
                else if (myCriterion.Operador == CriteriaOperator.GreaterThanOrEqual)
                    criterion = Expression.Ge(myCriterion.NombrePropiedad, myCriterion.Valor);
                else if (myCriterion.Operador == CriteriaOperator.LesserThan)
                    criterion = Expression.Lt(myCriterion.NombrePropiedad, myCriterion.Valor);
                else if (myCriterion.Operador == CriteriaOperator.LesserThanOrEqual)
                    criterion = Expression.Le(myCriterion.NombrePropiedad, myCriterion.Valor);
                else if (myCriterion.Operador == CriteriaOperator.Like)
                    criterion = Expression.Like(myCriterion.NombrePropiedad, myCriterion.Valor);
                else if (myCriterion.Operador == CriteriaOperator.NotLike)
                    criterion = Expression.Not(Expression.Like(myCriterion.NombrePropiedad, myCriterion.Valor));
                else if (myCriterion.Operador == CriteriaOperator.IsNull)
                    criterion = Expression.IsNull(myCriterion.NombrePropiedad);
                else if (myCriterion.Operador == CriteriaOperator.IsNotNull)
                    criterion = Expression.IsNotNull(myCriterion.NombrePropiedad);
                else
                    throw new ArgumentException("operator", "CriteriaOperator not supported in NHibernate Provider");
                if (_query.Operador == QueryOperator.And)
                    _criteria.Add(Expression.Conjunction().Add(criterion));
                else if (_query.Operador == QueryOperator.Or)
                {  
                    _criteria.Add(disjunction.Add(Restrictions.Eq(myCriterion.NombrePropiedad, myCriterion.Valor)));
                }
                    
            }
        }
    }
}
