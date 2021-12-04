using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaPractica.Core;
using PruebaPractica.Persistencia.Datos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaPractica.Web.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly CrudApiContext _context;

        public EmpleadoController(CrudApiContext context)
        {
            _context = context;
        }

        // GET: Empleado
        public async Task<IActionResult> Index()
        {
            var crudApiContext = _context.Empleados.Include(e => e.IdestadocivilNavigation).Include(e => e.IdtipodocumentoNavigation);
            return View(await crudApiContext.ToListAsync());
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
                    Fechanacimiento = empleadoDto.Fechanacimiento,
                    Idestadocivil = empleadoDto.Idestadocivil,
                    Idtipodocumento = empleadoDto.Idtipodocumento,
                    Valoraganar = empleadoDto.Valoraganar
                };
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var estado = await _context.Estadocivils.ToListAsync();

            var ListEstado = new List<ListEstado>();

            foreach (var item in estado)
            {
                ListEstado.Add(new ListEstado() { IdEstado = item.Id, NameEstado = item.Nombre });
            }
            ViewBag.listEstadoCivil = ListEstado;


            ViewData["Idtipodocumento"] = new SelectList(_context.Documentos, "Id", "Nombre", empleadoDto.Idtipodocumento);
            return View(empleadoDto);
        }






    }
}
