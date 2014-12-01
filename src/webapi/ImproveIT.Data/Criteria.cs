using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImproveIT.Data
{
    public class Criteria
    {
        public string NombrePropiedad { get; set; }
        public CriteriaOperator Operador { get; set; }
        public object Valor { get; set; }

        public Criteria()
        { 
        }

        public Criteria(string nombrePropiedad, object valorPropiedad, CriteriaOperator operador)
        {
            this.NombrePropiedad = nombrePropiedad;
            this.Operador = operador;
            this.Valor = valorPropiedad;
        }
    }

    public enum CriteriaOperator
    {
        Equal = 0,
        NotEqual = 1,
        GreaterThan = 2,
        LesserThan = 3,
        GreaterThanOrEqual = 4,
        LesserThanOrEqual = 5,
        Like = 6,
        NotLike = 7,
        IsNull = 8,
        IsNotNull = 9,
        In = 10,
        ObjectType = 11
    }

}
