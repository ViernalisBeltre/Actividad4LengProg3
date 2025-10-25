using Microsoft.AspNetCore.Mvc;
using Actividad4LengProg3.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Actividad4LengProg3.Controllers
{
    public class EstudiantesController : Controller
    {
        private static List<EstudianteViewModel> listaEstudiantes = new List<EstudianteViewModel>();

        public ActionResult Index()
        {
            ViewBag.Carreras = GetCarreras();
            ViewBag.Recintos = GetRecintos();
            ViewBag.Generos = GetGeneros();
            ViewBag.Turnos = GetTurnos();
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(EstudianteViewModel estudiante)
        {
            if (estudiante.EstaBecado && (estudiante.PorcentajeBeca == null))
            {
                ModelState.AddModelError("PorcentajeBeca", "Debe ingresar el porcentaje de beca si está becado.");
            }

            if (ModelState.IsValid)
            {
                listaEstudiantes.Add(estudiante);
                TempData["Mensaje"] = "Estudiante registrado correctamente.";
                return RedirectToAction("Lista");
            }

            ViewBag.Carreras = GetCarreras();
            ViewBag.Recintos = GetRecintos();
            ViewBag.Generos = GetGeneros();
            ViewBag.Turnos = GetTurnos();
            return View("Index", estudiante);
        }

        public ActionResult Lista()
        {
            return View(listaEstudiantes);
        }

        public ActionResult Editar(string matricula)
        {
            var estudiante = listaEstudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante == null)
                return HttpNotFound();

            ViewBag.Carreras = GetCarreras();
            ViewBag.Recintos = GetRecintos();
            ViewBag.Generos = GetGeneros();
            ViewBag.Turnos = GetTurnos();
            return View(estudiante);
        }

        [HttpPost]
        public ActionResult Editar(EstudianteViewModel estudiante)
        {
            if (estudiante.EstaBecado && (estudiante.PorcentajeBeca == null))
            {
                ModelState.AddModelError("PorcentajeBeca", "Debe ingresar el porcentaje de beca si está becado.");
            }

            if (ModelState.IsValid)
            {
                var existente = listaEstudiantes.FirstOrDefault(e => e.Matricula == estudiante.Matricula);
                if (existente != null)
                {
                    listaEstudiantes.Remove(existente);
                    listaEstudiantes.Add(estudiante);
                }
                TempData["Mensaje"] = "Estudiante actualizado correctamente.";
                return RedirectToAction("Lista");
            }

            ViewBag.Carreras = GetCarreras();
            ViewBag.Recintos = GetRecintos();
            ViewBag.Generos = GetGeneros();
            ViewBag.Turnos = GetTurnos();
            return View(estudiante);
        }

        public ActionResult Eliminar(string matricula)
        {
            var estudiante = listaEstudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante != null)
            {
                listaEstudiantes.Remove(estudiante);
                TempData["Mensaje"] = "Estudiante eliminado correctamente.";
            }
            return RedirectToAction("Lista");
        }

        private List<string> GetCarreras() => new List<string>
        {
            "Ingeniería en Sistemas", "Administración de Empresas", "Contabilidad", "Diseño Gráfico", "Derecho"
        };

        private List<string> GetRecintos() => new List<string>
        {
            "Santo Domingo", "Santiago", "La Vega", "San Pedro", "Puerto Plata"
        };

        private List<string> GetGeneros() => new List<string> { "Masculino", "Femenino", "Otro" };

        private List<string> GetTurnos() => new List<string> { "Matutino", "Vespertino", "Nocturno" };
    }
}

