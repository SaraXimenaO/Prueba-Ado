﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Autenticacion
{
    public class RespuestaAutenticacion
    {
        public string Token { get; set; }
        public DateTime Expiracion { get; set; }
    }
}
