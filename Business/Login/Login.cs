
using Domain;

using Domain.Entities;


namespace Application.Recaudos
{
    public class Login : ILogin
    {

        private readonly ApplicationDbContext _context;

        public Login(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Cliente>> GetClientes()
        {
            return _context.Clientes.ToList();

        }

       
    }
}
