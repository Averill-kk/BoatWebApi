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
    public class GpsBoatDatasController : ControllerBase
    {
        private readonly GpsDataContext _context;

        public GpsBoatDatasController(GpsDataContext context)
        {
            _context = context;
        }

        // GET: api/GpsBoatDatas
        [HttpGet]
        public IEnumerable<GpsBoatData> GetGpsBoatDatas()
        {
            return _context.GpsBoatDatas;
        }

        // GET: api/GpsBoatDatas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGpsBoatData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gpsBoatData = await _context.GpsBoatDatas.FindAsync(id);

            if (gpsBoatData == null)
            {
                return NotFound();
            }

            return Ok(gpsBoatData);
        }

        // PUT: api/GpsBoatDatas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGpsBoatData([FromRoute] int id, [FromBody] GpsBoatData gpsBoatData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gpsBoatData.Id)
            {
                return BadRequest();
            }

            _context.Entry(gpsBoatData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GpsBoatDataExists(id))
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

        // POST: api/GpsBoatDatas
        [HttpPost]
        public async Task<IActionResult> PostGpsBoatData([FromBody] GpsBoatData gpsBoatData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GpsBoatDatas.Add(gpsBoatData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGpsBoatData", new { id = gpsBoatData.Id }, gpsBoatData);
        }

        // DELETE: api/GpsBoatDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGpsBoatData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gpsBoatData = await _context.GpsBoatDatas.FindAsync(id);
            if (gpsBoatData == null)
            {
                return NotFound();
            }

            _context.GpsBoatDatas.Remove(gpsBoatData);
            await _context.SaveChangesAsync();

            return Ok(gpsBoatData);
        }

        private bool GpsBoatDataExists(int id)
        {
            return _context.GpsBoatDatas.Any(e => e.Id == id);
        }
    }
}