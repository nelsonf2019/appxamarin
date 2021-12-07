using System;
using System.Collections.Generic;
using System.Text;

namespace AppInmobiliaria.Entidades
{
     public class ClassPeriodo:ClassBaseDTO 
    {
        public String IdConjunto { get; set; }
        public String IdCasa { get; set; }
        public float Monto { get; set; }
        public String IdPeriodo { get; set; }
        public bool EsEntrada { get; set; }
        public String Notas { get; set; }

    }
}
