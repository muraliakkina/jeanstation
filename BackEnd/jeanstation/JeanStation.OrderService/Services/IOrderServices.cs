using JeanStation.OrderService.Models;
using System.Collections.Generic;

namespace JeanStation.OrderService.Services
{
    public interface IOrderServices
    {
        List<Order> GetAllOrdersByUser(int userId);
        List<Order> GetAllOrders();
        Order PlaceOrder(Order order);
        Order GetOrderById(int oderId);
        List<MultiItemsOrder> GetItemsInOrder(int orderId);
        bool EditOrderStatus(int orderId, string orderStatus);
        ReturnOrder ReturnTheProduct(ReturnOrder order);
        bool AddMultiItemsOrders(MultiItemsOrder multiItemsOrder);
    }
}
