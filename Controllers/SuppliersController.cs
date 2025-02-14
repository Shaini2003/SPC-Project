using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Project.Data;
using Project.Models;
using Project.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Project.Controllers
{
    // localhost:xxxx/api/suppliers
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public SuppliersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllSuppliers()
        {
           var allSuppliers = dbContext.Suppliers.ToList();
            return Ok(allSuppliers);
        }

        [HttpGet]
        [Route("{id:guid}")]

        public IActionResult GetSupplierById(Guid id) 
        {
            var supplier = dbContext.Suppliers.Find(id);

            if(supplier is null)
            {
                return NotFound();
            }
            return Ok(supplier);
        }


        [HttpPost]
        public IActionResult AddSupplier(AddSupplierDto addSupplierDto)
        {
            var supplierEntity = new Supplier()
            {
                Name = addSupplierDto.Name,
                Email = addSupplierDto.Email,
                Phone = addSupplierDto.Phone,
                Password =addSupplierDto.Password,

            };
            dbContext.Suppliers.Add(supplierEntity);
            dbContext.SaveChanges();

            return Ok(supplierEntity);
        }

        [HttpPut]
        public IActionResult UpdateSuppliers(Guid id,UpdateSupplierDto updateSupplierDto)
        {
            var supplier = dbContext.Suppliers.Find(id);
            if(supplier is null)
            {
                return NotFound();
            }

            supplier.Name = updateSupplierDto.Name;
            supplier.Email = updateSupplierDto.Email;
            supplier.Phone = updateSupplierDto.Phone;
            supplier.Password = updateSupplierDto.Password;

            dbContext.SaveChanges();

            return Ok(supplier);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteSupplier(Guid id)
        {
            var supplier = dbContext.Suppliers.Find(id);
            if(supplier is null)
            {
                return NotFound();
            }
            dbContext.Suppliers.Remove(supplier);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
