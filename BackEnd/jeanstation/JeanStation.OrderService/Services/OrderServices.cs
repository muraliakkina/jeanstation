using JeanStation.OrderService.DAL;
using JeanStation.OrderService.Models;
using System.Collections.Generic;

namespace JeanStation.OrderService.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _repo;
        public OrderServices(IOrderRepository orderRepository)
        {
            this._repo = orderRepository;
        }
        public bool EditOrderStatus(int orderId, string orderStatus)
        {
            try
            {
                return _repo.EditOrderStatus(orderId, orderStatus);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public List<Order> GetAllOrdersByUser(int userId)
        {
            try
            {
                return _repo.GetAllOrdersByUser(userId);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public List<Order> GetAllOrders()
        {
            try
            {
                return _repo.GetAllOrders();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public Order GetOrderById(int oderId)
        {
            try
            {
                return _repo.GetOrderById(oderId);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public List<MultiItemsOrder> GetItemsInOrder(int orderId)
        {
            try
            {
                return _repo.GetItemsInOrder(orderId);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public Order PlaceOrder(Order order)
        {
            try
            {
                return _repo.PlaceOrder(order);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public ReturnOrder ReturnTheProduct(ReturnOrder order)
        {
            try
            {
                return _repo.ReturnTheProduct(order);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public bool AddMultiItemsOrders(MultiItemsOrder multiItemsOrder)
        {
            try
            {
                return _repo.AddMultiItemsOrders(multiItemsOrder);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
