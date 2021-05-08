using AutoMapper;
using CozinhaPedidos.Core.Interfaces.Repositories;
using CozinhaPedidos.Core.Interfaces.Services;
using CozinhaPedidos.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozinhaPedidos.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<ClienteViewModel>> GetAllAsync()
        {
#warning IMPLEMENTAR ESSE MÉTODO
            throw new NotImplementedException();
        }

        public async Task<ClienteViewModel> GetByIdAsync(int id)
        {
            var model = await _clienteRepository.GetByIdAsync(id);

            var viewModel = _mapper.Map<ClienteViewModel>(model);

            return viewModel;
        }
    }
}
