using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Cuentum
    {
        public Cuentum()
        {
            Transaccions = new HashSet<Transaccion>();
            Usuarios = new HashSet<Usuario>();
        }

        public decimal IdCuenta { get; set; }
        public decimal? NumeroCuenta { get; set; }
        public decimal? Saldo { get; set; }

        public virtual ICollection<Transaccion> Transaccions { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
