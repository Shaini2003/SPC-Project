using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models.Entities;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public WarehouseController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllWarehouses()
        {
            var allWarehouses = dbContext.warehouses.ToList();
            return Ok(allWarehouses);
        }

        [HttpGet]
        [Route("{WarehouseID:int}")]

        public IActionResult GetWarehouseById(int WarehouseID)
        {
            var warehouse = dbContext.warehouses.Find(WarehouseID);

            if (warehouse is null)
            {
                return NotFound();
            }
            return Ok(warehouse);
        }


        [HttpPost]
        public IActionResult AddWarehouse(AddWarehouseDTO addWarehouseDto)
        {
            var warehouseEntity = new Warehouse()
            {
                WarehouseID = addWarehouseDto.WarehouseID,
                Location=addWarehouseDto.Location,
                Contact=addWarehouseDto.Contact,
                
            };
            dbContext.warehouses.Add(warehouseEntity);
            dbContext.SaveChanges();

            return Ok(warehouseEntity);
        }

        [HttpPut]
        public IActionResult UpdateWarehouse(int WarehouseID, UpdateWarehouseDTO updateWarehouseDto)
        {
            var warehouse = dbContext.warehouses.Find(WarehouseID);
            if (warehouse is null)
            {
                return NotFound();
            }

            warehouse.WarehouseID = updateWarehouseDto.WarehouseID;
            warehouse.Location = updateWarehouseDto.Location;
            warehouse.Contact = updateWarehouseDto.Contact;
            

            dbContext.SaveChanges();

            return Ok(warehouse);
        }
        [HttpDelete]
        [Route("{WarehouseID:int}")]
        public IActionResult DeleteWarehouse(int WarehouseID)
        {
            var warehouse = dbContext.warehouses.Find(WarehouseID);
            if (warehouse is null)
            {
                return NotFound();
            }
            dbContext.warehouses.Remove(warehouse);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
