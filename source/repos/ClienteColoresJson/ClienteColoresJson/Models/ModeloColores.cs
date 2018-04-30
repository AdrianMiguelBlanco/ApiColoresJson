using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace ClienteColoresJson.Models
{
    public class ModeloColores
    {
        public async Task<List<Color>> MostrarColores()
        {
            using (HttpClient cliente = new HttpClient())
            {
                String peticion = "api/Colores/";
                cliente.BaseAddress = new Uri("http://localhost:50014/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await cliente.GetAsync(peticion);
                if (response.IsSuccessStatusCode)
                {
                    List<Color> colores = await response.Content.ReadAsAsync<List<Color>>();
                    return colores;
                }
                else
                {
                    return null;
                }
            }
        }


        public async Task<Color> BuscarColor(int idcolor)
        {
            using (HttpClient cliente = new HttpClient())
            {
                String peticion = "api/Colores/" + idcolor;
                cliente.BaseAddress = new Uri("http://localhost:50014/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await cliente.GetAsync(peticion);
                if (response.IsSuccessStatusCode)
                {
                    Color color = await response.Content.ReadAsAsync<Color>();
                    return color;
                }
                else
                {
                    return null;
                }
            }
        }


        public async Task InsertarColor(int idcolor, String nombre, String hexa)
        {
            using (HttpClient cliente = new HttpClient())
            {
                String peticion = "api/NuevoColor/";
                cliente.BaseAddress = new Uri("http://localhost:50014/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Color color = new Color()
                {
                    IdColor = idcolor,
                    Nombre = nombre,
                    Hex = hexa
                };
                HttpResponseMessage response = await cliente.PostAsJsonAsync(peticion, color);
            }
        }


        public async Task ModificarColor(int idcolor, String nombre, String hex)
        {
            using (HttpClient cliente = new HttpClient())
            {
                String peticion = "api/ModificarColor/";
                cliente.BaseAddress = new Uri("http://localhost:50014/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Color cli = new Color()
                {
                    IdColor = idcolor,
                    Nombre = nombre,
                    Hex = hex
                };
                HttpResponseMessage response =
                    await cliente.PutAsJsonAsync(peticion, cli);
            }
        }


        public async Task EliminarColor(int idcolor)
        {
            using (HttpClient cliente = new HttpClient())
            {
                String peticion = "api/EliminarColor/" + idcolor;
                cliente.BaseAddress = new Uri("http://localhost:50014/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response =
                    await cliente.DeleteAsync(peticion);
            }
        }
    }
}