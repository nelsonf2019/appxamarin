
using System;
using System.Collections.Generic;
using System.Text;

namespace AppInmobiliaria.Entidades
{
    public class ClassPersona:ClassBaseDTO
    {
        public string Email { get; set; }
        public String Password { get; set; }

        public bool EsAdministrador { get; set; }

        public String Nombre { get; set; }

        public String Apellido { get; set; }
    }
}
