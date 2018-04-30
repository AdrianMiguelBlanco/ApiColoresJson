using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioApiClientesJson.Models
{
    public class ListaColores
    {
        [JsonProperty("colores")]
        public List<Color> Colores { get; set; }
    }
}