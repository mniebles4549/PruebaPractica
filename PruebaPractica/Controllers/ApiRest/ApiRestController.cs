using Microsoft.AspNetCore.Mvc;
using PruebaPractica.Core;
using PruebaPractica.Core.Dtos;
using PruebaPractica.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaPractica.Web.Controllers.ApiRest
{
    [Route("api/[controller]")]
    [ApiController]

    public class ApiRestController : ControllerBase
    {
        private readonly IEmpleadoEntidad _baseEntidad;

        public ApiRestController(IEmpleadoEntidad baseEntidad)
        {

            _baseEntidad = baseEntidad;
        }

        [HttpGet]
        public async Task<IActionResult> ListaEmpleados()
        {
            try
            {
                var ListaEmpleados = await _baseEntidad.ListaDeTodosLosEmpleados();
                var list = new List<EmpleadoDtoApi>();
                foreach (var item in ListaEmpleados)
                {
                    list.Add(new EmpleadoDtoApi
                    {
                        Apellidos = item.Apellidos,
                        Nombres = item.Nombres,
                        FechaNacimiento = item.Fechanacimiento,
                        EstadoCivil = item.IdestadocivilNavigation.Nombre,
                        TipodoCumento = item.IdtipodocumentoNavigation.Nombre,
                        Valoraganar = item.Valoraganar
                    });
                }
                return Ok(list);

            }
            catch (Exception ex)
            {

                throw;
            }

        }


    }
}
