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
    public class EmployeesController : ControllerBase
    {
        private readonly HexawareLmsProjectContext _context;

        public EmployeesController(HexawareLmsProjectContext context)
        {
            _context = context;
        }


        //After successful login he will be redirected to his personal details page
        [HttpGet("login")]
        public  IQueryable<Employee> Validate(string name,string pass)
        {
            var  emp = from e in _context.Employees
                        select e;
            if(!(string.IsNullOrEmpty(name)&&string.IsNullOrEmpty(pass)))
            {
                return emp.Where(data=>data.EmpUname==name&&data.EmpPass==pass);
            }
            return null;
        }
     
        //GET:api/Employees/empname/{name}
        [HttpGet("empname/{name}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmpByName(string name)
        {

            List<Employee> emp = await _context.Employees.Where(data => data.EmpName == name).ToListAsync();
            if (emp == null)
            {
                return NotFound();
            }
            return emp;
        }
        [HttpGet("level/{level}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmpByLevel(int level)
        {

            List<Employee> emp = await _context.Employees.Where(data => data.Level == level).ToListAsync();
            if (emp != null)
            {
                return emp;
            }
            return NotFound("No employees found with such records");
        }



        //To get employees based on designation

        //GET:api/Employees/designation/{designation}

        [HttpGet("designation/{designation}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmpByDesignation(string designation)
        {

            List<Employee> emp = await _context.Employees.Where(data => data.Designation == designation).ToListAsync();
            if (emp == null)
            {
                return NotFound();
            }
            return emp;
        }
        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound("No employee with such record");
            }

            return employee;
        }
        [HttpGet("manager/{managerId}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeByManagerId(int managerId)
        {
            var employee=await _context.Employees.FindAsync(managerId);
            if (employee == null)
            {
                return NotFound();
            }
            
            return await _context.Employees.Where(data=>data.ManagerId==managerId).ToListAsync();
        }


        //checking and desucting the weekend and holidays
       

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmpId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmpId }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmpId == id);
        }
    }
}
