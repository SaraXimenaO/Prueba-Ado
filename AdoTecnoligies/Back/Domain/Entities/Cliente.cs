using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente
    {

        public Cliente(string tipoIdentificacion, string numeroIdentificacion, string nombre, string apellido, string genero)
        {
            Id = Guid.NewGuid();
            TipoIdentificacion = tipoIdentificacion;
            NumeroIdentificacion = numeroIdentificacion;
            Nombre = nombre;
            Apellido = apellido;
            Genero = genero;
        }
        public Guid? Id { get; set; }
        public string TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Nombre  { get; set; }
        public string Apellido { get; set; }
        public string Genero { get; set; }
    }
}
