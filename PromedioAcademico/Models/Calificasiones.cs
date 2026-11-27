using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromedioAcademico.Models
{

    public class Calificaciones
    {
        public double Cal1 { get; set; }
        public double Cal2 { get; set; }
        public double Cal3 { get; set; }

        public double Promedio() => (Cal1 + Cal2 + Cal3) / 3;
    }
}
