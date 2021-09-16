using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio_1_EDII.Models
{
    public class rutaE<T>
    {
        string rutaSeleccionada { get; set; }
        List<T> numerosEncontrados = new List<T>();
        bool encontroValorB { get; set; }
        string encontroValorS { get; set; }
    }
}
