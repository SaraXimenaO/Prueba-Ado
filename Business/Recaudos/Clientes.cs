
using Domain;

using Domain.Entities;


namespace Application.Recaudos
{
    public class Clientes : IClientes
    {

        private readonly ApplicationDbContext _context;

        public Clientes(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Cliente>> GetClientes()
        {
            return _context.Clientes.ToList();

        }

        public async Task<bool> InsertCliente(Cliente Cliente)
        {
            var entity = _context.Clientes.Where(a => a.NumeroIdentificacion == Cliente.NumeroIdentificacion);

            if (entity.Any())
            {
                return false;
            }
            else
            {
                _context.Clientes.Add(new Cliente(Cliente.TipoIdentificacion, Cliente.NumeroIdentificacion, Cliente.Nombre, Cliente.Apellido, Cliente.Genero));
                _context.SaveChanges();
                return true;
            }
        }

        public async Task<bool> UpdateCliente(Cliente Cliente)
        {
            var entity = _context.Clientes.FirstOrDefault(a => a.NumeroIdentificacion == Cliente.NumeroIdentificacion);

            if (!string.IsNullOrEmpty(entity.NumeroIdentificacion))
            {
                entity.TipoIdentificacion = Cliente.TipoIdentificacion;
                entity.Apellido = Cliente.Apellido;
                entity.Genero = Cliente.Genero;
                entity.Nombre = Cliente.Nombre;
                _context.Clientes.Update(entity);
                _context.SaveChanges();
                return true;
                
            }
            else
            {
                return false;
            }
        }
    }
}
