using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioApiClientesJson.Models
{
    public class Color
    {
        [JsonProperty("idcolor")]
        public int IdColor { get; set; }
        [JsonProperty("nombre")]
        public String Nombre { get; set; }
        [JsonProperty("hexadecimal")]
        public String Hex { get; set; }
    }
}