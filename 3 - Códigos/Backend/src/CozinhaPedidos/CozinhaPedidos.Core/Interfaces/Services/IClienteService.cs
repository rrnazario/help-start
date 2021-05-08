using CozinhaPedidos.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozinhaPedidos.Core.Interfaces.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteViewModel>> GetAllAsync();
        Task<ClienteViewModel> GetByIdAsync(int id);
    }
}
