using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using System.Security.Cryptography.X509Certificates;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ChefsController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ChefList()
        {
            var value =_context.Chefs.ToList();
            return Ok (value);
        }
        [HttpPost]
        public IActionResult CreateChef(Chef chef)
        {
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("chef ekleme başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteChef(int id) 
        {
            var value =_context.Chefs.Find(id);
            if (value == null)
                return BadRequest();
            _context.Chefs.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
            
        }
        [HttpGet("GetChef")]
        public IActionResult GetChef(int id) {
            return Ok(_context.Chefs.Find(id));
        }
        [HttpPut]
        public IActionResult PutChef(int id,Chef chef) 
        {
            _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok("şef güncelleme işlemi başarılı");
            
        }

    }
}
