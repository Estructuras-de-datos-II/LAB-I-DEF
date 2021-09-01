using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio_1_EDII.Models
{
    public class Movies : IComparable
    {
        public string director { get; set; }
        public float ratingIMBD { get; set; }
        public string genero { get; set; }
        public DateTime lanzamiento { get; set; }
        public int ratingRottenTomatoes { get; set; }
        public string titulo { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 0;
            else return 0;

        }
    }
}
