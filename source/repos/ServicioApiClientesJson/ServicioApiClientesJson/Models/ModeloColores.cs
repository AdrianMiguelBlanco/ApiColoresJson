using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ServicioApiClientesJson.Models
{
    public class ModeloColores
    {
        public String Path { get; set; }

        public ModeloColores(String path)
        {
            this.Path = path;
        }

        public List<Color> GetColores()
        {
            List<Color> listacolores = new List<Color>();
            var json = File.ReadAllText(this.Path);
            var jObject = JObject.Parse(json);
            JArray colores = (JArray)jObject["colores"];
            foreach (var coloresjson in colores)
            {
                Color color = new Color();
                color.IdColor = int.Parse(coloresjson["idcolor"].ToString());
                color.Nombre = coloresjson["nombre"].ToString();
                color.Hex = coloresjson["hexadecimal"].ToString();
                listacolores.Add(color);
            }
            return listacolores;
        }
        public Color BuscarColor(int idcolor)
        {
            Color color = null;
            var json = File.ReadAllText(this.Path);
            var jObject = JObject.Parse(json);
            JArray colores = (JArray)jObject["colores"];
            foreach (var coloresjson in colores)
            {
                int idclientejson = int.Parse(coloresjson["idcolor"].ToString());
                if (idclientejson == idcolor)
                {
                    color = new Color();
                    color.IdColor = int.Parse(coloresjson["idcolor"].ToString());
                    color.Nombre = coloresjson["nombre"].ToString();
                    color.Hex = coloresjson["hexadecimal"].ToString();
                    break;
                }
            }
            return color;
        }

        public void InsertaColor(int idcolor, String nombre,String hexa)
        {
            var json = File.ReadAllText(this.Path);
            ListaColores lista = JsonConvert.DeserializeObject<ListaColores>(json);
            Color nuevocolor = new Color();
            nuevocolor.IdColor = idcolor;
            nuevocolor.Nombre = nombre;
            nuevocolor.Hex = hexa;
            lista.Colores.Add(nuevocolor);
            String newjson = JsonConvert.SerializeObject(lista, Formatting.Indented);
            File.WriteAllText(Path, newjson);
        }

        public void ModificarColor(int idcolor, String nombre,String hexa)
        {
            var json = File.ReadAllText(this.Path);
            ListaColores lista = JsonConvert.DeserializeObject<ListaColores>(json);
            Color color = lista.Colores.Where(z => z.IdColor == idcolor).First();
            color.Nombre = nombre;
            color.Hex = hexa;
            String newjson = JsonConvert.SerializeObject(lista, Formatting.Indented);
            File.WriteAllText(Path, newjson);
        }

        public void EliminarColor(int idcolor)
        {
            var json = File.ReadAllText(this.Path);
            ListaColores lista = JsonConvert.DeserializeObject<ListaColores>(json);
            Color cliente = lista.Colores.Where(z => z.IdColor == idcolor).First();
            lista.Colores.Remove(cliente);
            String newjson = JsonConvert.SerializeObject(lista, Formatting.Indented);
            File.WriteAllText(Path, newjson);
        }
    }
}