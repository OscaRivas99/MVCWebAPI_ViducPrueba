using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Transaccion
    {
        public decimal IdTrans { get; set; }
        public string? Tipo { get; set; }
        public decimal? IdCuenta { get; set; }
        public decimal? Monto { get; set; }
        public string? Fecha { get; set; }

        public virtual Cuentum? IdCuentaNavigation { get; set; }
    }
}
