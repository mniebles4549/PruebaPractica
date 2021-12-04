using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaPractica.Core.Interfaces
{
    public interface IEmpleadoEntidad
    {
        Task<IEnumerable<Empleado>> ListaDeTodosLosEmpleados();

        Task<bool> GuardarEmpleado(Empleado entidad);

        Task<bool> SaveChangesAsync();


    }

}
