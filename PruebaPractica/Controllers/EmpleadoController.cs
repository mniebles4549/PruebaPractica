using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaPractica.Core;
using PruebaPractica.Core.Dtos;
using PruebaPractica.Core.Interfaces;
using PruebaPractica.Persistencia.Datos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaPractica.Web.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly CrudApiContext _context;
        private readonly IEmpleadoEntidad _baseEntidad;

        public EmpleadoController(CrudApiContext context, IEmpleadoEntidad baseEntidad)
        {
            _context = context;
            _baseEntidad = baseEntidad;
        }

        // GET: Empleado
        public async Task<IActionResult> Index()
        {
            var ListaEmpleados = await _baseEntidad.ListaDeTodosLosEmpleados();
            return View(ListaEmpleados);
        }


        // GET: Empleado/Create
        public async Task<IActionResult> Create()
        {

            var estado = await _context.Estadocivils.ToListAsync();
            var ListEstado = new List<ListEstado>();
            foreach (var item in estado)
            {
                ListEstado.Add(new ListEstado() { IdEstado = item.Id, NameEstado = item.Nombre });
            }
            ViewBag.listEstadoCivil = ListEstado;
            ViewData["Idtipodocumento"] = new SelectList(_context.Documentos, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmpleadoDto empleadoDto)
        {

            if (ModelState.IsValid)
            {
                var empleado = new Empleado()
                {
                    Apellidos = empleadoDto.Apellidos,
                    Nombres = empleadoDto.Nombres,
                    Fechanacimiento = empleadoDto.FechaNacimiento,
                    Idestadocivil = empleadoDto.IdEstadoCivil,
                    Idtipodocumento = empleadoDto.IdTipodoCumento,
                    Valoraganar = empleadoDto.Valoraganar
                };
                await _baseEntidad.GuardarEmpleado(empleado);
                await _baseEntidad.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var estado = await _context.Estadocivils.ToListAsync();

            var ListEstado = new List<ListEstado>();

            foreach (var item in estado)
            {
                ListEstado.Add(new ListEstado() { IdEstado = item.Id, NameEstado = item.Nombre });
            }
            ViewBag.listEstadoCivil = ListEstado;
            ViewData["Idtipodocumento"] = new SelectList(_context.Documentos, "Id", "Nombre", empleadoDto.IdTipodoCumento);
            return View(empleadoDto);
        }


    }
}
