using Domain.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Recaudos
{
    public interface ILogin
    {
        Task<List<Cliente>> GetClientes();
  
    }
}
