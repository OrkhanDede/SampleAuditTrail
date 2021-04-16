using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditTrail.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuditTrail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Gets()
        {
            var pLsit = await  _context.Products.ToListAsync();
            return Ok(pLsit);
        }
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            //await InitializeData.SeedAsync(_context);
            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateTitleAsync(int id,[FromBody] ProductDto productDto)
        {
            var product= await  _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            product.Price = productDto.Price;
            product.Title = productDto.Title;
            product.Description = productDto.Description;
            _context.SaveChanges();
            return Ok(1);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product= await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok(1);
        }
        [HttpPost("create")]
        public IActionResult Create([FromBody] ProductDto productDto)
        {
            _context.Products.Add(new Product()
            {
                Title = productDto.Title,
                Description = productDto.Description,
                Price = productDto.Price
            });
            _context.SaveChanges();
            return Ok(1);
        }
    }

    public class ProductDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
