using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Project.Data;
using Project.Models;
using Project.Models.Entities;
using SPC.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Project.Controllers
{
    // localhost:xxxx/api/orders
    [Route("api/[controller]/[action]")]
    [ApiController]
   
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public OrdersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var allOrders = dbContext.Orders.ToList();
            return Ok(allOrders);
        }
        [HttpGet]
        [Route("{OrderID:int}")]

        public IActionResult GetOrderById(int OrderID)
        {
            var order = dbContext.Orders.Find(OrderID);

            if (order is null)
            {
                return NotFound();
            }
            return Ok(order);
        }



        [HttpPost]
        public IActionResult AddOrder(AddOrderDto addOrderDto)
        {
            var orderEntity = new Order()
            {
                DrugId = addOrderDto.DrugId,
                Quantity = addOrderDto.Quantity,
                

            };
            dbContext.Orders.Add(orderEntity);
            dbContext.SaveChanges();

            return Ok(orderEntity);
        }

        [HttpPut]
        public IActionResult UpdateOrders(int OrderID, updateOrderDto updateOrderDto)
        {
            var order = dbContext.Orders.Find(OrderID);
            if (order is null)
            {
                return NotFound();
            }

            order.DrugId = updateOrderDto.DrugId;
            order.Quantity = updateOrderDto.Quantity;
            

            dbContext.SaveChanges();

            return Ok(order);
        }
        [HttpDelete]
        [Route("{OrderID:int}")]
        public IActionResult DeleteOrder(int OrderID)
        {
            var order = dbContext.Orders.Find(OrderID);
            if (order is null)
            {
                return NotFound();
            }
            dbContext.Orders.Remove(order);
            dbContext.SaveChanges();

            return Ok();
        }

        
    }
}