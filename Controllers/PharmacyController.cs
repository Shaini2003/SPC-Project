using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models.Entities;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public PharmacyController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllPharmacies()
        {
            var allPharmacies = dbContext.pharmacies.ToList();
            return Ok(allPharmacies);
        }

        [HttpGet]
        [Route("{PharmacyID:int}")]

        public IActionResult GetPharmacyById(int PharmacyID)
        {
            var pharmacy = dbContext.pharmacies.Find(PharmacyID);

            if (pharmacy is null)
            {
                return NotFound();
            }
            return Ok(pharmacy);
        }


        [HttpPost]
        public IActionResult AddPharmacy(AddPharmacyDTO addPharmacyDto)
        {
            var pharmacyEntity = new Pharmacy()
            {
                PharmacyID = addPharmacyDto.PharmacyID,
                PharmacyName=addPharmacyDto.PharmacyName,
                Location=addPharmacyDto.Location,
                Contact=addPharmacyDto.Contact,
                LinkedStatus=addPharmacyDto.LinkedStatus,
                


            };
            dbContext.pharmacies.Add(pharmacyEntity);
            dbContext.SaveChanges();

            return Ok(pharmacyEntity);
        }

        [HttpPut]
        public IActionResult UpdatePharmacy(int PharmacyID, UpdatePharmacyDTO updatepharmacyDto)
        {
            var pharmacy = dbContext.pharmacies.Find(PharmacyID);
            if (pharmacy is null)
            {
                return NotFound();
            }

            pharmacy.PharmacyID = updatepharmacyDto.PharmacyID;
            pharmacy.PharmacyName = updatepharmacyDto.PharmacyName;
            pharmacy.Location = updatepharmacyDto.Location;
            pharmacy.Contact = updatepharmacyDto.Contact;
            pharmacy.LinkedStatus = updatepharmacyDto.LinkedStatus;
            


            dbContext.SaveChanges();

            return Ok(pharmacy);
        }
        [HttpDelete]
        [Route("{PharmacyID:int}")]
        public IActionResult DeletePharmacy(int PharmacyID)
        {
            var pharmacy = dbContext.pharmacies.Find(PharmacyID);
            if (pharmacy is null)
            {
                return NotFound();
            }
            dbContext.pharmacies.Remove(pharmacy);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
