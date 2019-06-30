﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entUsuario
    {
        public int idUsuario { get; set; }
        public entCliente idCliente { get; set; }
        public String nomUsuario { get; set; }
        public String correo { get; set; }
        public String contrasenia { get; set; }
        public Boolean estUsuario { get; set; }
        public DateTime fecCreacion { get; set; }
        public Boolean tipo { get; set; }
    }
}
