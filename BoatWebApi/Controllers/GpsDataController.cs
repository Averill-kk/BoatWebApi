using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoatWebApi.Models;

namespace BoatWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GpsDataController : ControllerBase
    {
        private readonly GpsDataContext _context;

        public GpsDataController(GpsDataContext context)
        {
            _context = context;
        }

        // GET: api/GpsData
        [HttpGet]
        public IEnumerable<GpsData> GetGps()
        {
            return _context.GpsDatas;
        }

        // GET: api/GpsData/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGpsData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gpsData = await _context.GpsDatas.FindAsync(id);

            if (gpsData == null)
            {
                return NotFound();
            }

            return Ok(gpsData);
        }

        // PUT: api/GpsData/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGpsData([FromRoute] int id, [FromBody] GpsData gpsData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gpsData.Id)
            {
                return BadRequest();
            }

            _context.Entry(gpsData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GpsDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GpsData
        [HttpPost]
        public async Task<IActionResult> PostGpsData([FromBody] GpsData gpsData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GpsDatas.Add(gpsData);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetGpsData", new { id = gpsData.Id }, gpsData);
        }

        // DELETE: api/GpsData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGpsData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gpsData = await _context.GpsDatas.FindAsync(id);
            if (gpsData == null)
            {
                return NotFound();
            }

            _context.GpsDatas.Remove(gpsData);
            await _context.SaveChangesAsync();

            return Ok(gpsData);
        }

        private bool GpsDataExists(int id)
        {
            return _context.GpsDatas.Any(e => e.Id == id);
        }
    }
}