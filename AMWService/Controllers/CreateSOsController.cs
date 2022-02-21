using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AMWService.DbContext;
using AMWService.Models;

namespace AMWService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateSOsController : ControllerBase
    {
        private readonly  DbConfig _context;

        public CreateSOsController(DbConfig context)
        {
            _context = context;
        }
        //GET: api/CreateSOs
        [HttpGet("GetColumns")]
        public async Task<ActionResult<IEnumerable<Columns>>> Getam_Status()
        {
            return await _context.am_Status.ToListAsync();
        }
        
        [HttpGet("GetServiceOrder")]
        public async Task<ActionResult<IEnumerable<CreateSO>>> Getams_ServiceOrder()
        {
            return await _context.ams_ServiceOrder
                .Select(x => new CreateSO()
                {
                    ID = x.ID,
                    SO = x.SO,
                    CustommerID = x.CustommerID,
                    StatusID = x.StatusID,
                    PriorityID = x.PriorityID,
                    TypeID = x.TypeID,
                    RootcauseID = x.RootcauseID,
                    Image = x.Image,
                    UserID = x.UserID,
                    ImageSrc = String.Format("{0}://{1}{2}/Images/{3}",Request.Scheme,Request.Host,Request.PathBase,x.Image)
                })
                .ToListAsync();
        }

        [HttpGet("GetCustommer")]
        public async Task<ActionResult<IEnumerable<Project>>> Getam_Custommer()
        {
            return await _context.am_Custommer.ToListAsync();
        }
        [HttpGet("GetProblum")]
        public async Task<ActionResult<IEnumerable<Problem>>> Getam_Type()
        {
            return await _context.am_Type.ToListAsync();
        }
        [HttpGet("GetRootcause")]
        public async Task<ActionResult<IEnumerable<RootCause>>> Getam_RootCauseType()
        {
            return await _context.am_RootCauseType.ToListAsync();
        }

        [HttpGet("GetPriolity")]
        public async Task<ActionResult<IEnumerable<Priolity>>> Getam_Priority()
        {
            return await _context.am_Priority.ToListAsync();
        }

        [HttpGet("GetUser")]
        public async Task<ActionResult<IEnumerable<UserOwner>>> Getamv_User()
        {
            return await _context.amv_User.ToListAsync();
        }

        //GET: api/CreateSOs/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<CreateSO>> GetCreateSO(int id)
        //{
        //    var createSO = await _context.ams_ServiceOrder.FindAsync(id);

        //    if (createSO == null)
        //    {
        //        return NotFound();
        //    }

        //    return createSO;
        //}

        // PUT: api/CreateSOs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCreateSO(int id, CreateSO createSO)
        {
            if (id != createSO.ID)
            {
                return BadRequest();
            }

            _context.Entry(createSO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreateSOExists(id))
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

        // POST: api/CreateSOs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreateSO>> PostCreateSO(CreateSO createSO)
        {
            _context.ams_ServiceOrder.Add(createSO);
            await _context.SaveChangesAsync();
     
            return Ok(new Response { Status = "Success", Message = "Success" });
        }

        // DELETE: api/CreateSOs/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCreateSO(int id)
        //{
        //    var createSO = await _context.ams_ServiceOrder.FindAsync(id);
        //    if (createSO == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.ams_ServiceOrder.Remove(createSO);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool CreateSOExists(int id)
        {
            return _context.ams_ServiceOrder.Any(e => e.ID == id);
        }
    }
}
