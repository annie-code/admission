using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAdmissionService.Data;
using StudentAdmissionService.Models;

namespace StudentAdmissionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAdmissionsController : ControllerBase
    {
        private readonly StudentAdmissionServiceContext _context;

        public StudentAdmissionsController(StudentAdmissionServiceContext context)
        {
            _context = context;
        }

        // GET: api/StudentAdmissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentAdmission>>> GetStudentAdmission()
        {
            return await _context.StudentAdmission.ToListAsync();
        }

        // GET: api/StudentAdmissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentAdmission>> GetStudentAdmission(int id)
        {
            var studentAdmission = await _context.StudentAdmission.FindAsync(id);

            if (studentAdmission == null)
            {
                return NotFound();
            }

            return studentAdmission;
        }

        // PUT: api/StudentAdmissions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentAdmission(int id, StudentAdmission studentAdmission)
        {
            if (id != studentAdmission.StudentID)
            {
                return BadRequest();
            }

            _context.Entry(studentAdmission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentAdmissionExists(id))
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

        // POST: api/StudentAdmissions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentAdmission>> PostStudentAdmission(StudentAdmission studentAdmission)
        {
            _context.StudentAdmission.Add(studentAdmission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentAdmission", new { id = studentAdmission.StudentID }, studentAdmission);
        }

        // DELETE: api/StudentAdmissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentAdmission(int id)
        {
            var studentAdmission = await _context.StudentAdmission.FindAsync(id);
            if (studentAdmission == null)
            {
                return NotFound();
            }

            _context.StudentAdmission.Remove(studentAdmission);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentAdmissionExists(int id)
        {
            return _context.StudentAdmission.Any(e => e.StudentID == id);
        }
    }
}
