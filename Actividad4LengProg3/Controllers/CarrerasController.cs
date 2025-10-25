using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Actividad4LengProg3.Models;

namespace Actividad4LengProg3.Controllers
{
    public class CarrerasController : Controller
    {
        public static List<CarreraViewModel> listaCarreras = new List<CarreraViewModel>
        {
            new CarreraViewModel { Codigo = "C001", NombreCarrera = "Ingeniería en Sistemas", CantidadCreditos = 180, CantidadMaterias = 45 },
            new CarreraViewModel { Codigo = "C002", NombreCarrera = "Diseño Gráfico", CantidadCreditos = 160, CantidadMaterias = 40 }
        };

        public IActionResult Lista() => View(listaCarreras);

        public IActionResult Crear() => View();

        [HttpPost]
        public IActionResult Crear(CarreraViewModel carrera)
        {
            if (ModelState.IsValid)
            {
                listaCarreras.Add(carrera);
                TempData["Mensaje"] = "Carrera agregada correctamente.";
                return RedirectToAction("Lista");
            }
            return View(carrera);
        }

        public IActionResult Editar(string codigo)
        {
            var carrera = listaCarreras.FirstOrDefault(c => c.Codigo == codigo);
            if (carrera == null) return NotFound();
            return View(carrera);
        }

        [HttpPost]
        public IActionResult Editar(CarreraViewModel carrera)
        {
            if (ModelState.IsValid)
            {
                var existente = listaCarreras.FirstOrDefault(c => c.Codigo == carrera.Codigo);
                if (existente != null)
                {
                    listaCarreras.Remove(existente);
                    listaCarreras.Add(carrera);
                }
                TempData["Mensaje"] = "Carrera actualizada correctamente.";
                return RedirectToAction("Lista");
            }
            return View(carrera);
        }

        public IActionResult Eliminar(string codigo)
        {
            var carrera = listaCarreras.FirstOrDefault(c => c.Codigo == codigo);
            if (carrera != null)
            {
                listaCarreras.Remove(carrera);
                TempData["Mensaje"] = "Carrera eliminada correctamente.";
            }
            return RedirectToAction("Lista");
        }
    }
}
