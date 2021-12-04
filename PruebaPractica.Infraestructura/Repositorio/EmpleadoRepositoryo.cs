using Microsoft.EntityFrameworkCore;
using PruebaPractica.Core;
using PruebaPractica.Core.Interfaces;
using PruebaPractica.Persistencia.Datos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaPractica.Infraestructura.Repositorio
{
    public class EmpleadoRepositoryo : IEmpleadoEntidad
    {
        private readonly CrudApiContext _Context;
        protected readonly DbSet<Empleado> _Entity;

        public EmpleadoRepositoryo(CrudApiContext context)
        {
            _Context = context;
            _Entity = context.Set<Empleado>();
        }

        public async Task<IEnumerable<Empleado>> ListaDeTodosLosEmpleados()
        {
            try
            {
                var ListaEmpleados = await _Context.Empleados.AsNoTracking().Include(e => e.IdestadocivilNavigation)
                     .Include(e => e.IdtipodocumentoNavigation).ToListAsync();
                return (ListaEmpleados);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> GuardarEmpleado(Empleado entidad)
        {
            try
            {
                await _Entity.AddAsync(entidad);
                return true;

            }
            catch (Exception)
            {
                throw;
            }


        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _Context.SaveChangesAsync() > 0;
        }




    }
}
