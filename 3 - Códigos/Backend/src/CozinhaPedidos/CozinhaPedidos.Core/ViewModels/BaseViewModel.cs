using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozinhaPedidos.Core.ViewModels
{
    public abstract class BaseViewModel
    {
        public int Id { get; set; }
        public int Erased { get; set; }
    }
}
