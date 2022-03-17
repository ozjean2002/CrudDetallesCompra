using CrudDetallesCompra.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudDetallesCompra.Data.Servie
{
    public interface IGetReceipService
    {
        Task<IEnumerable<GetReceip>> Get();
        Task<GetReceip> GetId(int numeroCompra);
    }
}