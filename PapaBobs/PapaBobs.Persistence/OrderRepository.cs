using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.Persistence
{
    public class OrderRepository
    {
        public static void CreateOrder(DTO.OrderDTO orderDTO)
        {
            var db = new PapaBobsEntities();
            var order = ConvertToEntity(orderDTO);

            db.Orders.Add(order);
            db.SaveChanges();

        }

        public static List<DTO.OrderDTO> GetOrders()
        {
            var db = new PapaBobsEntities();
            var orders = db.Orders.Where(p => p.Completed == false).ToList();
            var ordersDTO = convertToDTO(orders);
            return ordersDTO;

        }

        public static void CompleteOrder(Guid orderId)
        {
            var db = new PapaBobsEntities();
            var order = db.Orders.FirstOrDefault(p => p.OrderId == orderId);
            order.Completed = true;
            db.SaveChanges();
        }

        private static List<DTO.OrderDTO> convertToDTO(List<Order> orders)
        {
            var ordersDTO = new List<DTO.OrderDTO>();
            foreach (var order in orders)
            {
                var orderDTO = new DTO.OrderDTO();
                orderDTO.OrderId = order.OrderId;
                orderDTO.Size = order.Size;
                orderDTO.Crust = order.Crust;
                orderDTO.Pepperoni = order.Pepperoni;
                orderDTO.Sausage = order.Sausage;
                orderDTO.GreenPeppers = order.GreenPeppers;
                orderDTO.Onions = order.Onions;
                orderDTO.Name = order.Name;
                orderDTO.Address = order.Address;
                orderDTO.ZipCode = order.ZipCode;
                orderDTO.Phone = order.Phone;
                orderDTO.PaymentType = order.PaymentType;
                orderDTO.TotalCost = order.TotalCost;

                ordersDTO.Add(orderDTO);
            }

            return ordersDTO;
        }

        private static Order ConvertToEntity(DTO.OrderDTO orderDTO)
        {
            var order = new Order();

            order.OrderId = orderDTO.OrderId;
            order.Size = orderDTO.Size;
            order.Crust = orderDTO.Crust;
            order.Pepperoni = orderDTO.Pepperoni;
            order.Sausage = orderDTO.Sausage;
            order.GreenPeppers = orderDTO.GreenPeppers;
            order.Onions = orderDTO.Onions;
            order.Name = orderDTO.Name;
            order.Address = orderDTO.Address;
            order.ZipCode = orderDTO.ZipCode;
            order.Phone = orderDTO.Phone;
            order.PaymentType = orderDTO.PaymentType;
            order.TotalCost = orderDTO.TotalCost;

            return order;
        }
    }
}
