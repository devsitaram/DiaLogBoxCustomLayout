using Mad1.Data;
using Mad1.Models.Domain;
using Mad1.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mad1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public StudentController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateStudent(StudentDto request)
        {
            var addStudent = new Student()
            {
                Name = request.Name,
                Email = request.Email,
                FypTitle = request.FypTitle
            };

            await appDbContext.students.AddAsync(addStudent);
            await appDbContext.SaveChangesAsync();

            return Ok(new
            {
                message = "Successfuly added",
                isSuccess = true,
                status = 200,
                result = addStudent
            });
        }

        // User Find By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await appDbContext.students.FindAsync(id);

            if (student == null)
            {
                return NotFound(new
                {
                    message = "User not found",
                    isSuccess = false,
                    status = 404,
                    result = new { }
                });
            }

            return Ok(new
            {
                message = "Successfuly find",
                isSuccess = true,
                status = 200,
                result = student
            });
        }


        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await appDbContext.students.ToListAsync();

            return Ok(new
            {
                message = "Successfuly ",
                isSuccess = true,
                status = 200,
                result = students
            });
        }

        // Delete User
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var student = await appDbContext.students.FindAsync(id);

            if (student == null)
            {
                return NotFound(new
                {
                    message = "User not found",
                    issuccess = false,
                    status = 404,
                    result = new { }
                });
            }

            appDbContext.students.Remove(student);
            await appDbContext.SaveChangesAsync();

            return Ok(new
            {
                message = "Delete success",
                isSuccess = true,
                status = 200,
                result = new { }
            });


        }

        // Update
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(int id, Student updatedStudent)
        {
            var student = await appDbContext.students.FindAsync(id);

            if (student == null)
            {
                return NotFound(new
                {
                    message = "User not found",
                    isSuccess = false,
                    status = 404,
                    result = new { }
                });
            }

            student.Name = updatedStudent.Name;
            student.Email = updatedStudent.Email;
            student.FypTitle = updatedStudent.FypTitle;

            await appDbContext.SaveChangesAsync();

            return Ok(new
            {
                message = "Update successful",
                isSuccess = true,
                status = 200,
                result = student
            });
        }
    }
}
