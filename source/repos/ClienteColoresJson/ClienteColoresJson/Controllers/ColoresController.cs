using ClienteColoresJson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ClienteColoresJson.Controllers
{
    public class ColoresController : Controller
    {
        ModeloColores modelo;

        public ColoresController()
        {
            modelo = new ModeloColores();
        }

        // GET: ClientesController 
        public async Task<ActionResult> Index()
        {
            List<Color> lista = await modelo.MostrarColores();
            return View(lista);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Color color)
        {
            await modelo.InsertarColor(color.IdColor, color.Nombre, color.Hex);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int idcolor)
        {
            Color color = await modelo.BuscarColor(idcolor);
            return View(color);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Color color)
        {
            await modelo.ModificarColor(color.IdColor, color.Nombre,color.Hex);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int idcolor)
        {
            await modelo.EliminarColor(idcolor);
            return RedirectToAction("Index");
        }
    }
}