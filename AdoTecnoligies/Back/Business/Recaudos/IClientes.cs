using Domain.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Recaudos
{
    public interface IClientes
    {
        Task<List<Cliente>> GetClientes();
        Task<bool> InsertCliente(Cliente Cliente);
        Task<bool> UpdateCliente(Cliente Cliente);
    }
}
