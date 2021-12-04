using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaPractica.Core
{
    public partial class Documento
    {
        public Documento()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
