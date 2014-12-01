using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImproveIT.Data
{
    public sealed class Query
    {
        public IList<Criteria> Criteria { get; set; }
        public QueryOperator Operador { get; set; }
        public IList<Order> Ordenamientos { get; set; }
        public QueryComponentList Component { get; set; }
        public Query()
        {
            this.Criteria = new List<Criteria>();
            this.Ordenamientos = new List<Order>();
        }
    }

    public enum QueryOperator
    {
        And = 0,
        Or = 1,
    }

    public enum QueryComponentList
    {
        Default = 0,
        True = 1,
        False = 2
    }
}
