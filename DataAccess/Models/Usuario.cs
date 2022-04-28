using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Usuario
    {
        public decimal IdUser { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public decimal? IdCuenta { get; set; }
        public string? Pass { get; set; }
        public string? Token { get; set; }

        public virtual Cuentum? IdCuentaNavigation { get; set; }
    }
}
