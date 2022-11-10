using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Data.Contexts;
using TestTask.Web.Data.IRepositories;
using TestTask.Web.Models;

namespace TestTask.Web.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private DbContext dbContext;
        public OrderRepository()
        {
            dbContext = new DbContext();
        }
        public async Task CreateAsync(Order order)
        {
            await dbContext.ConnectionAsync($"INSERT INTO Orders (SenderCity, SenderAddress, RecipientCity, RecipientAddress, CargoWeight, PickupDate) " +
                $"VALUES ('{order.SenderCity}', '{order.SenderAddress}', '{order.RecipientCity}', '{order.RecipientAddress}', '{order.CargoWeight}', '{order.PickupDate}')");
        }

        public async Task DeleteAsync(int id)
        {
            await dbContext.ConnectionAsync($"DELETE FROM Orders WHERE OrderId = {id};");
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            IList<Order> orders = new List<Order>();
            var reader = await dbContext.ConnectionAsync("SELECT * FROM Orders;");

            while (reader.Read())
            {
                orders.Add(new Order
                {
                    OrderId = reader.GetInt32(0),
                    SenderCity = reader.GetString(1),
                    SenderAddress = reader.GetString(2),
                    RecipientCity = reader.GetString(3),
                    RecipientAddress = reader.GetString(4),
                    CargoWeight = reader.GetInt32(5),
                    PickupDate = reader.GetDateTime(6)
                });
            }

            return orders;
        }

        public async Task<Order> GetAsync(int id)
        {
            Order order = new Order();

            var reader = await dbContext.ConnectionAsync($"SELECT * FROM Orders WHERE id = {id};");

            while (reader.Read())
            {
                order.OrderId = reader.GetInt32(0);
                order.SenderCity = reader.GetString(1);
                order.SenderAddress = reader.GetString(2);
                order.RecipientCity = reader.GetString(3);
                order.RecipientAddress = reader.GetString(4);
                order.CargoWeight = reader.GetInt32(5);
                order.PickupDate = reader.GetDateTime(6);
            }

            return order;
        }

        public async Task UpdateAsync(Order order)
        {
            await dbContext.ConnectionAsync($"ALTER TABLE Orders SET " +
                $"SenderCity = '{order.SenderCity}', " +
                $"SenderAddress = '{order.SenderAddress}', " +
                $"RecipientCity = '{order.RecipientCity}', " +
                $"RecipientAddress = '{order.RecipientAddress}', " +
                $"CargoWeight = '{order.CargoWeight}', " +
                $"PickupDate = '{order.PickupDate}' WHERE id = {order.OrderId};");
        }
    }
}
