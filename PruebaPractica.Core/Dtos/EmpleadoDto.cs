using System;

namespace PruebaPractica.Core.Dtos
{
    public partial class EmpleadoDto
    {

        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public int IdTipodoCumento { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Valoraganar { get; set; }

        public int IdEstadoCivil { get; set; }

    }

    public partial class EmpleadoDtoApi
    {

        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public string TipodoCumento { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Valoraganar { get; set; }

        public string EstadoCivil { get; set; }

    }
}
