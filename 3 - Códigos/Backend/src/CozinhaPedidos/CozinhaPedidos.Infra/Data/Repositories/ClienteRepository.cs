using CozinhaPedidos.Core.Entities;
using CozinhaPedidos.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozinhaPedidos.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await Task.FromResult(new Cliente()
            {
                Id = new Random().Next()
            });
        }
    }
}
