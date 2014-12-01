using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImproveIT.Data
{
    public class Order
    {
        public string NombrePropiedad { get; set; }
        public OperationOrder TipoOrdenamiento { get; set; }
        
        public Order()
        { }

        public Order(string nombrePropiedad, OperationOrder tipoOrdenamiento)
        {
            this.NombrePropiedad = nombrePropiedad;
            this.TipoOrdenamiento = tipoOrdenamiento;
        }
    }

    public enum OperationOrder
    {
        Ascending = 0,
        Descending = 1,
    }

}
