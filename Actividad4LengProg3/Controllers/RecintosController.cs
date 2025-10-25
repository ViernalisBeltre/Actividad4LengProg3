using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Actividad4LengProg3.Models;

namespace Actividad4LengProg3.Controllers
{
    public class RecintosController : Controller
    {

        public static List<RecintoViewModel> listaRecintos = new List<RecintoViewModel>
        {
            new RecintoViewModel { Codigo = "R001", NombreRecinto = "Santo Domingo", DireccionRecinto = "Av. Máximo Gómez" },
            new RecintoViewModel { Codigo = "R002", NombreRecinto = "Santiago", DireccionRecinto = "Calle del Sol" }
        };

        public IActionResult Lista() => View(listaRecintos);

        public IActionResult Crear() => View();

        [HttpPost]
        public IActionResult Crear(RecintoViewModel recinto)
        {
            if (ModelState.IsValid)
            {
                listaRecintos.Add(recinto);
                TempData["Mensaje"] = "Recinto agregado correctamente.";
                return RedirectToAction("Lista");
            }
            return View(recinto);
        }

        public IActionResult Editar(string codigo)
        {
            var recinto = listaRecintos.FirstOrDefault(r => r.Codigo == codigo);
            if (recinto == null) return NotFound();
            return View(recinto);
        }

        [HttpPost]
        public IActionResult Editar(RecintoViewModel recinto)
        {
            if (ModelState.IsValid)
            {
                var existente = listaRecintos.FirstOrDefault(r => r.Codigo == recinto.Codigo);
                if (existente != null)
                {
                    listaRecintos.Remove(existente);
                    listaRecintos.Add(recinto);
                }
                TempData["Mensaje"] = "Recinto actualizado correctamente.";
                return RedirectToAction("Lista");
            }
            return View(recinto);
        }

        public IActionResult Eliminar(string codigo)
        {
            var recinto = listaRecintos.FirstOrDefault(r => r.Codigo == codigo);
            if (recinto != null)
            {
                listaRecintos.Remove(recinto);
                TempData["Mensaje"] = "Recinto eliminado correctamente.";
            }
            return RedirectToAction("Lista");
        }
    }
}
