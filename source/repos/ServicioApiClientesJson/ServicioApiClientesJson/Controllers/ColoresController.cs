using ServicioApiClientesJson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ServicioApiClientesJson.Controllers
{
    public class ColoresController : ApiController
    {
        ModeloColores modelo;
        public void CrearModelo()
        {
            String path =
                HttpContext.Current.Server.MapPath("~/Documentos/colores.json");
            modelo = new ModeloColores(path);
        }
        public List<Color> Get()
        {
            this.CrearModelo();
            return modelo.GetColores();
        }
        public Color Get(int id)
        {
            this.CrearModelo();
            return modelo.BuscarColor(id);
        }

        [Route("api/NuevoColor")]
        [HttpPost]
        public void Post(Color color)
        {
            this.CrearModelo();
            modelo.InsertaColor(color.IdColor, color.Nombre,color.Hex);
        }
        [Route("api/ModificarColor")]
        [HttpPut]
        public void Put(Color color)
        {
            this.CrearModelo();
            modelo.ModificarColor(color.IdColor, color.Nombre, color.Hex);
        }

        [Route("api/EliminarColor/{idcolor}")]
        [HttpDelete]
        public void Delete(int idcolor)
        {
            this.CrearModelo();
            modelo.EliminarColor(idcolor);
        }
    }
}
