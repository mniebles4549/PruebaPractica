using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PruebaPractica.Core
{
    public partial class Empleado
    {
        public int Id { get; set; }

        [StringLength(100)]
        [RegularExpression(@"^(?:.*[a-z]){6,}$", ErrorMessage = "La longitud de la cadena debe ser mayor o igual a 6 caracteres y no pueden ir números.")]
        [Required(ErrorMessage = "Los Nombres Son Requerido")]
        public string Nombres { get; set; }

        [StringLength(100)]
        [RegularExpression(@"^(?:.*[a-z]){6,}$", ErrorMessage = "La longitud de la cadena debe ser mayor o igual a 6 caracteres y no pueden ir números.")]
        [Required(ErrorMessage = "Los Apellidos Son Requerido")]
        public string Apellidos { get; set; }

        [Display(Name = "Tipo De Documento")]
        public int Idtipodocumento { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        [Required(ErrorMessage = "La Fecha Nacimiento Es Requerida")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fechanacimiento { get; set; }

        [Display(Name = "Valor Aganar")]
        [Required(ErrorMessage = "El Valor Aganar Es Requerido")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public string Valoraganar { get; set; }

        public int Idestadocivil { get; set; }

        [Display(Name = "Estado Civil")]

        public virtual Estadocivil IdestadocivilNavigation { get; set; }

        [Display(Name = "Tipo De Documento")]
        public virtual Documento IdtipodocumentoNavigation { get; set; }


        public IEnumerable<ListEstado> ListEstado { get; set; }
    }


    public partial class EmpleadoDto
    {
        public int Id { get; set; }

         public string Nombres { get; set; }
  public string Apellidos { get; set; }

        public int Idtipodocumento { get; set; }

        public DateTime Fechanacimiento { get; set; }

         public string Valoraganar { get; set; }

        public int Idestadocivil { get; set; }

         public virtual Estadocivil IdestadocivilNavigation { get; set; }

         public virtual Documento IdtipodocumentoNavigation { get; set; }


        public IEnumerable<ListEstado> ListEstado { get; set; }
    }

    public class ListEstado
    {
        public int Id { get; set; }

        public int IdEstado { get; set; }
        public string NameEstado { get; set; }
       // public bool check { get; set; }

    }
}
