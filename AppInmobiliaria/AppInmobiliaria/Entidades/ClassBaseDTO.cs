using System;
using System.Collections.Generic;
using System.Text;

namespace AppInmobiliaria.Entidades
{
    public abstract class ClassBaseDTO
        //Es abstracta y no puedo instanciar y no le puedo hacer un new
    {
        public String id { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
