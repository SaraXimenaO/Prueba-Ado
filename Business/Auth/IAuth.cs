using Domain.Entities.Autenticacion;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auth
{
    public interface IAuth
    {
        RespuestaAutenticacion GetToken(UserLogin userLogin);
    }
}
