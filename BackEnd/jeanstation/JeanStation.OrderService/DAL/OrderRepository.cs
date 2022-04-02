using JeanStation.OrderService.Models;
using System.Collections.Generic;
using System.Linq;

namespace JeanStation.OrderService.DAL
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDBContext _dbContext;
        public OrderRepository(OrderDBContext orderDBContext)
        {
            this._dbContext = orderDBContext;
        }
        public bool EditOrderStatus(int orderId, string orderStatus)
        {
            try
            {
                Order status = _dbContext.Orders.Find(orderId);
                if (status == null)
                {
                    return false;
                }
                else
                {
                    status.OrderStatus =  orderStatus;
                    //_dbContext.Orders.Attach(status).Property(s => s.OrderStatus).IsModified = true;
                    _dbContext.Orders.Update(status);
                    _dbContext.SaveChanges();
                    return true;
                }
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
                return _dbContext.Orders.Where(u => u.UserId == userId).ToList();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public Order GetOrderById(int orderId)
        {
            try
            {
                return _dbContext.Orders.Find(orderId);
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
                List<MultiItemsOrder> status =  _dbContext.MultiItemsOrders.Where(e=> e.OrderId == orderId).ToList();
                return status;

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
                if(order == null )
                {
                    return null;
                }
                else
                {
                    _dbContext.Orders.Add(order);
                    var result = _dbContext.SaveChanges();
                    Order order1 = _dbContext.Orders.Where(s => s.OrderId == order.OrderId).SingleOrDefault();
                    
                    return order1;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public  bool AddMultiItemsOrders(MultiItemsOrder multiItemsOrder)
        {
            try
            {
                
               
                    _dbContext.MultiItemsOrders.Add(multiItemsOrder);
                    _dbContext.SaveChanges();
                    return true;
                
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
                _dbContext.ReturnOrders.Add(order);
                _dbContext.SaveChanges();
                return order;
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
                return _dbContext.Orders.ToList();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
