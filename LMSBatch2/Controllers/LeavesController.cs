using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LMSBatch2.Models;

namespace LMSBatch2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeavesController : ControllerBase
    {
        private readonly HexawareLmsProjectContext _context;

        public LeavesController(HexawareLmsProjectContext context)
        {
            _context = context;
        }

        //GET:api/Leaves/approval/{id}
        /*[HttpGet("approval")]
        public async Task<ActionResult<Leave>> LeaveApproval(int LeaveId)
        {
            var leave = await _context.Leaves.FindAsync(LeaveId);
            if (leave == null)
            {
                return NotFound();
            }
            DateTime d1 = (DateTime)leave.LeaveEndDate;
            DateTime d2 = (DateTime)leave.LeaveStartDate;
            TimeSpan t = d1 - d2;
            int days=t.Days;
            if (days > leave.LeaveBalanace)
            {
                return BadRequest("Your leave balance is very less");
            }
            return Ok(days + " Leave approved");
        }*/

        // GET: api/Leaves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Leave>>> GetLeaves()
        {
            return await _context.Leaves.ToListAsync();
        }

        // GET: api/Leaves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Leave>> GetLeave(int id)
        {
            var leave = await _context.Leaves.FindAsync(id);

            if (leave == null)
            {
                return NotFound();
            }

            return leave;
        }

        // PUT: api/Leaves/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeave(int id, Leave leave)
        {
            if (id != leave.LeaveId)
            {
                return BadRequest();
            }

            _context.Entry(leave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveExists(id))
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
        /* [HttpGet("weekend/{leaveId}")]
       public async Task<ActionResult<Employee>> checkWeekend(int leaveId)
        {
            int count = 0;
            int count1 = 0;
            var leave = await _context.Leaves.FindAsync(leaveId);
            if (leave != null)
            {
                DateTime d1 = (DateTime)leave.LeaveStartDate;
                DateTime d2 = (DateTime)leave.LeaveEndDate;
                for(DateTime index = d1; index < d2; index = index.AddDays(1))
                {
                    if ((index.DayOfWeek == DayOfWeek.Saturday) || (index.DayOfWeek == DayOfWeek.Sunday))
                    {
                        count = count + 1;
                        //return Ok("The given days doesnot fall between saturday or sunday"+index);
                    }
                    else
                    {
                        count1 = count1 + 1;
                    }
                }
                TimeSpan t = d2 - d1;
                int days=t.Days;
                leave.LeaveBalanace = leave.LeaveBalanace - count1;


            }
            return Ok("The remaining leave balance is: "+leave.LeaveBalanace);
        }
        */
        [HttpPut("update/{LeaveId}")]
        public async Task<IActionResult> UpdateLeaveStatus(int LeaveId, Leave l)
        {
            int count = 0, count1 = 0;
            var leave =  await _context.Leaves.FindAsync(LeaveId);
            if(leave != null)
            {
                DateTime d1 = (DateTime)leave.LeaveStartDate;
                DateTime d2 = (DateTime)leave.LeaveEndDate;
                for (DateTime index = d1; index < d2; index = index.AddDays(1))
                {
                    if ((index.DayOfWeek == DayOfWeek.Saturday) || (index.DayOfWeek == DayOfWeek.Sunday))
                    {
                        count = count + 1;
                        //return Ok("The given days doesnot fall between saturday or sunday"+index);
                    }
                    else
                    {
                        count1 = count1 + 1;
                    }
                }
                TimeSpan t = d2 - d1;//retrieves the timespan between start and end date
                int days = t.Days;//retrieves the days between start and end date
                //leave.LeaveBalanace = leave.LeaveBalanace - count1;
                days = days - count;
                if (days < leave.LeaveBalanace)
                {
                    leave.LeaveStatus = "Approved";
                    leave.LeaveBalanace = l.LeaveBalanace - days;
                    _context.Entry(leave).State = EntityState.Modified;
                    _context.SaveChanges();
                    return Ok("Leave status approved");
                }                
            }

            return BadRequest("Your leave balance is very less");
        }

            // POST: api/Leaves
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
        public async Task<ActionResult<Leave>> PostLeave(Leave leave)
        {
            _context.Leaves.Add(leave);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeave", new { id = leave.LeaveId }, leave);
        }

        // DELETE: api/Leaves/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeave(int id)
        {
            var leave = await _context.Leaves.FindAsync(id);
            if (leave == null)
            {
                return NotFound();
            }
            if (leave.LeaveStatus == "Approved")
            {
                _context.Leaves.Remove(leave);
                await _context.SaveChangesAsync();

                return Ok("Successfully deleted the approved leave");
            }
            return BadRequest("Sorry couldnot delete the leave");

            
        }

        private bool LeaveExists(int id)
        {
            return _context.Leaves.Any(e => e.LeaveId == id);
        }
    }
}
