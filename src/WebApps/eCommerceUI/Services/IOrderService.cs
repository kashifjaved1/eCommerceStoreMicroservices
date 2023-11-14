using eCommerceUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerceUI.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName);
    }

}
