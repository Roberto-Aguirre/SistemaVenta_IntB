using System;
using System.Collections.Generic;

namespace SistemaVenta.Entity
{
    public partial class TipoDocumentoVentum
    {
        public TipoDocumentoVentum()
        {
            Venta = new HashSet<Ventum>();
        }

        public int IdTipoDocumentoVenta { get; set; }
        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
