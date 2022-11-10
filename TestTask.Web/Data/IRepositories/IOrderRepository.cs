using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Web.Models;

namespace TestTask.Web.Data.IRepositories
{
    public interface IOrderRepository
    {
        Task CreateAsync(Order order);

        Task UpdateAsync(Order order);

        Task DeleteAsync(int id);

        Task<IEnumerable<Order>> GetAllAsync();

        Task<Order> GetAsync(int id);
    }
}
