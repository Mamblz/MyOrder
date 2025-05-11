using System.Diagnostics;
namespace OrderManagment
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
        public int Count { get; set; }
        public DateTime OrderGet { get; set; }
    }
    public interface IOrderManagment
    {
        Order CreateOrder(string name, string user, string status, int count);
        bool DeleteOrder(int orderId);
        Order GetOrderById(int orderId);
    }

    public class OrderTask : IOrderManagment
    {
        public readonly List<Order> orders = new List<Order>();
        private int NextId = 1;

        public Order CreateOrder(string name, string user, string status, int count)
        {
            var order = new Order
            {
                Id = NextId++,
                Name = name,
                User = user,
                Status = status,
                Count = count,
                OrderGet = DateTime.Now
            };
            orders.Add(order);
            string log = $"[INFO] Order created: {order.Id}, {order.Name}, {order.User}, {order.Count}";
            Debug.WriteLine(log);
            File.AppendAllText("log.txt", log + Environment.NewLine);
            return order;
        }

        public bool DeleteOrder(int orderId)
        {
            var order = orders.FirstOrDefault(x => x.Id == orderId);
            if (order != null)
            {
                orders.Remove(order);
                return true;
            }
            return false;
        }

        public Order GetOrderById(int orderId)
        {
            return orders.FirstOrDefault(x => x.Id == orderId);
        }
    }
}
