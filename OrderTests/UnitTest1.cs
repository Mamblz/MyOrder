using OrderManagment;

namespace OrderTests
{
    public class OrderTests
    {
        private readonly IOrderManagment _testOrder;

        public OrderTests()
        {
            _testOrder = new OrderTask();
        }

        [Fact]
        public void CreateOrders()
        {
            var order = _testOrder.CreateOrder("Заказ", "Клиент", "Статус", 5000);
            Assert.Equal("Заказ", order.Name);
            Assert.Equal("Клиент", order.User);
            Assert.Equal("Статус", order.Status);
            Assert.Equal(5000, order.Count);
        }

        [Fact]
        public void DeleteOrders()
        {
            var order = _testOrder.CreateOrder("Заказ", "Клиент", "Статус", 5000);
            var result = _testOrder.DeleteOrder(order.Id);

            Assert.True(result);
            Assert.Null(_testOrder.GetOrderById(order.Id));
        }

        [Fact]
        public void GetOrders()
        {
            var order = _testOrder.CreateOrder("Заказ", "Клиент", "Статус", 5000);
            var featchorder = _testOrder.GetOrderById(order.Id);

            Assert.NotNull(featchorder);
            Assert.Equal(order.Id, featchorder.Id);
        }
    }
}