using Data;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary;
using Labolatorium3.Models;

namespace Labolatorium3.Controllers
{
    [Route("api/organizations")]
    [ApiController]
    public class OrganizationApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrganizationApiController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetFiltered(string filter)
        {
            return Ok(_context.Organizations
                .Where(o => o.Title.StartsWith(filter))
                .Select(o => new { o.Title, o.Id })
                .ToList());
        }

        //[Route("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var organization = _context.Organizations.Find(id);
        //    if (organization == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(organization);
        //    }
        //}
    }
}
